using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ModuleServicePOS.Data;
using ModuleServicePOS.Data.FormModel;
using ModuleServicePOS.Data.ModelClasses;
using ModuleServicePOS.Repository.Constant;
using ModuleServicePOS.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ModuleServicePOS.Controllers
{
    public class AdminController : Controller
    {
        private readonly ILogger<AdminController> _logger;
        private readonly IOrderService _orderService;
        private readonly ISummaryOfReceivedService _summaryOfReceivedService;
        private readonly IEstimateDetailService _estimateDetailService;
        private IConfiguration _config;
        private ApplicationContext _context;
        public AdminController(ILogger<AdminController> logger, IOrderService orderService, IEstimateDetailService estimateDetailService, ISummaryOfReceivedService summaryOfReceivedService, ApplicationContext context, IConfiguration config)
        {
            _logger = logger;
            _orderService = orderService;
            _summaryOfReceivedService= summaryOfReceivedService;
            _estimateDetailService = estimateDetailService;
            _context = context;
            _config = config;
        }
        public IActionResult Index()
        {
            return View(_orderService.GetOrders());
        }

        [HttpGet]
        public IActionResult Repair(long id)
        {
            #region PRIVATE FUNCTION 
            EstimateDetailsFormModel _mappingEstimateDetailsToEstimateDetailsFormModel(EstimateDetails estimateDetails)
            {
                return new EstimateDetailsFormModel
                {
                    Id = estimateDetails.Id,
                    SerialNo = estimateDetails.SerialNo,
                    Amount = estimateDetails.Amount,
                    ItemAddDate = estimateDetails.ItemAddDate,
                    Description = estimateDetails.Description,
                    OrderDetailId = estimateDetails.OrderDetailId
                };
            } 
            #endregion
            OrderDetailsFormModel orderDetails = new OrderDetailsFormModel();
            if (id > 0)
            {
                var orderDetailItem = _orderService.GetOrder(id);
                orderDetails = new OrderDetailsFormModel
                {
                    Address = orderDetailItem.Address,
                    ClientName = orderDetailItem.ClientName,
                    DatePrepared = orderDetailItem.DatePrepared,
                    MobileNo = orderDetailItem.MobileNo,
                    Model = orderDetailItem.Model,
                    PreparedBy = orderDetailItem.PreparedBy,
                    SerialNo = orderDetailItem.SerialNo,
                    TechnicianNote = orderDetailItem.TechnicianNote,
                    ProductStatusList = orderDetailItem.ProductStatus.Split(","),
                    IsClosed = orderDetailItem.IsClosed,
                    Id = orderDetailItem.Id
                };
                orderDetails.SummaryOfReceivedList = _summaryOfReceivedService.GetAllByOrderId(id).ToList().Select(x => x.ItemName);
                orderDetails.EstimateDetailsList = _estimateDetailService.GetAllByOrderId(id).Where(x => x.IsDelete != true).ToList().Select(item => _mappingEstimateDetailsToEstimateDetailsFormModel(item));
            }
            else {
                orderDetails.PreparedBy = HttpContext.Session.GetString(Constants.UName);
                orderDetails.SerialNo = DateTime.UtcNow.ToString("yyyyMMdd-HHmmss");
            }
            return View(orderDetails);
        }

        [HttpPost]
        public IActionResult Repair(OrderDetailsFormModel orderDetails)
        {

            #region INTERNAL FUNCTION
            void _summaryOfReceivedServiceInsert(IEnumerable<string> summaryOfReceivedList, long orderDetailId)
            {
                foreach (var item in summaryOfReceivedList)
                {
                    _summaryOfReceivedService.Insert(new SummaryOfReceived
                    {
                        OrderDetailId = orderDetailId,
                        ItemName = item,
                    });
                }
            }

            OrderDetails _mappingOrderDetailsFormModelToOrderDetails(OrderDetailsFormModel orderDetailsFormModel) {
                return new OrderDetails
                {
                    Id = orderDetailsFormModel.Id,
                    Model = orderDetailsFormModel.Model,
                    Address = orderDetailsFormModel.Address,
                    SystemType = String.Join(",", orderDetailsFormModel.SystemType.ToString()),
                    OrderStatus = orderDetailsFormModel.OrderStatus.ToString(),
                    IsClosed = orderDetailsFormModel.IsClosed,
                    MobileNo = orderDetailsFormModel.MobileNo,
                    SerialNo = orderDetailsFormModel.SerialNo,
                    PreparedBy = orderDetailsFormModel.PreparedBy,
                    ClientName = orderDetailsFormModel.ClientName,
                    DatePrepared = orderDetailsFormModel.DatePrepared,
                    TechnicianNote = orderDetailsFormModel.TechnicianNote,
                    SubTotal = orderDetailsFormModel.SubTotal,
                    GrandTotal = orderDetailsFormModel.GrandTotal,
                    ProductStatus = String.Join(",", orderDetailsFormModel.ProductStatusList),
                };
            }
            #endregion

            if (ModelState.IsValid)
            {

                if (orderDetails.Id > 0)
                { 
                    var record  = _orderService.UpdateOrder(_mappingOrderDetailsFormModelToOrderDetails(orderDetails));
                    _summaryOfReceivedService.DeleteByOrderId(orderDetails.Id);
                    if (orderDetails.SummaryOfReceivedList.Count() > 0)
                    {
                        _summaryOfReceivedServiceInsert(orderDetails.SummaryOfReceivedList, record.Id);
                    }
                }
                else {
                    var record = _orderService.InsertOrder(_mappingOrderDetailsFormModelToOrderDetails(orderDetails));
                    if (orderDetails.SummaryOfReceivedList.Count() > 0)
                    {
                        _summaryOfReceivedServiceInsert(orderDetails.SummaryOfReceivedList, record.Id);
                    }
                }
                
                return RedirectToAction("Index");
            }
            return View(orderDetails);
        }

        #region Estimate
        [HttpPost]
        public IActionResult AddEstimate(OrderDetailsFormModel orderDetailsFormModel)
        {
            EstimateDetails estimateDetails = new EstimateDetails();

            estimateDetails.Description = orderDetailsFormModel.EstimateDetails.Description;
            estimateDetails.Amount = orderDetailsFormModel.EstimateDetails.Amount;
            estimateDetails.SerialNo = orderDetailsFormModel.EstimateDetails.SerialNo;
            estimateDetails.ItemAddDate = DateTime.Now;
            estimateDetails.OrderDetailId = orderDetailsFormModel.EstimateDetails.OrderDetailId;
            _estimateDetailService.Insert(estimateDetails);

            return RedirectToAction("Repair",new { id = estimateDetails.OrderDetailId });
        }

        [HttpPost]
        public IActionResult DeleteEstimate(long estimateId)
        {
            _estimateDetailService.DeleteById(estimateId);
            return RedirectToAction("Index");
        }
        #endregion
    }
}

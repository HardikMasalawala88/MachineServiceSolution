using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using ModuleServicePOS.Data;
using ModuleServicePOS.Data.FormModel;
using ModuleServicePOS.Data.ModelClasses;
using ModuleServicePOS.Repository.Constant;
using ModuleServicePOS.Service;
using Newtonsoft.Json;
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
        private readonly IEstimateDetailService _estimateDetailService;
        private readonly ISummaryOfReceivedMasterService _summaryOfReceivedMasterService;
        private readonly ISummaryOfReceivedOrderDetailService _summaryOfReceivedOrderDetailService;
        private IConfiguration _config;
        private ApplicationContext _context;
        public AdminController(ILogger<AdminController> logger, IOrderService orderService, IEstimateDetailService estimateDetailService, ISummaryOfReceivedMasterService summaryOfReceivedMasterService, ISummaryOfReceivedOrderDetailService summaryOfReceivedOrderDetailService, ApplicationContext context, IConfiguration config)
        {
            _logger = logger;
            _orderService = orderService;
            _estimateDetailService = estimateDetailService;
            _summaryOfReceivedMasterService = summaryOfReceivedMasterService;
            _summaryOfReceivedOrderDetailService = summaryOfReceivedOrderDetailService;
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
            EstimateDetailsFormModel _mappingEstimateDetailsToEstimateDetailsFormModel(EstimateDetail estimateDetails)
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
            IEnumerable<SummaryOfReceivedOrderDetailFromModel> _mappigSummaryOfReceivedOrderDetailFromModels(List<SummaryOfReceivedOrderDetail> toList) {

                List<SummaryOfReceivedOrderDetailFromModel> summaryOfReceivedOrderDetailFromModels = new List<SummaryOfReceivedOrderDetailFromModel>();
                
                foreach(var item in toList)
                {
                    summaryOfReceivedOrderDetailFromModels.Add(
                             new SummaryOfReceivedOrderDetailFromModel
                             {
                                 CompanyName = item.CompanyName,
                                 ModelNumber = item.ModelNumber,
                                 OrderDetailId = item.OrderDetailId,
                                 SerialNumber = item.SerialNumber,
                                 SummaryOfReceivedMasterId = item.SummaryOfReceivedMasterId
                             });
                }
                return summaryOfReceivedOrderDetailFromModels;
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
                    OrderStatus = orderDetailItem.OrderStatus,
                    SystemType = (SystemType)Enum.Parse(typeof(SystemType),orderDetailItem.SystemType),
                    TechnicianNote = orderDetailItem.TechnicianNote,
                    SystemPassword = orderDetailItem.SystemPassword,
                    ProductStatusList = orderDetailItem.ProductStatus.Split(","),
                    IsClosed = orderDetailItem.IsClosed,
                    Id = orderDetailItem.Id
                };
                orderDetails.EstimateDetailsList = _estimateDetailService.GetAllByOrderId(id).Where(x => x.IsDelete != true).ToList().Select(item => _mappingEstimateDetailsToEstimateDetailsFormModel(item));
                orderDetails.SummaryOfReceivedOrderDetails = _mappigSummaryOfReceivedOrderDetailFromModels(_summaryOfReceivedOrderDetailService.GetAllByOrderId(id).ToList());
                orderDetails.SummaryOfReceivedOrderDetailsJSON = JsonConvert.SerializeObject(orderDetails.SummaryOfReceivedOrderDetails, Formatting.Indented, new JsonSerializerSettings { PreserveReferencesHandling = PreserveReferencesHandling.Objects });
            }
            else {
                orderDetails.PreparedBy = HttpContext.Session.GetString(Constants.UName);
                orderDetails.SerialNo = DateTime.UtcNow.ToString("yyyyMMdd-HHmmss");
            }
            var SummaryData = _summaryOfReceivedMasterService.GetAll();
            orderDetails.SummaryDetailsList = SummaryData.ToList();
            return View(orderDetails);
        }

        [HttpPost]
        public IActionResult Repair(OrderDetailsFormModel orderDetails)
        {

            #region INTERNAL FUNCTION
            void _summaryOfReceivedOrderInsert(IEnumerable<SummaryOfReceivedOrderDetail> summaryOfReceivedList, long orderDetailId)
            {
                foreach (var item in summaryOfReceivedList)
                {
                    _summaryOfReceivedOrderDetailService.Insert(new SummaryOfReceivedOrderDetail
                    {
                        OrderDetailId = orderDetailId,
                        SummaryOfReceivedMasterId = item.SummaryOfReceivedMasterId,
                        CompanyName = item.CompanyName,
                        ModelNumber = item.ModelNumber,
                        SerialNumber = item.SerialNumber,
                        CreatedDate = DateTime.Now,
                    });
                }
            }

            OrderDetail _mappingOrderDetailsFormModelToOrderDetails(OrderDetailsFormModel orderDetailsFormModel) {
                return new OrderDetail
                {
                    Id = orderDetailsFormModel.Id,
                    Model = orderDetailsFormModel.Model,
                    Address = orderDetailsFormModel.Address,
                    SystemType = orderDetailsFormModel.SystemType.ToString(),
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
                    SystemPassword = orderDetailsFormModel.SystemPassword,
                    ProductStatus = String.Join(",", orderDetailsFormModel.ProductStatusList),
                };
            }
            #endregion
            if (ModelState.IsValid)
            {
                List<SummaryOfReceivedOrderDetail> data = new List<SummaryOfReceivedOrderDetail>();
                data = JsonConvert.DeserializeObject<List<SummaryOfReceivedOrderDetail>>(orderDetails.SummaryOfReceivedOrderDetailsJSON);
                
                if (orderDetails.Id > 0)
                {
                    data.ForEach(x => {
                        x.OrderDetailId = orderDetails.Id;
                    });
                    var record  = _orderService.UpdateOrder(_mappingOrderDetailsFormModelToOrderDetails(orderDetails));
                    if (orderDetails.SummaryOfReceivedOrderDetailsJSON.Count() > 0)
                    {
                        _summaryOfReceivedOrderDetailService.DeleteByOrderId(orderDetails.Id);
                        _summaryOfReceivedOrderInsert(data, record.Id);
                    }
                }
                else {
                    var record = _orderService.InsertOrder(_mappingOrderDetailsFormModelToOrderDetails(orderDetails));
                    if (orderDetails.SummaryOfReceivedList.Count() > 0)
                    {
                        _summaryOfReceivedOrderInsert(data, record.Id);
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
            EstimateDetail estimateDetails = new EstimateDetail();
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

        #region Summary of received Master
        public IActionResult SummaryOfReceivedList()
        {
            return View(_summaryOfReceivedMasterService.GetAll());
        } 

        [HttpGet]
        public IActionResult AddSummaryOfReceived(long id)
        {
            SummaryOfReceivedMasterFormModel summaryOfReceivedMaster = new SummaryOfReceivedMasterFormModel();
            if (id > 0)
            {
                var summaryOfReceivedItem = _summaryOfReceivedMasterService.Get(id);
                summaryOfReceivedMaster = new SummaryOfReceivedMasterFormModel
                {
                    ItemName = summaryOfReceivedItem.ItemName,
                    Id = summaryOfReceivedItem.Id
                };
            }
            else
            {
                summaryOfReceivedMaster.CreatedBy = HttpContext.Session.GetString(Constants.UName);
            }
            return View(summaryOfReceivedMaster);
        }

        [HttpPost]
        public IActionResult AddSummaryOfReceived(SummaryOfReceivedMasterFormModel receivedMasterFormModel)
        {
            if (ModelState.IsValid)
            {
                SummaryOfReceivedMaster summaryOfReceivedMaster = new SummaryOfReceivedMaster();
                if (receivedMasterFormModel.Id > 0)
                {
                    var SummaryList = _summaryOfReceivedMasterService.Get(receivedMasterFormModel.Id);
                    SummaryList.ItemName = receivedMasterFormModel.ItemName;
                    SummaryList.ModifiedDate = DateTime.Now;
                    SummaryList.ModifiedBy = HttpContext.Session.GetString(Constants.UName);
                    _summaryOfReceivedMasterService.Update(SummaryList);
                }
                else
                {
                    summaryOfReceivedMaster.ItemName = receivedMasterFormModel.ItemName;
                    summaryOfReceivedMaster.CreatedDate = DateTime.Now;
                    summaryOfReceivedMaster.CreatedBy = HttpContext.Session.GetString(Constants.UName);
                    _summaryOfReceivedMasterService.Insert(summaryOfReceivedMaster);
                }
            }
            return RedirectToAction("SummaryOfReceivedList");
        }

        [HttpPost]
        public IActionResult RemoveSummaryOfReceived(long summaryId)
        {
            _summaryOfReceivedMasterService.DeleteById(summaryId);
            return RedirectToAction("SummaryOfReceivedList");
        }
        #endregion
    }
}

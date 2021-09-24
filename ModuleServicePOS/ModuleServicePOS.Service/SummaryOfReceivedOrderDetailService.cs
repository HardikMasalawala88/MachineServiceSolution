using ModuleServicePOS.Data.ModelClasses;
using ModuleServicePOS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleServicePOS.Service
{
    public class SummaryOfReceivedOrderDetailService : ISummaryOfReceivedOrderDetailService
    {
        private readonly IRepository<SummaryOfReceivedOrderDetail> _summaryOfReceivedOrderDetailRepository;

        public SummaryOfReceivedOrderDetailService(IRepository<SummaryOfReceivedOrderDetail> summaryOfReceivedOrderDetailRepository)
        {
            _summaryOfReceivedOrderDetailRepository = summaryOfReceivedOrderDetailRepository;
        }
        public void DeleteById(long id)
        {
            SummaryOfReceivedOrderDetail summaryOfReceivedOrderDetail = Get(id);
            _summaryOfReceivedOrderDetailRepository.Remove(summaryOfReceivedOrderDetail);
            _summaryOfReceivedOrderDetailRepository.SaveChanges();
        }

        public void DeleteByOrderId(long id)
        {
            //foreach (var item in GetAllByOrderId(orderId).ToList().Select((value, i) => (value, i)))
            //{
            //    _summaryOfReceivedOrderDetailRepository.Remove(_summaryOfReceivedOrderDetailRepository.Get(item.value.Id));
            //    _summaryOfReceivedOrderDetailRepository.SaveChanges();
            //}
        }

        public SummaryOfReceivedOrderDetail Get(long id)
        {
            return _summaryOfReceivedOrderDetailRepository.Get(id);
        }

        public IEnumerable<SummaryOfReceivedOrderDetail> GetAll()
        {
            return _summaryOfReceivedOrderDetailRepository.GetAll();
        }

        public IEnumerable<SummaryOfReceivedOrderDetail> GetAllByOrderId(long orderId)
        {
            return _summaryOfReceivedOrderDetailRepository.GetAll().Where(x => x.OrderDetailId == orderId);
        }

        public SummaryOfReceivedOrderDetail Insert(SummaryOfReceivedOrderDetail summaryOfReceivedOrderDetail)
        {
            summaryOfReceivedOrderDetail.CreatedDate = DateTime.UtcNow;
            _summaryOfReceivedOrderDetailRepository.Insert(summaryOfReceivedOrderDetail);
            return summaryOfReceivedOrderDetail;
        }

        public SummaryOfReceivedOrderDetail Update(SummaryOfReceivedOrderDetail summaryOfReceivedOrderDetail)
        {
            _summaryOfReceivedOrderDetailRepository.Update(summaryOfReceivedOrderDetail);
            return summaryOfReceivedOrderDetail;
        }
    }
}

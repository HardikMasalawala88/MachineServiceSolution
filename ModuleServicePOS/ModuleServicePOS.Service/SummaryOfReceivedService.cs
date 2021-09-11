using ModuleServicePOS.Data.ModelClasses;
using ModuleServicePOS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleServicePOS.Service
{
    public class SummaryOfReceivedService : ISummaryOfReceivedService
    {
        private readonly IRepository<SummaryOfReceived> _summaryOfReceivedRepository;

        public SummaryOfReceivedService(IRepository<SummaryOfReceived> summaryOfReceivedRepository)
        {
            _summaryOfReceivedRepository = summaryOfReceivedRepository;
        }
        public void DeleteById(long id)
        {
            SummaryOfReceived summaryOfReceived = Get(id);
            _summaryOfReceivedRepository.Remove(summaryOfReceived);
            _summaryOfReceivedRepository.SaveChanges();
        }

        public void DeleteByOrderId(long orderId)
        {
            foreach (var item in GetAllByOrderId(orderId).ToList().Select((value, i) => (value, i)))
            {
                _summaryOfReceivedRepository.Remove(_summaryOfReceivedRepository.Get(item.value.Id));
                _summaryOfReceivedRepository.SaveChanges();
            }
        }

        public SummaryOfReceived Get(long id)
        {
            return _summaryOfReceivedRepository.Get(id);
        }

        public IEnumerable<SummaryOfReceived> GetAll()
        {
            return _summaryOfReceivedRepository.GetAll();
        }

        public IEnumerable<SummaryOfReceived> GetAllByOrderId(long orderId)
        {
            return _summaryOfReceivedRepository.GetAll().Where(x => x.OrderDetailId == orderId);
        }

        public SummaryOfReceived Insert(SummaryOfReceived summaryOfReceived)
        {
            summaryOfReceived.CreatedDate = DateTime.UtcNow;
            _summaryOfReceivedRepository.Insert(summaryOfReceived);
            return summaryOfReceived;
        }

        public SummaryOfReceived Update(SummaryOfReceived summaryOfReceived)
        {
            _summaryOfReceivedRepository.Update(summaryOfReceived);
            return summaryOfReceived;
        }
    }
}

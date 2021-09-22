using ModuleServicePOS.Data.ModelClasses;
using ModuleServicePOS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleServicePOS.Service
{
    public class SummaryOfReceivedMasterService : ISummaryOfReceivedMasterService
    {
        private readonly IRepository<SummaryOfReceivedMaster>  _summaryOfReceivedMasterRepository;

        public SummaryOfReceivedMasterService(IRepository<SummaryOfReceivedMaster> summaryOfReceivedMasterRepository)
        {
            _summaryOfReceivedMasterRepository = summaryOfReceivedMasterRepository;
        }
        public void DeleteById(long id)
        {
            SummaryOfReceivedMaster summaryOfReceivedMaster = Get(id);
            _summaryOfReceivedMasterRepository.Remove(summaryOfReceivedMaster);
            _summaryOfReceivedMasterRepository.SaveChanges();
        }

        //public void DeleteByOrderId(long id)
        //{
        //    throw new NotImplementedException();
        //}

        public SummaryOfReceivedMaster Get(long id)
        {
            return _summaryOfReceivedMasterRepository.Get(id);
        }

        public IEnumerable<SummaryOfReceivedMaster> GetAll()
        {
            return _summaryOfReceivedMasterRepository.GetAll();
        }

        /*public IEnumerable<SummaryOfReceivedMaster> GetAllByOrderId(long orderId)
        {
            throw new NotImplementedException();
        }*/

        public SummaryOfReceivedMaster Insert(SummaryOfReceivedMaster summaryOfReceived)
        {
            summaryOfReceived.CreatedDate = DateTime.UtcNow;
            _summaryOfReceivedMasterRepository.Insert(summaryOfReceived);
            return summaryOfReceived;
        }

        public SummaryOfReceivedMaster Update(SummaryOfReceivedMaster summaryOfReceived)
        {
            _summaryOfReceivedMasterRepository.Update(summaryOfReceived);
            return summaryOfReceived;
        }
    }
}

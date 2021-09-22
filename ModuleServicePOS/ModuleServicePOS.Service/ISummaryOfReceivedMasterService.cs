using ModuleServicePOS.Data.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleServicePOS.Service
{
    public interface ISummaryOfReceivedMasterService
    {
        IEnumerable<SummaryOfReceivedMaster> GetAll();
        //IEnumerable<SummaryOfReceivedMaster> GetAllByOrderId(long orderId);
        SummaryOfReceivedMaster Get(long id);
        SummaryOfReceivedMaster Insert(SummaryOfReceivedMaster summaryOfReceived);
        SummaryOfReceivedMaster Update(SummaryOfReceivedMaster summaryOfReceived);
        void DeleteById(long id);
        //void DeleteByOrderId(long id);
    }
}

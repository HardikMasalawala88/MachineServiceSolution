using ModuleServicePOS.Data.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleServicePOS.Service
{
    public interface ISummaryOfReceivedService
    {
        IEnumerable<SummaryOfReceived> GetAll();
        IEnumerable<SummaryOfReceived> GetAllByOrderId(long orderId);
        SummaryOfReceived Get(long id);
        SummaryOfReceived Insert(SummaryOfReceived orderDetails);
        SummaryOfReceived Update(SummaryOfReceived orderDetails);
        void DeleteById(long id);
        void DeleteByOrderId(long id);
    }
}

using ModuleServicePOS.Data.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleServicePOS.Service
{
    public interface ISummaryOfReceivedOrderDetailService
    {
        IEnumerable<SummaryOfReceivedOrderDetail> GetAll();
        IEnumerable<SummaryOfReceivedOrderDetail> GetAllByOrderId(long orderId);
        SummaryOfReceivedOrderDetail Get(long id);
        SummaryOfReceivedOrderDetail Insert(SummaryOfReceivedOrderDetail summaryOfReceivedOrderDetail);
        SummaryOfReceivedOrderDetail Update(SummaryOfReceivedOrderDetail summaryOfReceivedOrderDetail);
        void DeleteById(long id);
        void DeleteByOrderId(long id);
    }
}

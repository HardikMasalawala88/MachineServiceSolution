using ModuleServicePOS.Data.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleServicePOS.Service
{
    public interface IEstimateDetailService
    {
        IEnumerable<EstimateDetails> GetAll();
        IEnumerable<EstimateDetails> GetAllByOrderId(long orderId);
        EstimateDetails Get(long id);
        EstimateDetails Insert(EstimateDetails estimateDetails);
        EstimateDetails Update(EstimateDetails estimateDetails);
        void DeleteById(long id);
        void DeleteByOrderId(long id);
    }
}

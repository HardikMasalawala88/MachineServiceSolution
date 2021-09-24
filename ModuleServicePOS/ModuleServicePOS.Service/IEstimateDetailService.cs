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
        IEnumerable<EstimateDetail> GetAll();
        IEnumerable<EstimateDetail> GetAllByOrderId(long orderId);
        EstimateDetail Get(long id);
        EstimateDetail Insert(EstimateDetail estimateDetails);
        EstimateDetail Update(EstimateDetail estimateDetails);
        void DeleteById(long id);
        void DeleteByOrderId(long id);
    }
}

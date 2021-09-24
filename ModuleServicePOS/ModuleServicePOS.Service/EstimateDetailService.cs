using ModuleServicePOS.Data.ModelClasses;
using ModuleServicePOS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleServicePOS.Service
{
    public class EstimateDetailService : IEstimateDetailService
    {
        private readonly IRepository<EstimateDetail>  _estimateDetailsRepository;

        public EstimateDetailService(IRepository<EstimateDetail> estimateDetailsRepository)
        {
            _estimateDetailsRepository = estimateDetailsRepository;
        }
        public void DeleteById(long id)
        {
            EstimateDetail estimateDetails = Get(id);
            _estimateDetailsRepository.Remove(estimateDetails);
            _estimateDetailsRepository.SaveChanges();
        }

        public void DeleteByOrderId(long orderId)
        {
            foreach (var item in GetAllByOrderId(orderId).ToList().Select((value, i) => (value, i)))
            {
                _estimateDetailsRepository.Remove(_estimateDetailsRepository.Get(item.value.Id));
                _estimateDetailsRepository.SaveChanges();
            }
        }

        public EstimateDetail Get(long id)
        {
            return _estimateDetailsRepository.Get(id);
        }

        public IEnumerable<EstimateDetail> GetAll()
        {
            return _estimateDetailsRepository.GetAll();
        }

        public IEnumerable<EstimateDetail> GetAllByOrderId(long orderId)
        {
            return _estimateDetailsRepository.GetAll().Where(x => x.OrderDetailId == orderId);
        }

        public EstimateDetail Insert(EstimateDetail estimateDetails)
        {
            estimateDetails.CreatedDate = DateTime.UtcNow;
            _estimateDetailsRepository.Insert(estimateDetails);
            return estimateDetails;
        }

        public EstimateDetail Update(EstimateDetail estimateDetails)
        {
            _estimateDetailsRepository.Update(estimateDetails);
            return estimateDetails;
        }
    }
}

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
        private readonly IRepository<EstimateDetails>  _estimateDetailsRepository;

        public EstimateDetailService(IRepository<EstimateDetails> estimateDetailsRepository)
        {
            _estimateDetailsRepository = estimateDetailsRepository;
        }
        public void DeleteById(long id)
        {
            EstimateDetails estimateDetails = Get(id);
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

        public EstimateDetails Get(long id)
        {
            return _estimateDetailsRepository.Get(id);
        }

        public IEnumerable<EstimateDetails> GetAll()
        {
            return _estimateDetailsRepository.GetAll();
        }

        public IEnumerable<EstimateDetails> GetAllByOrderId(long orderId)
        {
            return _estimateDetailsRepository.GetAll().Where(x => x.OrderDetailId == orderId);
        }

        public EstimateDetails Insert(EstimateDetails estimateDetails)
        {
            estimateDetails.CreatedDate = DateTime.UtcNow;
            _estimateDetailsRepository.Insert(estimateDetails);
            return estimateDetails;
        }

        public EstimateDetails Update(EstimateDetails estimateDetails)
        {
            _estimateDetailsRepository.Update(estimateDetails);
            return estimateDetails;
        }
    }
}

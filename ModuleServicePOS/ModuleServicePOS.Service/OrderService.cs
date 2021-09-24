using ModuleServicePOS.Data.ModelClasses;
using ModuleServicePOS.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleServicePOS.Service
{
    public class OrderService : IOrderService
    {
        private IRepository<OrderDetail> _orderRepository;

        public OrderService(IRepository<OrderDetail> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public void DeleteOrder(long id)
        {
            OrderDetail orderDetails = GetOrder(id);
            _orderRepository.Remove(orderDetails);
            _orderRepository.SaveChanges();
        }

        public OrderDetail GetOrder(long id)
        {
            return _orderRepository.Get(id);
        }

        public IEnumerable<OrderDetail> GetOrders()
        {
            return _orderRepository.GetAll();
        }

        public OrderDetail InsertOrder(OrderDetail orderDetails)
        {
            orderDetails.CreatedDate = DateTime.UtcNow;
            _orderRepository.Insert(orderDetails);
            return orderDetails;
        }

        public OrderDetail UpdateOrder(OrderDetail orderDetails)
        {
            orderDetails.ModifiedDate = DateTime.UtcNow;
            _orderRepository.Update(orderDetails);
            return orderDetails;
        }
    }
}

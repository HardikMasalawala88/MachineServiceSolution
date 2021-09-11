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
        private IRepository<OrderDetails> _orderRepository;

        public OrderService(IRepository<OrderDetails> orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public void DeleteOrder(long id)
        {
            OrderDetails orderDetails = GetOrder(id);
            _orderRepository.Remove(orderDetails);
            _orderRepository.SaveChanges();
        }

        public OrderDetails GetOrder(long id)
        {
            return _orderRepository.Get(id);
        }

        public IEnumerable<OrderDetails> GetOrders()
        {
            return _orderRepository.GetAll();
        }

        public OrderDetails InsertOrder(OrderDetails orderDetails)
        {
            orderDetails.CreatedDate = DateTime.UtcNow;
            _orderRepository.Insert(orderDetails);
            return orderDetails;
        }

        public OrderDetails UpdateOrder(OrderDetails orderDetails)
        {
            orderDetails.ModifiedDate = DateTime.UtcNow;
            _orderRepository.Update(orderDetails);
            return orderDetails;
        }
    }
}

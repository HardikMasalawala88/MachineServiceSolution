using ModuleServicePOS.Data.ModelClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuleServicePOS.Service
{
    public interface IOrderService
    {
        IEnumerable<OrderDetails> GetOrders();
        OrderDetails GetOrder(long id);
        OrderDetails InsertOrder(OrderDetails orderDetails);
        OrderDetails UpdateOrder(OrderDetails orderDetails);
        void DeleteOrder(long id);
    }
}

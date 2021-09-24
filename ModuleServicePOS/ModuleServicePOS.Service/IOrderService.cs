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
        IEnumerable<OrderDetail> GetOrders();
        OrderDetail GetOrder(long id);
        OrderDetail InsertOrder(OrderDetail orderDetails);
        OrderDetail UpdateOrder(OrderDetail orderDetails);
        void DeleteOrder(long id);
    }
}

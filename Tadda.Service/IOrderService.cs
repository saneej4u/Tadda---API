using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tadda.Model.Entities;

namespace Tadda.Service
{
    public interface IOrderService
    {
        Order GetSingleOrder(int orderId);
        IEnumerable<Order> GetAllOrderByUser(int endUserId);
        Order CreateOrder(Order order);

        OrderLine CreateOrderLine(OrderLine orderLine);
    }
}

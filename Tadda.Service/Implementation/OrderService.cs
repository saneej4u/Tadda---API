using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tadda.Data.Infrastructure;
using Tadda.Data.Repository;
using Tadda.Model.Entities;

namespace Tadda.Service.Implementation
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _IOrderRepository;
        private readonly IOrderLineRepository _IOrderLineRepository;
        private readonly IUnitOfWork _IUnitOfWork;
        public OrderService(IOrderRepository order, IOrderLineRepository odl, IUnitOfWork unitOfWork)
        {
            this._IOrderRepository = order;
            this._IOrderLineRepository = odl;
            this._IUnitOfWork = unitOfWork;
        }
        public Order CreateOrder(Order order)
        {
            _IOrderRepository.Add(order);

            var orderLines = order.OrderLines;

            if (orderLines != null && orderLines.Any())
            {
                foreach (var item in orderLines)
                {
                    _IOrderLineRepository.Add(item);
                }
            }

            _IUnitOfWork.Commit();

            return order;

        }
        public IEnumerable<Order> GetAllOrderByUser(int endUserId)
        {
            return _IOrderRepository.GetAllOrderAndLines(endUserId);
            //  return _IOrderRepository.GetAll().Where(x => x.EndUserID == endUserId);
        }
        public Order GetSingleOrder(int orderId)
        {
            return _IOrderRepository.GetById(orderId);
        }


        public OrderLine CreateOrderLine(OrderLine orderLine)
        {
            _IOrderLineRepository.Add(orderLine);
            _IUnitOfWork.Commit();
            return orderLine;
        }
    }
}

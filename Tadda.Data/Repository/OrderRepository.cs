using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tadda.Data.Infrastructure;
using Tadda.Model.Entities;
using System.Collections.Generic;
using System.Data.Entity;

namespace Tadda.Data.Repository
{
    class OrderRepository : RepositoryBase<Order>, IOrderRepository
    {
        public OrderRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }

        public IEnumerable<Order> GetAllOrderAndLines(int endUserId)
        {
            return DataContext.Orders.Where(x => x.EndUserID == endUserId).Include(o=> o.OrderLines);
        }
    }
    public interface IOrderRepository : IRepository<Order>
    {
       IEnumerable<Order> GetAllOrderAndLines(int endUserId);
    }
}

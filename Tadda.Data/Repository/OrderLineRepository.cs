using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tadda.Data.Infrastructure;
using Tadda.Model.Entities;

namespace Tadda.Data.Repository
{
    class OrderLineRepository : RepositoryBase<OrderLine>, IOrderLineRepository
    {
        public OrderLineRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    public interface IOrderLineRepository : IRepository<OrderLine>
    {

    }
}

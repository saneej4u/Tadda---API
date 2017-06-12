using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tadda.Data.Infrastructure;
using Tadda.Model.Entities;

namespace Tadda.Data.Repository
{
   public class AddressRepository : RepositoryBase<Address>, IAddressRepository
    {
        public AddressRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    public interface IAddressRepository : IRepository<Address>
    {

    }
}

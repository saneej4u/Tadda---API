using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tadda.Data.Infrastructure;
using Tadda.Model.Entities;

namespace Tadda.Data.Repository
{

    public class TempCompanyUserRepository : RepositoryBase<TempCompanyUser>, ITempCompanyUserRepository
    {
        public TempCompanyUserRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {
        }
    }
    public interface ITempCompanyUserRepository : IRepository<TempCompanyUser>
    {

    }
}

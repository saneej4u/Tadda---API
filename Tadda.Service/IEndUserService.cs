using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tadda.Model.Entities;

namespace Tadda.Service
{
    public interface IEndUserService
    {
        IEnumerable<EndUser> GetAll(int companyId);
        EndUser GetUser(string email);
        EndUser CreateEnduser(EndUser endUser);
        EndUser UpdateEnduser(EndUser enduser);
        void DeleteEnduser(int enduserId);

    }
}

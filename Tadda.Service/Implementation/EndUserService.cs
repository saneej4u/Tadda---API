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
    public class EndUserService : IEndUserService
    {
        private readonly IEndUserRepository _IEndUserRepository;
        private readonly IUnitOfWork _IUnitOfWork;
        public EndUserService(IEndUserRepository enduserRep, IUnitOfWork uow)
        {
            this._IEndUserRepository = enduserRep;
            this._IUnitOfWork = uow;
        }

        public EndUser CreateEnduser(EndUser endUser)
        {
            _IEndUserRepository.Add(endUser);
            _IUnitOfWork.Commit();

            return endUser;
        }

        public IEnumerable<EndUser> GetAll(int companyId)
        {
            return _IEndUserRepository.GetAll().Where(x => x.CompanyId == companyId);
        }
        public EndUser GetUser(string email)
        {
            if(!string.IsNullOrEmpty(email))
            {
                EndUser enduser =_IEndUserRepository.Get(x => x.EmailAddress == email);

                if(enduser !=null)
                {
                    return enduser;
                }
            }
            return null;
        }



        public void DeleteEnduser(int enduserId)
        {
            throw new NotImplementedException();
        }

        public EndUser UpdateEnduser(EndUser enduser)
        {
            _IEndUserRepository.Update(enduser);
            _IUnitOfWork.Commit();

            return enduser;
        }
    }
}

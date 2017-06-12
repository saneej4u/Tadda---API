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
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _CompanyRepository;
        private readonly IApplicationUserRepository _ApplicationUserRepository;
        private readonly ITempCompanyUserRepository _TempCompanyUserRepository;
        private readonly IUnitOfWork _UnitOfWork;

        public CompanyService(ICompanyRepository compRep,
            IApplicationUserRepository appuser,
            ITempCompanyUserRepository tempComprep,
            IUnitOfWork uow)
        {
            this._CompanyRepository = compRep;
            this._UnitOfWork = uow;
            this._ApplicationUserRepository = appuser;
            this._TempCompanyUserRepository = tempComprep;
        }
        public Company CreateCompany(Company company)
        {
            if (company.CompanyUniqueId == Guid.Empty)
            {
                company.CompanyUniqueId = Guid.NewGuid();
            }

            //TODO: Renewel and expire Logic depends on subcription choosen

            company.RenewedOn = DateTime.Now;
            company.ExpireOn = DateTime.Now.AddYears(1);

            _CompanyRepository.Add(company);
            _UnitOfWork.Commit();

            return company;
        }
        public Company GetCompanyById(int companyId)
        {
            return _CompanyRepository.GetById(companyId);
        }

        public Company GetCompanyByEmail(string companyemail)
        {
            var user = _ApplicationUserRepository.GetAll().Where(x => x.Email == companyemail).FirstOrDefault();
            if (user != null)
            {
                return GetCompanyById(user.CompanyId);
            }

            return null;
        }


        public ApplicationUser UpdateCompanyUser(ApplicationUser companyUser)
        {
            _ApplicationUserRepository.Update(companyUser);
            _UnitOfWork.Commit();

            return companyUser;
        }
        public TempCompanyUser CreateTempCompanyUser(TempCompanyUser tempuser)
        {
            _TempCompanyUserRepository.Add(tempuser);
            _UnitOfWork.Commit();
            return tempuser;
        }
        public TempCompanyUser GetTempUser(string tempEmail)
        {
            return _TempCompanyUserRepository.Get(x => x.Email == tempEmail);
        }
        public void DeleteCompanyUser(string userid)
        {

        }
    }
}

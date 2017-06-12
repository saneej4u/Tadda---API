using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tadda.Model.Entities;

namespace Tadda.Service
{
    public interface ICompanyService
    {
        Company GetCompanyById(int companyId);
        Company GetCompanyByEmail(string companyemail);
        Company CreateCompany(Company company);
        ApplicationUser UpdateCompanyUser(ApplicationUser user);
        void DeleteCompanyUser(string userid);
        TempCompanyUser GetTempUser(string tempEmail);
        TempCompanyUser CreateTempCompanyUser(TempCompanyUser tempuser);
    }
}

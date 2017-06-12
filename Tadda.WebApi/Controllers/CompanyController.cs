using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Tadda.Service;

namespace Tadda.WebApi.Controllers
{
    [RoutePrefix("api/tadda/company")]
    [Authorize]
    public class CompanyController : BaseApiController
    {

        private ICompanyService _CompanyService;

        public CompanyController(ICompanyService compServ)
        {
            this._CompanyService = compServ;
        }

        [Route("{companyId}")]
        [HttpGet]
        public IHttpActionResult GetCompany(int companyId)
        {
            try
            {
                var company = _CompanyService.GetCompanyById(companyId);

                if (company != null)
                {
                    return Ok(company);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }


        [Route("email/{companyemail}")]
        [HttpGet]
        public IHttpActionResult GetCompanyByEmail(string companyemail)
        {
            try
            {
                if (string.IsNullOrEmpty(companyemail)) { return BadRequest(); }

                var company = _CompanyService.GetCompanyByEmail(companyemail);

                if (company != null)
                {
                    return Ok(company);
                }
                else
                {
                    return NotFound();
                }
            }
            catch (Exception)
            {
                return InternalServerError();
            }
        }

    }
}

using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.ModelBinding;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Owin.Security.OAuth;
using Tadda.WebApi.Models;
using Tadda.WebApi.Providers;
using Tadda.WebApi.Results;
using Tadda.Model.Entities;
using Tadda.Data.Infrastructure;
using Tadda.Service;
using System.Web.Http.Cors;

namespace Tadda.WebApi.Controllers
{

   // [EnableCors(origins: "*", headers: "*", methods: "*")]
    [RoutePrefix("api/tadda/account")]
    public class AccountController : BaseApiController
    {
        private const string LocalLoginProvider = "Local";
        private ApplicationUserManager _userManager;

        private ICompanyService _CompanyService;

        public AccountController(){}
        public AccountController(ICompanyService compService)
        {
            this._CompanyService = compService;
        }

        public ISecureDataFormat<AuthenticationTicket> AccessTokenFormat { get; private set; }

        // POST api/tadda/registercompany
        [AllowAnonymous]
        [Route("registercompany")]
        public async Task<IHttpActionResult> Register(RegisterBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var companyUser = new ApplicationUser()
            {
                UserName = model.Email,
                Email = model.Email,
                FirstName = model.FirstName,
                LastName = model.LastName
            };

            IdentityResult result = await UserManager.CreateAsync(companyUser, model.Password);

            if (!result.Succeeded)
            {
                return GetErrorResult(result);
            }
            else
            {
                IdentityResult addResult = await UserManager.AddToRoleAsync(companyUser.Id, "CompanySuperAdmin");

                //Create a new company
                var company = new Company
                {
                    Name = model.CompanyName,
                    SubscriptionId = model.SubscriptionId
                };

                var newCompany = _CompanyService.CreateCompany(company);

                if (newCompany != null)
                {
                    companyUser.CompanyUniqueId = newCompany.CompanyUniqueId;
                    companyUser.CompanyId = newCompany.CompanyId;
                    _CompanyService.UpdateCompanyUser(companyUser);
                }
            }

            return Ok(companyUser);
        }

        [AllowAnonymous]
        [Route("registercompanyadmin")]
        public async Task<IHttpActionResult> RegisterCompanyAdmin(RegisterBindingModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var tempCompanyUser = _CompanyService.GetTempUser(model.Email);

            if (tempCompanyUser != null)
            {
                var companyUser = new ApplicationUser()
                {
                    UserName = model.Email,
                    Email = model.Email,
                    FirstName = model.FirstName,
                    LastName = model.LastName
                };

                IdentityResult result = await UserManager.CreateAsync(companyUser, model.Password);

                if (!result.Succeeded)
                {
                    return GetErrorResult(result);
                }
                else
                {
                    IdentityResult addResult = await UserManager.AddToRoleAsync(companyUser.Id, "CompanyAdmin");

                    companyUser.CompanyUniqueId = tempCompanyUser.CompanyUniqueId;
                    companyUser.CompanyId = tempCompanyUser.CompanyId;
                    _CompanyService.UpdateCompanyUser(companyUser);

                }
            }
            else
            {
                return NotFound();
            }

            return Ok();
        }

   
        protected override void Dispose(bool disposing)
        {
            if (disposing && _userManager != null)
            {
                _userManager.Dispose();
                _userManager = null;
            }

            base.Dispose(disposing);
        }

        #region Helpers

        // POST api/Account/Logout
        [Route("Logout")]
        public IHttpActionResult Logout()
        {
            Authentication.SignOut(CookieAuthenticationDefaults.AuthenticationType);
            return Ok();
        }

        private IAuthenticationManager Authentication
        {
            get { return Request.GetOwinContext().Authentication; }
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }

        private class ExternalLoginData
        {
            public string LoginProvider { get; set; }
            public string ProviderKey { get; set; }
            public string UserName { get; set; }

            public IList<Claim> GetClaims()
            {
                IList<Claim> claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, ProviderKey, null, LoginProvider));

                if (UserName != null)
                {
                    claims.Add(new Claim(ClaimTypes.Name, UserName, null, LoginProvider));
                }

                return claims;
            }

            public static ExternalLoginData FromIdentity(ClaimsIdentity identity)
            {
                if (identity == null)
                {
                    return null;
                }

                Claim providerKeyClaim = identity.FindFirst(ClaimTypes.NameIdentifier);

                if (providerKeyClaim == null || String.IsNullOrEmpty(providerKeyClaim.Issuer)
                    || String.IsNullOrEmpty(providerKeyClaim.Value))
                {
                    return null;
                }

                if (providerKeyClaim.Issuer == ClaimsIdentity.DefaultIssuer)
                {
                    return null;
                }

                return new ExternalLoginData
                {
                    LoginProvider = providerKeyClaim.Issuer,
                    ProviderKey = providerKeyClaim.Value,
                    UserName = identity.FindFirstValue(ClaimTypes.Name)
                };
            }
        }

        private static class RandomOAuthStateGenerator
        {
            private static RandomNumberGenerator _random = new RNGCryptoServiceProvider();

            public static string Generate(int strengthInBits)
            {
                const int bitsPerByte = 8;

                if (strengthInBits % bitsPerByte != 0)
                {
                    throw new ArgumentException("strengthInBits must be evenly divisible by 8.", "strengthInBits");
                }

                int strengthInBytes = strengthInBits / bitsPerByte;

                byte[] data = new byte[strengthInBytes];
                _random.GetBytes(data);
                return HttpServerUtility.UrlTokenEncode(data);
            }
        }

        #endregion
    }
}

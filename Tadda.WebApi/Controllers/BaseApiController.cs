using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Tadda.Data.Infrastructure;
using Tadda.Model.Entities;

namespace Tadda.WebApi.Controllers
{
    public class BaseApiController : ApiController
    {

        public BaseApiController()
        {

        }

        public ApplicationUserManager UserManager
        {
            get { return HttpContext.Current.GetOwinContext().GetUserManager<ApplicationUserManager>(); }
        }

        public async Task<string> UserIdentityId()
        {
            // Git test
            var user = await UserManager.FindByNameAsync(User.Identity.Name);
            return user.Id;
        }

        public async Task<ApplicationUser> UserRecord()
        {
            return await UserManager.FindByEmailAsync(Thread.CurrentPrincipal.Identity.Name);
        }

    }
}

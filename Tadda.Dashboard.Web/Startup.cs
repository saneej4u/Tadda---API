using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Tadda.Dashboard.Web.Startup))]
namespace Tadda.Dashboard.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

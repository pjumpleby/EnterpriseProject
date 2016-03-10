using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(EnterpriseProject.WebApplication.Startup))]
namespace EnterpriseProject.WebApplication
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

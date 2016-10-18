using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CISK.CDProject.Startup))]
namespace CISK.CDProject
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

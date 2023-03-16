using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ERP_Automation_Test.Startup))]
namespace ERP_Automation_Test
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

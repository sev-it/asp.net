using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(ngNetMVC.Startup))]
namespace ngNetMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(WbApp.Startup))]
namespace WbApp
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

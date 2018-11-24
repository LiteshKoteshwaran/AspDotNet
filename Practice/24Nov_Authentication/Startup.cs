using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_24Nov_Authentication.Startup))]
namespace _24Nov_Authentication
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

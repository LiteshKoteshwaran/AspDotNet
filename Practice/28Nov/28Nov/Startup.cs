using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(_26Nov.Startup))]
namespace _26Nov
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

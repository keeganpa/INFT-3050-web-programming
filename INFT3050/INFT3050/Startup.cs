using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(INFT3050.Startup))]
namespace INFT3050
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

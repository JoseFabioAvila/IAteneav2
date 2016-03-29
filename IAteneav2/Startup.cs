using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(IAteneav2.Startup))]
namespace IAteneav2
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}

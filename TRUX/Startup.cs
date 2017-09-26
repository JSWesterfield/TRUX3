using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TRUX.Startup))]
namespace TRUX
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

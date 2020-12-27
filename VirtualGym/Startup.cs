using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(VirtualGym.Startup))]
namespace VirtualGym
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

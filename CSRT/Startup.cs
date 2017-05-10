using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CSRT.Startup))]
namespace CSRT
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CNPC.SISDUC.WEB.Startup))]
namespace CNPC.SISDUC.WEB
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

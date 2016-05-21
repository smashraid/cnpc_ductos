using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CNPC.SISDUC.Presentacion.Startup))]
namespace CNPC.SISDUC.Presentacion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

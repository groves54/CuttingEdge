using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CuttingEdge.Startup))]
namespace CuttingEdge
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

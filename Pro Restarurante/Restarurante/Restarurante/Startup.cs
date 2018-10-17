using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Restarurante.Startup))]
namespace Restarurante
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

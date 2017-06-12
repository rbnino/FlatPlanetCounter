using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(FlatPlanetCounter.Startup))]
namespace FlatPlanetCounter
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}

using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Socializer.Startup))]
namespace Socializer
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
        }
    }
}

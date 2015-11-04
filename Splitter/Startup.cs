using Microsoft.Owin;
using Microsoft.Owin.Cors;
using Owin;
using Splitter.App_Start;

[assembly: OwinStartup(typeof(Startup))]
namespace Splitter.App_Start
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCors(CorsOptions.AllowAll);
            ConfigureAuth(app);
        }
    }
}

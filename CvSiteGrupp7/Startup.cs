using Data.Contexts;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(CvSiteGrupp7.Startup))]
namespace CvSiteGrupp7
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            app.CreatePerOwinContext(() => new MessageDbContext());
        }
    }
}

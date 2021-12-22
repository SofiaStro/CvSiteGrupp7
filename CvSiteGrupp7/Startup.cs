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

            /*
           * För Controllers (vanliga): behöver ha NuGet för Microsoft.Owin.Host.SystemWeb (installeras med template för Identity) för att kunna hämta via HttpContext.GetOwinContext()
           * För ApiControllers: behöver ha NuGet för Microsoft.AspNet.WebApi.Owin för att kunna hämta via Request.GetOwinContext()
           * För att hämta contextet via Get metoden så behöver man använda namespacet: Microsoft.AspNet.Identity.Owin ex. GetOwinContext().Get<BookContext>()
           */
            app.CreatePerOwinContext(() => new MessageDbContext());
        }
    }
}

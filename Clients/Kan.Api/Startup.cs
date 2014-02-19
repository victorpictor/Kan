using System.Web.Http;
using System.Web.Http.Filters;
using Kan.Api.Response;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartup(typeof(Kan.Api.Startup))]
namespace Kan.Api
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var config = new HttpConfiguration();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Filters.Add(new HandleError());
            
            app.UseWebApi(config);
           
        }

    }

    
}

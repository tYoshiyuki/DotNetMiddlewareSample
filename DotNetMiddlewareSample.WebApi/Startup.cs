using System.Web.Http;
using DotNetMiddlewareSample.WebApi;
using DotNetMiddlewareSample.WebApi.Middleware;
using Microsoft.Owin;
using NSwag.AspNet.Owin;
using Owin;

[assembly: OwinStartup(typeof(Startup))]
namespace DotNetMiddlewareSample.WebApi
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            var configuration = new HttpConfiguration();
            configuration.MapHttpAttributeRoutes();

            app.UseSwaggerUi3(typeof(Startup).Assembly, settings => { });

            app.UseStopwatch();

            app.UseWebApi(configuration);
        }
    }
}

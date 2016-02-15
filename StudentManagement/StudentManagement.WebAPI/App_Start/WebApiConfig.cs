using System.Web.Http;
using System.Web.Http.Cors;

namespace StudentManagement.WebAPI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.IgnoreRoute("axd", "{resource}.axd/{*pathInfo}");
            config.Routes.IgnoreRoute("fav", "{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" }
            );

            config.Filters.Add(new StudentManagementExceptionFilterAttribute());
            var cors = new EnableCorsAttribute("*", "*", "*");
            config.EnableCors(cors);
            log4net.Config.XmlConfigurator.Configure();
        }
    }
}

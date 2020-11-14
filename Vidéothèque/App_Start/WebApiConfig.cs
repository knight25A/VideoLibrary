using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Xml;

namespace Vidéothèque
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            //JSON post Api, make every element camel case
            var settings = config.Formatters.JsonFormatter.SerializerSettings;
            settings.ContractResolver = new Newtonsoft.Json.Serialization.CamelCasePropertyNamesContractResolver();
            settings.Formatting = (Newtonsoft.Json.Formatting)Formatting.Indented;

            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApplication3.MassageHandles;

namespace WebApplication3
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "ProductsAPI",
                routeTemplate: "products/{id}",
                defaults: new {controller = "Products", id = RouteParameter.Optional }
            );

        //    config.MessageHandlers.Add(new APIKeyMassageHandler());
        }
    }
}

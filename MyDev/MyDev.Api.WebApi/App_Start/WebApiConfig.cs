using MyDev.Api.WebApi.Areas.HelpPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace MyDev.Api.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务

            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.SetDocumentationProvider(new XmlDocumentationProvider(System.Web.HttpContext.Current.Server.MapPath("~/App_Data/MyDev.Api.WebApi.XML")));
        }
    }
}

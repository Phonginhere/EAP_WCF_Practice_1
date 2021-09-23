using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace WebApplication_WCF_Movies_Prc2
{
    public static class WebApiConfig
    {
        //public static void Register(HttpConfiguration config)
        //{
        //    // Web API configuration and services

        //    // Web API routes

        //    //config.MapHttpAttributeRoutes();

        //    config.Routes.MapHttpRoute("APIblabla", "api/{controller}/{id}",
        //      new { id = RouteParameter.Optional });
        //}
        public static void Register(HttpConfiguration configuration)
        {
            configuration.Routes.MapHttpRoute("Default API", "api/{controller}/{id}",
                new { id = RouteParameter.Optional });
        }
    }
}

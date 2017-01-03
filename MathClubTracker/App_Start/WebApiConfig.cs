using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web.Http;
using Newtonsoft.Json.Serialization;
using MathClubTracker.Filters;
using WebApiContrib.Formatting.Jsonp;
using System.Web.Http.OData.Builder;
using System.Web.Http.OData.Extensions;
using MathClubTracker.Domain.DomainObjects;


namespace MathClubTracker
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Student",
                routeTemplate: "enrollees/{id}/{action}",
                defaults: new { Controller = "Student", action = RouteParameter.Optional },
                constraints : new { id = "/d+"} // restricts id to be integer only -- not needed here but used as an example to bind regular expressions
                                                // to proper parameter formats.
            );

            config.Routes.MapHttpRoute(
                name: "OtherActions",
                routeTemplate: "api/{controller}/{id}/{action}",
                defaults: new { action = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "Classes",
                routeTemplate: "classes/{action}",
                defaults: new { Controller = "Student", action = RouteParameter.Optional }
            );

            /*
            The WebApiConfig class may require additional changes to add a route for this controller. Merge these statements into the Register method of the WebApiConfig class as applicable. Note that OData URLs are case sensitive.
            */

            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<Student>("Student");
            config.Routes.MapODataServiceRoute("odata", "odata", builder.GetEdmModel());
            



            // These two lines below change the json result formatting to use camel case instead of pascal case.
            var jsonFormatter = config.Formatters.OfType<JsonMediaTypeFormatter>().FirstOrDefault();

            //jsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            jsonFormatter.SerializerSettings.ContractResolver = new DefaultContractResolver();

            var formatter = new JsonpMediaTypeFormatter(jsonFormatter);
            config.Formatters.Insert(0, formatter);

#if !DEBUG
            //Force HTTPS on entire API
            config.Filters.Add(new RequireHttpsAttribute());
#endif
            // Uncomment the following line of code to enable query support for actions with an IQueryable or IQueryable<T> return type.
            // To avoid processing unexpected or malicious queries, use the validation settings on QueryableAttribute to validate incoming queries.
            // For more information, visit http://go.microsoft.com/fwlink/?LinkId=279712.
            //config.EnableQuerySupport();
        }
    }
}
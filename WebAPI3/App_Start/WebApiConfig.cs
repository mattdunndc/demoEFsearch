using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.OData.Extensions;
using System.Web.OData.Builder;
using System.Web.OData.Extensions;
using Microsoft.OData.Edm;
using Microsoft.OData.Edm.Library;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using NRPTmodel;
using NRPTmodel.Models;

namespace WebAPI3
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
      
            //The origins parameter of the [EnableCors] attribute specifies which origins are allowed to access the resource.
            var cors = new EnableCorsAttribute("http://localhost:60655", "*", "*");
            config.EnableCors(); // requires nuget cors: Install-Package Microsoft.AspNet.WebApi.Cors
      
            // Web API routes
            config.MapHttpAttributeRoutes();
            ///
            /// 
            /// 
            /// 
            config.MapODataServiceRoute("odata", "odata", getModel());


            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Formatters.JsonFormatter.SerializerSettings.Formatting = Formatting.Indented;
            config.Formatters.JsonFormatter.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
            config.Formatters.JsonFormatter.SupportedMediaTypes.Add(new MediaTypeHeaderValue("text/html")); //remove xml from reg api call like t_dept_smart

        }

        public static IEdmModel getModel()
        {
            ODataConventionModelBuilder builder = new ODataConventionModelBuilder();
            builder.EntitySet<t_inst_institutn>("t_inst_institutn");
            builder.EntitySet<t_rrac_activity>("t_rrac_activity");
            builder.EntitySet<t_rrqs_resource_request>("t_rrqs_resource_request");

            builder.EntitySet<t_user>("t_user");

            builder.EntitySet<t_proj_project>("t_proj_project");
            // New code for project like sp:
            builder.Function("GetNextId").Returns<int>();

            builder.EntitySet<t_prdp_proj_dept>("t_prdp_proj_dept");
            builder.EntitySet<t_prin_proj_inst>("t_prin_proj_inst");

            // New code for project like sp:
            builder.Function("getNextId").Returns<int>();

            builder.EntitySet<t_stcd_state_cd>("t_stcd_state_cd");
            builder.EntitySet<t_rrcs_city_state_near_rrlc>("t_rrcs_city_state_near_rrlc");

            builder.EntitySet<t_scad_app_def>("t_scad_app_def");
            builder.EntitySet<t_prap_proj_scad>("t_prap_proj_scad"); 

            return builder.GetEdmModel();
        }
    }
}

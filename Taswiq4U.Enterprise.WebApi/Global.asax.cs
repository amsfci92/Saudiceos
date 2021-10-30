using Cigarette.Enterprise.Extentions.Mapping;
using OperationManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using Taswiq4U.Enterprise.WebApi.MessageAPIHandler;

namespace Taswiq4U.Enterprise.WebApi
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected  void Application_Start()
        {
            MappingProfile.Initialize();//mapping

            AreaRegistration.RegisterAllAreas();
            UnityWebApiActivator.Start();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //GlobalConfiguration.Configuration.MessageHandlers.Add(new AuthorizationHandler());
            //await JobScheduler.Start();
        }
    }
}

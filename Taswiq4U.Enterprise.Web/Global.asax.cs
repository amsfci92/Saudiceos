using Cigarette.Enterprise.Extentions.Mapping;
using OperationManager.GeoLocation;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing; 
namespace Saudiceos.Enterprise.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            MappingProfile.Initialize();//mapping
            //AreaRegistration.RegisterAllAreas();

            UnityConfig.RegisterComponents();//DI 
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {  
        }
        
        
        private string GetCountryCodeByIP(string ip)
        {
            var geoLocationManager = new GeoLocationManager();
            var countryDetails = geoLocationManager.GetCountryData(ip);

            if (countryDetails != null && countryDetails.geoplugin_countryCode != null)
            {
                return countryDetails.geoplugin_countryCode.ToLower();
            }
            return null;
        }
    }
}

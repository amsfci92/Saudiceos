using OperationManager.GeoLocation;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Saudiceos.Enterprise.Web.Attributes
{

    public partial class CountryFilterAttribute : ActionFilterAttribute
    { 
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        { 
            //Log("OnActionExecuting", filterContext.RouteData);
            //string language = (string)filterContext.RouteData.Values["language"];
            //var country = (string)filterContext.RouteData.Values["country"];
            //if (language != null)
            //{
            //    string CountryAbbrevation = "KW";
            //    var cookieCountry = HttpContext.Current.Request.Cookies["Country"];
            //    if (country != null)
            //    { 
            //        CountryAbbrevation = country;
            //        filterContext.RouteData.Values["country"] = country;
            //    }
            //    else
            //    {
            //        var geoLocationManager = new GeoLocationManager();
            //        var countryDetails = geoLocationManager.GetCountryData("156.204.161.24");

            //        if (countryDetails != null && countryDetails.geoplugin_countryCode != null)
            //        {
            //            CountryAbbrevation = countryDetails.geoplugin_countryCode;
            //        }
            //    }

            //    HttpCookie cookie = new HttpCookie("Country");
            //    cookie.Value = CountryAbbrevation;
            //    filterContext.HttpContext.Response.Cookies.Add(cookie);
            //    if (!filterContext.IsChildAction && !filterContext.HttpContext.Request.RawUrl.Contains(country))
            //    {
            //        filterContext.Result = new RedirectToRouteResult(
            //                            filterContext.RequestContext.RouteData.Values
            //                            );
            //    }
                

            //} 
        }

        private void Log(string methodName, RouteData routeData)
        {
            var controllerName = routeData.Values["controller"];
            var actionName = routeData.Values["action"];
            var message = String.Format("{0}- controller:{1} action:{2}", methodName,
                                                                        controllerName,
                                                                        actionName);
            Debug.WriteLine(message);
        }


    }
}

using System.Web.Mvc;
using Saudiceos.Enterprise.Web.helper; 

namespace Saudiceos.Enterprise.Web.Controllers
{
    public class BaseController : Controller
    {
        public string language = "ar";
        public string country = "eg";
        public int countryId = 1;
        public string currency = "EPG";

        public BaseController()
        {
            var cookieManager = CookieHelper.Instance(httpContext: System.Web.HttpContext.Current, System.Web.HttpContext.Current.Response);
            var c = cookieManager.CurrentCountry();
            var l = cookieManager.CurrentLanguage();

            if (!string.IsNullOrWhiteSpace(c))
            {
                country = c;
            }

            if (!string.IsNullOrWhiteSpace(l))
            {
                language = l;
            }
        }
    }
}
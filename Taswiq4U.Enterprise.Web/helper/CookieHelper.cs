using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Cigarette.Enterprise.ResourceManager.Helpers;

namespace Saudiceos.Enterprise.Web.helper
{
    public class CookieHelper
    {
        private static HttpResponse _httpResponseBase;
        private static HttpContext _httpContext;
        public CookieHelper(HttpContext httpContext, HttpResponse httpResponseBase)
        {
            _httpResponseBase = httpResponseBase;
            _httpContext = httpContext;
        }
        public static CookieHelper Instance(HttpContext httpContext, HttpResponse httpResponseBase)
        {
            return new CookieHelper(httpContext, httpResponseBase);
        }

        public static bool IsArabic()
        {
            return CultureHelper.IsArabic();
        }

        public string CurrentCountry()
        {
            var countrCode = "eg";
            var cookie = _httpContext.Request.Cookies["Country"];

            if (cookie != null && cookie.Value != null)
            {
                countrCode = cookie.Value;
            }
            else
            {
                HttpCookie newcookie = new HttpCookie("Country");
                newcookie.Value = countrCode;
                _httpResponseBase.Cookies.Add(newcookie);
            }
            return countrCode;
        }
        public string CurrentLanguage()
        {
            return CultureHelper.IsArabic() ? "ar" : "en";
        }
    }
}
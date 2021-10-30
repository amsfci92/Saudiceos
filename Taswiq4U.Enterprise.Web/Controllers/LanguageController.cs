//using Cigarette.Enterprise.BLL.CountryServ;
//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Runtime.CompilerServices;
//using System.Threading;
//using System.Web;
//using System.Web.Mvc;

//namespace Saudiceos.Enterprise.Web.Controllers
//{

//    public class LanguageController : BaseController
//    {
//        private ICountryService _countryService;

//        public LanguageController(ICountryService countryService)
//        {
//            _countryService = countryService;
//        }

//        public ActionResult Change(string returnUrl, string language = "ar")
//        {
//            int count = 0;
//            int index = 0;
            
//            string LanguageAbbrevation = "ar";
//            if (language != null && language == "en")
//            {
//                LanguageAbbrevation = "en";
//            }

//            CultureInfo cultureInfo = new CultureInfo(LanguageAbbrevation, true);
//            cultureInfo.DateTimeFormat.Calendar = new GregorianCalendar();
//            cultureInfo.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";

//            Thread.CurrentThread.CurrentCulture = cultureInfo;

//            CultureInfo uicultureInfo = new CultureInfo(LanguageAbbrevation, true);
//            uicultureInfo.DateTimeFormat.Calendar = new GregorianCalendar();
//            uicultureInfo.DateTimeFormat.ShortDatePattern = "dd/MM/yyyy";

//            Thread.CurrentThread.CurrentUICulture = uicultureInfo;

//            HttpCookie cookie = new HttpCookie("Language");
//            cookie.Value = LanguageAbbrevation;
//            Response.Cookies.Remove("Language");
//            Response.Cookies.Add(cookie);
//            Request.Cookies.Add(cookie);


//            return RedirectToLocal(returnUrl);
//        }

//        private ActionResult RedirectToLocal(string returnUrl)
//        {
//            if (string.IsNullOrWhiteSpace(returnUrl))
//            {
//                return RedirectToAction("Index", "Advertisement");
//            }
//            if (Url.IsLocalUrl(returnUrl))
//            {
//                return Redirect(returnUrl);
//            }
//            return RedirectToAction("Index", "Advertisement");
//        }
//    }
//}
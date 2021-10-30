//using System;
//using System.Collections.Generic;
//using System.Globalization;
//using System.Linq;
//using System.Threading;
//using System.Web;
//using System.Web.Mvc;

//namespace Saudiceos.Enterprise.Web.Areas.AdminPanel.Controllers
//{
//      // GET: AdminPanel/Languge
//        [RoutePrefix("Language")]
//        public class LanguageController : Controller
//        {

//            [HttpPost]
//            [Route("Change")]
//            public ActionResult Change(int? Language)
//            {
//                string LanguageAbbrevation = "ar";
//                if (Language.HasValue && Language.Value == 2)
//                {
//                    LanguageAbbrevation = "en";
//                }

//                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(LanguageAbbrevation);
//                Thread.CurrentThread.CurrentUICulture = new CultureInfo(LanguageAbbrevation);

//                HttpCookie cookie = new HttpCookie("Language");
//                cookie.Value = LanguageAbbrevation;
//                Response.Cookies.Add(cookie);
//                return Json(new { result = "success" });
//            }
//        } 
//}
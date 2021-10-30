//using AutoMapper;
//using Cigarette.Enterprise.BLL.AboutServ;
//using Cigarette.Enterprise.BLL.CountryAdminServ;
//using Cigarette.Enterprise.BLL.CountryServ;
//using Cigarette.Enterprise.ViewModels.ViewModels.About;
//using Microsoft.AspNet.Identity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace Saudiceos.Enterprise.Web.Areas.AdminPanel.Controllers
//{
//    [Authorize(Roles = "Admin,CountryAdmin")]
//    public class AboutController : Controller
//    {
//        IAboutService _aboutService;
//        ICountryService _countryService;
//        ICountryAdminService _countryAdminService;

//        public AboutController(IAboutService aboutService,
//            ICountryService countryService,
//            ICountryAdminService countryAdminService)
//        {
//            _aboutService = aboutService;
//            _countryService = countryService;
//            _countryAdminService = countryAdminService;
//        }

//        [Authorize(Roles = "Admin")]
//        [HttpGet]
//        public ActionResult Index()
//        {
//            var countries = _countryService.GetCountries().OrderBy(x => x.CountryId);
//            ViewBag.CountryId = new SelectList(countries, "CountryId", "ArabicDescription");

//            var countryId = (countries.ElementAt(0) != null) ? countries.ElementAt(0).CountryId : 0;

//            var model = _aboutService.GetAppInfo(countryId);

//            if (model == null)
//                model = new AboutVM { CountryId = countryId };

//            return View(model);
//        }

//        [Authorize(Roles = "CountryAdmin")]
//        [HttpGet]
//        public ActionResult CountryInfo()
//        {
//            var userId = User.Identity.GetUserId();
//            var countryId = _countryAdminService.AdminCountryId(userId);
//            ViewBag.CountryId = countryId;


//            var model = _aboutService.GetAppInfo(countryId);

//            if (model == null)
//                model = new AboutVM { CountryId = countryId };

//            return View("CountryInfo", model);
//        }

//        [HttpGet]
//        public ActionResult Edit(int countryId)
//        {
//            var model = _aboutService.GetAppInfo(countryId);
//            if (model == null)
//                model = new AboutVM { CountryId = countryId };
//            var res = Mapper.Map<AboutBM>(model);
//            return View(res);
//        }

//        [HttpPost]
//        public ActionResult Edit(AboutBM bM)
//        {
//            if (!ModelState.IsValid)
//            {
//                ModelState.AddModelError("", "All Fields Required");
//                return View(bM);
//            }

//            _aboutService.EditAppInfo(bM);
//            if (User.IsInRole("Admin"))
//            {
//                return RedirectToRoute("Admin.About.List");
//            }
//            else
//            {
//                return RedirectToAction("CountryInfo");
//            }
//        }

//        [HttpGet]
//        public ActionResult GetCountryInfo(int countryId)
//        {
//            var model = _aboutService.GetAppInfo(countryId);

//            if (model == null)
//                model = new AboutVM { CountryId = countryId };

//            return PartialView("Partials/_CountryInfo", model);
//        }
//    }
//}
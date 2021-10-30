//using AutoMapper;
//using Cigarette.Enterprise.BLL.CountryAdminServ;
//using Cigarette.Enterprise.BLL.CountryServ;
//using Cigarette.Enterprise.BLL.SmsGatewayServ;
//using Cigarette.Enterprise.ViewModels.ViewModels.SmsGateway;
//using Microsoft.AspNet.Identity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace Saudiceos.Enterprise.Web.Areas.AdminPanel.Controllers
//{
//    [Authorize(Roles = "Admin,CountryAdmin")]
//    public class SmsController : Controller
//    {
//        ISmsGatewayService _smsGatewayService;
//        ICountryService _countryService;
//        ICountryAdminService _countryAdminService { get; set; }

//        public SmsController(ISmsGatewayService smsGatewayService,
//            ICountryService countryService,
//            ICountryAdminService countryAdminService)
//        {
//            _smsGatewayService = smsGatewayService;
//            _countryService = countryService;
//            _countryAdminService = countryAdminService;
//        }

//        [Authorize(Roles = "Admin")]
//        // GET: AdminPanel/Sms
//        public ActionResult Index()
//        {
//            var countries = _countryService.GetCountries().OrderBy(x => x.CountryId);
//            ViewBag.CountryId = new SelectList(countries, "CountryId", "ArabicDescription");

//            var countryId = (countries.ElementAt(0) != null) ? countries.ElementAt(0).CountryId : 0;

//            var models = _smsGatewayService.GetSmsGatewayByCountryId(countryId);

//            return View(models);
//        }

//        [Authorize(Roles = "CountryAdmin")]
//        // GET: AdminPanel/Sms
//        public ActionResult Country()
//        {
//            var userId = User.Identity.GetUserId();
//            var countryId = _countryAdminService.AdminCountryId(userId);

//            var models = _smsGatewayService.GetSmsGatewayByCountryId(countryId);

//            return View(models);
//        }

//        [HttpGet]
//        public ActionResult Edit(int countryId)
//        {
//            var model = _smsGatewayService.GetSmsGatewayByCountryId(countryId);
//            if (model == null)
//                model = new SmsGatewayVM { CountryId = countryId };
//            //model.CountryId = countryId;

//            var bm = Mapper.Map<SmsGatewayBM>(model);
//            return View(bm);
//        }

//        [HttpPost]
//        public ActionResult Edit(SmsGatewayBM bM)
//        {
//            if (!ModelState.IsValid)
//            {
//                ModelState.AddModelError("", "All Fields Required");
//                return View(bM);
//            }

//            _smsGatewayService.AddOrEdit(bM);
//            if (User.IsInRole("Admin"))
//            {
//                return RedirectToRoute("Admin.Sms.Gatewaies");
//            }
//            else
//            {
//                return RedirectToAction("Country");
//            }
//        }

//        [HttpGet]
//        public ActionResult GetCountrySmsGateway(int countryId)
//        {
//            var model = _smsGatewayService.GetSmsGatewayByCountryId(countryId);
//            if (model == null)
//                model = new SmsGatewayVM { CountryId = countryId };

//            return PartialView("Partials/_CountryGateway", model);
//        }


//    }
//}
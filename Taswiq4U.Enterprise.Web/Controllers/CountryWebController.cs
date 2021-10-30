//using Cigarette.Enterprise.BLL.AdvertisementImageServ;
//using Cigarette.Enterprise.BLL.AdvertisementServ;
//using Cigarette.Enterprise.BLL.Category_SpecificationServ;
//using Cigarette.Enterprise.BLL.CategoryServ;
//using Cigarette.Enterprise.BLL.CityServ;
//using Cigarette.Enterprise.BLL.CountryServ;
//using Cigarette.Enterprise.BLL.FavoriteServ;
//using Cigarette.Enterprise.BLL.StateServ;
//using Cigarette.Enterprise.DAL.UserInfoServ;
//using Microsoft.AspNet.Identity.Owin;
//using OperationManager.GeoLocation;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text.RegularExpressions;
//using System.Web;
//using System.Web.Mvc;
//using Saudiceos.Enterprise.Web.helper;

//namespace Saudiceos.Enterprise.Web.Controllers
//{
//    public class CountryWebController : BaseController
//    {
//        #region Fields

//        private IAdvertisementServices _advertisementServices;
//        private ICategoryServices _categoryServices;
//        private ICategory_SpecificationServices _category_SpecificationAttributeServices;
//        private PaginationExtention _paginationExtention;
//        private ICityServices _cityServices;
//        private IStateService _stateService;
//        private IFavoriteService _favoriteService;
//        private ApplicationUserManager _userManager;
//        private IUserInfoService _userInfoService;
//        private IAdvertisementImageServices _advertisementImageServices;
//        private ICountryService _countryService;

//        public ApplicationUserManager UserManager
//        {
//            get
//            {
//                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
//            }
//            private set
//            {
//                _userManager = value;
//            }
//        }
//        #endregion 
//        #region ctor

//        public CountryWebController(IAdvertisementServices advertisementServices,
//            ICategoryServices categoryServices,
//            ICategory_SpecificationServices category_SpecificationAttributeServices,
//            IStateService stateService,
//            ICityServices cityServices,
//            //ApplicationUserManager userManager,
//            IUserInfoService userInfoService,
//            IFavoriteService favoriteService,
//            IAdvertisementImageServices advertisementImageServices,
//            ICountryService countryService)
//        {
//            _advertisementServices = advertisementServices;
//            _categoryServices = categoryServices;
//            _category_SpecificationAttributeServices = category_SpecificationAttributeServices;
//            _cityServices = cityServices;
//            _stateService = stateService;
//            _paginationExtention = new PaginationExtention();
//            _favoriteService = favoriteService;
//            //UserManager = userManager;
//            _userInfoService = userInfoService;
//            _advertisementImageServices = advertisementImageServices;
//            _countryService = countryService;
//        }

//        #endregion
//        public ActionResult Change(string returnUrl, string country = "eg")
//        {
//            var countrFound = _countryService.GetCountryByAbbr(country.ToLower());

//            //int count = 0;
//            //int index = 0;
//            //for (int i = 0; i < returnUrl.Length; i++)
//            //{
//            //    if (returnUrl[i] == '/')
//            //    {
//            //        count++;
//            //        if (count == 3)
//            //        {
//            //            index = i;
//            //            break;
//            //        }
//            //    }
//            //}

//            //string redirectUrl = "";
//            //if (count == 3)
//            //    redirectUrl = returnUrl.Substring(index + 1);

//            string CountryAbbrevation = "KW";
//            if (countrFound != null && country.ToLower() != "kw")
//            {
//                CountryAbbrevation = country;
//            }

//            HttpCookie cookie = new HttpCookie("Country");
//            cookie.Value = CountryAbbrevation.ToLower();
//            Response.Cookies.Remove("Country");
//            Response.Cookies.Add(cookie);
//            Request.Cookies.Add(cookie);

//            cookie = new HttpCookie("CountryText");
//            cookie.Value = language.ToLower() == "en" ? countrFound.EnglishDescription : countrFound.ArabicDescription;

//            Response.Cookies.Add(cookie);

//            //return RedirectToLocal($"/{CountryAbbrevation}/{language ?? "ar"}/{redirectUrl}");
//            return RedirectToHome();
//        }

//        public ActionResult CountryList(string Language)
//        {
//            var countryList = _countryService.GetCountries(false);
//            ViewBag.Language = Language;
//            return View(countryList);
//        }

//        public ActionResult SetCountry()
//        {
//            Request.Cookies.Remove("Country");

//            var countryCookie = Request.Cookies["Country"];
//            var geoLocationManager = new GeoLocationManager();
//            var countryDetails = geoLocationManager.GetCountryData(Request.UserHostAddress);

//            if (countryDetails != null && countryDetails.geoplugin_countryCode != null &&
//                string.IsNullOrWhiteSpace(country))
//            {
//                country = countryDetails.geoplugin_countryCode.ToLower();
//                var countrySystemDetails = _countryService.GetCountryByAbbr(country);

//                if (countrySystemDetails == null)
//                {
//                    country = "eg";
//                }
//            }

//            if ((countryCookie == null || string.IsNullOrWhiteSpace(countryCookie.Value)))
//            {
//                if (string.IsNullOrWhiteSpace(country))
//                {
//                    country = "eg";
//                }
//                HttpCookie newCountryCookie = new HttpCookie("Country");
//                newCountryCookie.Value = country ?? country;
//                Request.Cookies.Remove("Country");

//                Response.Cookies.Add(newCountryCookie);
//            }
//            else if ((!string.IsNullOrWhiteSpace(country) && country.ToLower() != countryCookie.Value.ToLower()))
//            {
//                HttpCookie newCountryCookie = new HttpCookie("Country");
//                newCountryCookie.Value = country;
//                Request.Cookies.Remove("Country");
//                Request.Cookies.Add(newCountryCookie);
//            }
//            return RedirectToHome();
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


//        private ActionResult RedirectToHome()
//        {
//            return RedirectToAction("Index", "Advertisement");
//        }
//    }
//}
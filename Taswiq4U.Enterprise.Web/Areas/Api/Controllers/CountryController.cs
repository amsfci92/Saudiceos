//using Cigarette.Enterprise.BLL.CityServ;
//using Cigarette.Enterprise.BLL.CountryServ;
//using Cigarette.Enterprise.BLL.StateServ;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using Saudiceos.Enterprise.Web.Models;

//namespace Saudiceos.Enterprise.Web.Areas.Api.Controllers
//{
//    public class CountryApiController : Controller
//    {
//        #region Fields
//        private ICountryService _countryService;
//        private ICityServices _cityService;
//        private IStateService _stateService;

//        #endregion

//        #region Ctor

//        public CountryApiController(ICountryService countryService,
//            ICityServices cityService,
//            IStateService stateService)
//        {
//            _countryService = countryService;
//            _cityService = cityService;
//            _stateService = stateService;
//        }
//        #endregion
        
//        /// <summary>
//        /// Get Countries
//        /// </summary>
//        /// <returns></returns> 
//        public JsonResult GetActiveCountries()
//        {
//            var countries = _countryService.GetCountries(false);

//            return Json(new { status = true, countries }, JsonRequestBehavior.AllowGet);
//        }

//        /// <summary>
//        /// Get Cities
//        /// </summary>
//        /// <returns></returns> 
//        public JsonResult GetActiveCities(string country)
//        {
//            var countrDetails = _countryService.GetCountryByAbbr(country,false);
//            if (countrDetails != null)
//            {
//                var cities = _cityService.GetCountryCities(countrDetails.CountryId);
//                if (cities != null)
//                {
//                    var citiesMapped = cities.Select(m => new { m.Id, NameAr = m.ArabicName, NameEn = m.EnglishName, States = m.StateList });
//                    return Json(new { status = true, citiesMapped }, JsonRequestBehavior.AllowGet);

//                }

//            }

//            return Json(new { status = false }, JsonRequestBehavior.AllowGet);
//        }

//        public JsonResult GetActiveCitiesStates(int cityId)
//        {
//            var states = _stateService.GetStatesWithCity(cityId);
//            if (states != null)
//            {
//                var citiesMapped = states.Select(m => new { m.Id, NameAr = m.ArabicName, NameEn = m.EnglishName });
//                return Json(new { status = true, citiesMapped }, JsonRequestBehavior.AllowGet);
//            }
                 
//            return Json(new { status = false }, JsonRequestBehavior.AllowGet);


//        }

//        /// <summary>
//        /// Get CountryData
//        /// </summary>
//        /// <returns></returns> 
//        [HttpGet] 
//        public JsonResult GetCountryData()
//        {
//            int.TryParse(User.Identity.GetCountryId(), out int countryId);
//            if (countryId != 0)
//            {
//                var country = _countryService.GetCountryBindingModel(countryId);
//                return Json(new { status = true, country }, JsonRequestBehavior.AllowGet);
//            }
//            return Json(new { status = false }, JsonRequestBehavior.AllowGet);
//        }

//    }
//}
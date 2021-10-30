//using Cigarette.Enterprise.BLL.CityServ;
//using Cigarette.Enterprise.BLL.CountryServ;
//using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.Country;
//using Microsoft.AspNet.Identity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Http;
//using System.Web.Http.Cors;
//using Taswiq4U.Enterprise.WebApi.Helpers;
//using Taswiq4U.Enterprise.WebApi.Models;

//namespace Taswiq4U.Enterprise.WebApi.Controllers
//{
//    [RoutePrefix("api/country")] 
    
//    public class CountryController : ApiController
//    {
//        #region Fields
//        private ICountryService _countryService;
//        private ICityServices _cityService;
        
//        #endregion

//        #region Ctor

//        public CountryController(ICountryService countryService,
//            ICityServices cityService)
//        {
//            _countryService = countryService;
//            _cityService = cityService;
//        }
//        #endregion

//        #region Methods
//        /// <summary>
//        /// Get Countries
//        /// </summary>
//        /// <returns></returns>
//        [Route("CountriesList")]
//        public IHttpActionResult GetActiveCountries()
//        {
//            var countries = _countryService.GetCountries();

//            return Ok(countries);
//        }

//        /// <summary>
//        /// Get Cities
//        /// </summary>
//        /// <returns></returns>
//        //[Route("CitiesList")]
//        [Route("GetActiveCities")]
//        public IHttpActionResult GetActiveCities(int countryId)
//        {
//            var cities = _cityService.GetCountryCities(countryId);

//            return Ok(cities);
//        }

//        /// <summary>
//        /// Get CountryData
//        /// </summary>
//        /// <returns></returns>
//        [Route("GetCountryData")]
//        [Authorize]
//        [EnableCors(origins: "*", headers: "*", methods: "*")]
//        public IHttpActionResult GetCountryData()
//        {
//            int.TryParse(User.Identity.GetCountryId(), out int countryId);
//            if (countryId != 0)
//            {
//                var cities = _countryService.GetCountryById(countryId);
//                return Ok(cities);
//            }
//            return BadRequest();
//        }

//        /// <summary>
//        /// Set Country
//        /// </summary>
//        /// <returns></returns>
//        [Route("ChangeCountry")]
//        [HttpGet]
//        [Authorize]
//        public IHttpActionResult SetUserCountry(int countryId)
//        {
//            var userId = User.Identity.GetUserId();

//            var result = _countryService.ChangeUserCountry(userId, countryId);

//            if (result)
//            {
//                return Ok();
//            }

//            return BadRequest(ErrorCodes.Ins.ChangeCountryFaild.Code);
//        } 
//        #endregion 
//    }
//}

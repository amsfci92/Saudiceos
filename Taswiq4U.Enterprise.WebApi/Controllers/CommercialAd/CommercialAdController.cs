//using Cigarette.Enterprise.BLL.CategoryServ;
//using Cigarette.Enterprise.BLL.CommercialAdServ;
//using Microsoft.AspNet.Identity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Http; 

//namespace Taswiq4U.Enterprise.WebApi.Controllers.CommercialAd
//{
//    [RoutePrefix("api/CommercialAd")]
//    public class CommercialAdController : ApiController
//    {
//        #region Fields
//        private ICategoryServices _categoryService;
//        private ICommercialAdService _commercialAdService;
//        #endregion

//        #region Ctor
//        public CommercialAdController(ICategoryServices categoryServices,
//            ICommercialAdService commercialAdService)
//        {
//            _categoryService = categoryServices;
//            _commercialAdService = commercialAdService;
//        }
//        #endregion

//        #region Methods
//        /// <summary>
//        /// GetMainSliderAds
//        /// </summary>
//        /// <returns></returns>
//        [Route("GetMainSliderAds/{countryId}")]
//        [HttpGet] 
//        public async Task<IHttpActionResult> GetMainSliderAds(int countryId) { 
//            var commercialAds = _commercialAdService.GetCommercialAdsByCountryMainSlider(countryId);

//            return Ok(commercialAds);
//        }

//        /// <summary>
//        /// GetMainSliderAds
//        /// </summary>
//        /// <returns></returns>
//        [Route("GetPopUpAds/{countryId}")]
//        [HttpGet]
//        public async Task<IHttpActionResult> GetPopUpAds(int countryId, int categoryId = 0)
//        {
//            var commercialAds = _commercialAdService.GetCommercialAdsByCountryPopUp(countryId);

//            return Ok(commercialAds);
//        }

//        /// <summary>
//        /// GetMainSliderAds
//        /// </summary>
//        /// <returns></returns>
//        [Route("GetOfferAds/{countryId}/{categoryId}")]
//        [HttpGet]

//        public async Task<IHttpActionResult> GetOfferAds(int countryId, int categoryId = 0)
//        {
//            var commercialAds = _commercialAdService.GetCommercialAdsByCountryOffers(countryId, categoryId);

//            return Ok(commercialAds);
//        }


//        /// <summary>
//        /// GetMainSliderAds
//        /// </summary>
//        /// <returns></returns>
//        [Route("GetInBetweenAds/{countryId}/{categoryId}")]
//        [HttpGet]

//        public async Task<IHttpActionResult> GetInBetweenAds(int countryId, int categoryId = 0)
//        {
//            var commercialAds = _commercialAdService.GetCommercialAdsByCountryInBetween(countryId, categoryId);

//            return Ok(commercialAds);
//        }

//        /// <summary>
//        /// LikeAd
//        /// </summary>
//        /// <returns></returns>
//        [Route("LikeAd/{adId}")]
//        [HttpGet]

//        [Authorize]
//        public async Task<IHttpActionResult> LikeAd(int adId)
//        {
//            var result = _commercialAdService.IncrementAdLikes(adId, User.Identity.GetUserId());

//            return Ok(result);
//        }

//        /// <summary>
//        /// GetMainSliderAds
//        /// </summary>
//        /// <returns></returns>
//        [Route("ViewAd/{adId}")]
//        [HttpGet]

//        public async Task<IHttpActionResult> ViewAd(int adId)
//        {
//            var result = _commercialAdService.IncrementViewCount(adId);

//            return Ok(result);
//        }
         
//        #endregion

//    }
//}
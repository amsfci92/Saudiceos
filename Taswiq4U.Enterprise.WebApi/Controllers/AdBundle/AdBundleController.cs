//using Cigarette.Enterprise.BLL.AdBundleServ;
//using Cigarette.Enterprise.BLL.CategoryServ;
//using Cigarette.Enterprise.ViewModels.BindingModels.Bundle;
//using Cigarette.Enterprise.ViewModels.BindingModels.UserBundle;
//using Microsoft.AspNet.Identity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Http;
//using Taswiq4U.Enterprise.WebApi.Helpers;

//namespace Taswiq4U.Enterprise.WebApi.Controllers.AdBundle
//{
//    [RoutePrefix("api/AdBundle")]
//    public class AdBundleController : ApiController
//    {
//        #region Fields
//        private ICategoryServices _categoryService;
//        private IAdBundleService _bundleService;

//        #endregion

//        #region Ctor
//        public AdBundleController(ICategoryServices categoryServices,
//         IAdBundleService bundleService)
//        {
//            _categoryService = categoryServices;
//            _bundleService = bundleService;
//        }
//        #endregion

//        #region Methods
//        /// <summary>
//        /// Get All Country Bundles
//        /// </summary>
//        /// <returns></returns>
//        [Route("GetAllBundlesByCountry")]
//        [HttpGet]
//        public IHttpActionResult GetAllBundlesByCountry(int countryId)
//        {
//            var categories = _bundleService.GetBundleByCountry(countryId);

//            return Ok(categories);
//        }


//        /// <summary>
//        /// Get User ValidBundles
//        /// </summary>
//        /// <returns></returns>
//        [Route("GetUserValidBundles")]
//        [HttpGet]

//        public IHttpActionResult GetUserValidBundles(int mainCategoryId)
//        {
//            var categories = _bundleService.GetBundleByCountry(mainCategoryId);

//            return Ok(categories);
//        }

//        /// <summary>
//        /// Get User ValidBundles
//        /// </summary>
//        /// <returns></returns>
//        [Route("BuyBundle")]
//        [HttpPost]
//        [Authorize]
//        public IHttpActionResult BuyBundle([FromBody] UserBundleBM bundleBM)
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ErrorCodes.Ins.InvalidData.Code);
//            }
//            bundleBM.UserId = User.Identity.GetUserId();

//            var categories = _bundleService.AddUserBundle(bundleBM);

//            return Ok(categories);
//        }

//        /// <summary>
//        /// Get User ValidBundles
//        /// </summary>
//        /// <returns></returns>
//        [Route("GetUserBundleAdsCount")]
//        [HttpGet]
//        [Authorize]
//        public IHttpActionResult GetUserBundleTotalAds()
//        {
//            string userId = User.Identity.GetUserId();

//            var categories = _bundleService.GetAdBundleTotalPaidAds(userId);

//            return Ok(categories);
//        }


//        #endregion

//    }
//}
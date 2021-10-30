//using Cigarette.Enterprise.BLL.AdvertisementServ;
//using Cigarette.Enterprise.BLL.FavoriteServ;
//using Cigarette.Enterprise.DAL.Repository.FavoriteRep;
//using Cigarette.Enterprise.ViewModels.Pagination;
//using Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel.Advertisement;
//using Microsoft.AspNet.Identity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Http;
//using Taswiq4U.Enterprise.WebApi.Helpers;

//namespace Taswiq4U.Enterprise.WebApi.Controllers.Favorite
//{
//    [RoutePrefix("Api/Favorite")]
//    public class FavoriteController : ApiController
//    {
//        #region Fields
//        private IFavoriteService _favoriteService;
//        private IAdvertisementServices _advertismentService;
//        #endregion

//        #region Ctor

//        public FavoriteController(IFavoriteService favoriteService, IAdvertisementServices advertisementServices)
//        {
//            _favoriteService = favoriteService;
//            _advertismentService = advertisementServices;
//        }

//        #endregion

//        #region Methods

//        [Route("GetFavoriteAds")]
//        [Authorize]
//        [HttpGet]
//        public async Task<IHttpActionResult> GetUserFavoriteAds(int? Page = 1, int? Size = 10)
//        {
//            var userId = User.Identity.GetUserId();
//            var paging = new PagingParams();
//            paging.Size = Size.Value;
//            paging.Page = Page.Value;
//            var favorites = await _favoriteService.GetUSerFavoriteAdsAsync(userId, paging);

//            return Ok(favorites);
//        }

//        [Route("AddToFavorite")]
//        [Authorize]
//        [HttpGet]
//        public async Task<IHttpActionResult> AddToFavorite(int adId)
//        {
//            var ad = _advertismentService.GetAdvertisementById(adId);
//            var userId = User.Identity.GetUserId();

//            if (ad == null)
//            {
//                return BadRequest(ErrorCodes.Ins.AdNotFound.Code);
//            }

//            bool result = await _favoriteService.AddToFavoriteAsync(userId, adId);
              
//            return Ok(result);
//        }



//        [Route("RemoveFromFavorite")]
//        [Authorize]
//        [HttpGet]
//        public async Task<IHttpActionResult> RemoveToFavorite(int adId)
//        {
//            var ad = _advertismentService.GetAdvertisementById(adId);
//            var userId = User.Identity.GetUserId();

//            if (ad == null)
//            {
//                return BadRequest(ErrorCodes.Ins.AdNotFound.Code);
//            }

//            bool result = await _favoriteService.RemoveFromFavoriteAsync(userId, adId);

//            return Ok(result);
//        }


//        #endregion
//    }
//}
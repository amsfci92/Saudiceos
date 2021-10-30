//using AutoMapper;
//using Cigarette.Enterprise.BLL.AdvertisementImageServ;
//using Cigarette.Enterprise.BLL.AdvertisementServ;
//using Cigarette.Enterprise.BLL.Category_SpecificationServ;
//using Cigarette.Enterprise.BLL.CategoryServ;
//using Cigarette.Enterprise.BLL.CityServ;
//using Cigarette.Enterprise.BLL.CommercialAdServ;
//using Cigarette.Enterprise.BLL.CountryServ;
//using Cigarette.Enterprise.BLL.FavoriteServ;
//using Cigarette.Enterprise.BLL.StateServ;
//using Cigarette.Enterprise.DAL;
//using Cigarette.Enterprise.DAL.Repository.CountryRep;
//using Cigarette.Enterprise.DAL.UserInfoServ;
//using Cigarette.Enterprise.ResourceManager.Helpers;
//using Cigarette.Enterprise.ViewModels.BindingModels.Advertisement;
//using Cigarette.Enterprise.ViewModels.BindingModels.Advertisement_SpecificationAttribute;
//using Cigarette.Enterprise.ViewModels.BindingModels.UserInfo;
//using Cigarette.Enterprise.ViewModels.Pagination;
//using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.City;
//using Cigarette.Enterprise.ViewModels.ViewModels.Advertisement;
//using Cigarette.Enterprise.ViewModels.ViewModels.Category;
//using Cigarette.Enterprise.ViewModels.ViewModels.Category_SpecificationAttribute;
//using Cigarette.Enterprise.ViewModels.ViewModels.City;
//using Cigarette.Enterprise.ViewModels.ViewModels.CommercialAd;
//using Cigarette.Enterprise.ViewModels.ViewModels.Generic;
//using Cigarette.Enterprise.ViewModels.ViewModels.SpecificationAttributeOption;
//using Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel.Advertisement;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.Owin;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;
//using Saudiceos.Enterprise.Web.Attributes;
//using Saudiceos.Enterprise.Web.helper;

//namespace Saudiceos.Enterprise.Web.Controllers
//{ 
//    public class CommercialAdsController : BaseController
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
//        private ICommercialAdService _commericalAdService;
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

//        public CommercialAdsController(IAdvertisementServices advertisementServices,
//            ICategoryServices categoryServices,
//            ICategory_SpecificationServices category_SpecificationAttributeServices,
//            IStateService stateService,
//            ICityServices cityServices,
//            //ApplicationUserManager userManager,
//            IUserInfoService userInfoService,
//            IFavoriteService favoriteService,
//            IAdvertisementImageServices advertisementImageServices,
//            ICommercialAdService commercialAdService,
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
//            _commericalAdService = commercialAdService;
//            _countryService = countryService;
//        }

//        #endregion

//        #region helper
//        #endregion

//        #region methods
//        #region Methods
//        /// <summary>
//        /// GetMainSliderAds
//        /// </summary>
//        /// <returns></returns> 
//        [HttpGet]
//        public async Task<ActionResult> GetMainSliderAds(int categoryId)
//        {
//            var countryDetails = _countryService.GetCountryByAbbr(country);

//            if (countryDetails != null)
//            {
//                var commercialAds = _commericalAdService.GetCommercialAdsByCountryMainSlider(countryDetails.CountryId);

//                return View(commercialAds);
//            }
//            return HttpNotFound();
//        }

//        /// <summary>
//        /// GetMainSliderAds
//        /// </summary>
//        /// <returns></returns> 
//        [ChildActionOnly]
//        [HttpGet] 
//        public async Task<ActionResult> GetPopUpAds(int categoryId)
//        {
//            var countryDetails = _countryService.GetCountryByAbbr(country);

//            if (countryDetails != null)
//            {
//                var commercialAds = _commericalAdService.GetCommercialAdsByCountryPopUp(countryDetails.CountryId);
//                return View(commercialAds);
//            }
//            return HttpNotFound();
//        }


//        #endregion
//        [HttpGet]
//        public ActionResult Index(PagingParams pagingParams, int categoryId = 0)
//        {
//            var countryDetails = _countryService.GetCountryByAbbr(country);

//            if (countryDetails != null)
//            {
//                var model = _commericalAdService.GetCommercialAdsByCountryOffers(countryDetails.CountryId, categoryId);

//                var categories = _categoryServices.GetCountryCategories(countryDetails.CountryId, true);
                 
//                ViewBag.CategoriesWithSub = categories; 
                 
//                ViewBag.Country = country;
                 
//                ViewBag.Language = language;
//                ViewBag.CatId = categoryId;

//                return View("Index2", model);
//            }

//            return HttpNotFound();
//        }
         
//        [HttpGet]
//        public ActionResult GetCommercialPopUp()
//        { 
//            var countryData = _countryService.GetCountryByAbbr(country);

//            if (countryData != null)
//            {
//                var commercialAds = _commericalAdService.GetCommercialAdsByCountryPopUp(countryData.CountryId);

//                if (commercialAds.Count() > 0)
//                {
//                    return Json(new
//                    {
//                        viewsCouns = commercialAds.ElementAt(0)?.ViewsCount,
//                        likes = commercialAds.ElementAt(0)?.Likes,
//                        link = commercialAds.ElementAt(0)?.Link,
//                        whatsapLink = commercialAds.ElementAt(0)?.WhatsappLink,
//                        instagramLink = commercialAds.ElementAt(0)?.InstagramLink,
//                        description = commercialAds.ElementAt(0)?.Description,
//                        image = commercialAds.ElementAt(0)?.SystemDataFile?.Url,
//                        id = commercialAds.ElementAt(0)?.Id
//                    }, JsonRequestBehavior.AllowGet);
//                }
//                else
//                {
//                    return null;
//                }

//            }
//            return HttpNotFound();
//        }

//        [HttpGet]
//        public ActionResult QuicCommercialkView(int id)
//        {
//            var result = _commericalAdService.IncrementViewCount(id);
//            var commercialAd = _commericalAdService.GetCommercialAdsById(id);
//            return PartialView(commercialAd);
//        }

//        #endregion
//        #region AJAX Calls

//        /// <summary>
//        /// LikeAd
//        /// </summary>
//        /// <returns></returns> 
//        [HttpGet]
//        [Authorize]
//        public async Task<ActionResult> LikeAd(int offerId)
//        {
//            var result = _commericalAdService.IncrementAdLikes(offerId, User.Identity.GetUserId());

//            return Json(result, JsonRequestBehavior.AllowGet);
//        }

//        /// <summary>
//        /// GetMainSliderAds
//        /// </summary>
//        /// <returns></returns> 
//        [HttpGet]
//        public async Task<ActionResult> ViewAd(int offerId)
//        {
//            var result = _commericalAdService.IncrementViewCount(offerId);

//            return Json(result, JsonRequestBehavior.AllowGet);
//        }

//        /// <summary>
//        /// Get Commercial Ad data
//        /// </summary>
//        /// <returns></returns> 
//        [HttpGet]
//        public async Task<ActionResult> GetCommAdData(int offerId)
//        {
//            var result = _commericalAdService.GetCommercialAdsById(offerId); 
//            if (result != null)
//            {
//                return Json(new
//                {
//                    viewsCouns = result.ViewsCount,
//                    likes = result.Likes,
//                    description = result.Description,
//                    image = result.SystemDataFile?.Url,
//                    id = result.Id
//                }, JsonRequestBehavior.AllowGet);
//            }
//            else
//            {
//                return null;
//            }
           
//        }
//        /// <summary>
//        /// Get Commercial Ad data
//        /// </summary>
//        /// <returns></returns> 
//        [HttpGet]
//        public async Task<ActionResult> GetCommAdByCategoryId(int categoryId, int pageNo = 1, int pageSize = 20)
//        {
//            var countrDetails = _countryService.GetCountryByAbbr(country);
//            var countryId = 0;
//            if (countrDetails != null )
//            {
//                countryId = countrDetails.CountryId;
//            }
//            var result = _commericalAdService.GetCommercialAdsByCountryOffers(countryId, categoryId, pageNo, pageSize);
//            if (result != null)
//            {
//                ViewBag.CategoryId = categoryId;
//                return PartialView(result);
//            }
//            else
//            {
//                return null;
//            }

//        }
//        #endregion
//    }
//}

//using AutoMapper;
//using Cigarette.Enterprise.BLL.AdvertisementServ;
//using Cigarette.Enterprise.BLL.Category_SpecificationServ;
//using Cigarette.Enterprise.BLL.CategoryServ;
//using Cigarette.Enterprise.BLL.CityServ;
//using Cigarette.Enterprise.BLL.CountryServ;
//using Cigarette.Enterprise.BLL.CustomHelpers;
//using Cigarette.Enterprise.BLL.FeaturedAdvertisementServ;
//using Cigarette.Enterprise.BLL.PaymentGatewayServ;
//using Cigarette.Enterprise.BLL.SettingsServ;
//using Cigarette.Enterprise.DAL.Repository.CountryRep;
//using Cigarette.Enterprise.ViewModels.BindingModels.Advertisement;
//using Cigarette.Enterprise.ViewModels.BindingModels.Advertisement_SpecificationAttribute;
//using Cigarette.Enterprise.ViewModels.BindingModels.WepAPIBindingModel.Advertisment;
//using Cigarette.Enterprise.ViewModels.Pagination;
//using Cigarette.Enterprise.ViewModels.ViewModels.Advertisement;
//using Cigarette.Enterprise.ViewModels.ViewModels.Category;
//using Cigarette.Enterprise.ViewModels.ViewModels.City;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.AspNet.Identity.Owin;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Threading.Tasks;
//using System.Web.Http;
//using Taswiq4U.Enterprise.WebApi.Helpers;
//using Taswiq4U.Enterprise.WebApi.Models;

//namespace Taswiq4U.Enterprise.WebApi.Controllers
//{
//    [Authorize]
//    [RoutePrefix("api/Featured")]
//    public class FeaturedAdvertisementController : ApiController
//    { 
//        #region Fields

//        public IAdvertisementServices _advertisementServices;
//        public ICategoryServices _categoryServices;
//        public ICategory_SpecificationServices _category_SpecificationAttributeServices;
//        public ICityServices _cityServices;
//        public ISettingsService _settingsService;
//        public ICountryService _countryService;
//        public IPaymentGatewayService _paymentService;

//        public IFeaturedAdvertisementService _featuredAdvertisementService;
//        public ApplicationUserManager _userManager;

//        private SettingsModel Settings = null;
//        public ApplicationUserManager UserManager
//        {
//            get
//            {
//                return _userManager ?? Request.GetOwinContext().GetUserManager<ApplicationUserManager>();
//            }
//            private set
//            {
//                _userManager = value;
//            }
//        }

//        #endregion

//        #region ctor

//        public FeaturedAdvertisementController(IPaymentGatewayService paymentService,ICountryService countryService, IAdvertisementServices advertisementServices,
//            ICategoryServices categoryServices,
//            ICategory_SpecificationServices category_SpecificationAttributeServices,
//            ICityServices cityServices,
//            ISettingsService settingsService,
//            IFeaturedAdvertisementService featuredAdvertisementService)
//        {
//            _paymentService = paymentService;
//            _countryService = countryService;
//            _advertisementServices = advertisementServices;
//            _categoryServices = categoryServices;
//            _category_SpecificationAttributeServices = category_SpecificationAttributeServices;
//            _cityServices = cityServices;
//            _settingsService = settingsService;
//            _featuredAdvertisementService = featuredAdvertisementService;


//            Settings =  _settingsService.GetSettings();
              
//            return; 
//        }

//        #endregion

//        #region methods

//        #region Set Ad Featured
//        [Route("SetAdFeatured")]
//        [HttpPost]
//        [Authorize]
//        public IHttpActionResult SetAdFeatuead([FromBody] FeaturedAdvertisementBM featuredAdvertisementBM)
//        {
//            if (ModelState.IsValid)
//            {
//                var country = _countryService.GetCountryById(UserManager.FindById(User.Identity.GetUserId()).CountryId.Value);

//                var featured = _featuredAdvertisementService.GetFeaturedAdvertisementsAdId( featuredAdvertisementBM.AdvertismentId);
                 
//                if (featured != null && featured.EndDate.Value > DateTime.Now)
//                    return BadRequest(ErrorCodes.Ins.AlreadyFeatured.Message($"Ad Id: {featured.AdvertismentId}").ToString());

//                var featuredEndTime = _featuredAdvertisementService.GetLastFeaturedAdvertismentByAdId(featuredAdvertisementBM.AdvertismentId);

//                if (featuredEndTime == null)
//                    featuredEndTime = DateTime.Now;

//                if (featuredEndTime - DateTime.Now > TimeSpan.FromDays(Settings.FeaturedAdsMaxWaitDays))
//                    return BadRequest(ErrorCodes.Ins.WaitingListFull.ToString());

//                var featuredAdvertisement = new FeaturedAdvertisementViewModel
//                { 
//                    Cost = country.FeaturedAdCost,
//                    AdvertismentId = featuredAdvertisementBM.AdvertismentId,
//                    PaymentTransactionId = featuredAdvertisementBM.PaymentTransactionId,
//                    UserId = User.Identity.GetUserId()
//                }; 

//                _featuredAdvertisementService.AddFeaturedAdvertisment(featuredAdvertisement, Settings.FeaturedPostDurationPerHour);

//                return Ok();
//            }
//            else
//            {
//                return BadRequest(ErrorCodes.Ins.AdNotFound.Message($"-adId {featuredAdvertisementBM.AdvertismentId}").ToString());
//            }
//        }
         
//        #endregion

//        #region Get Featured Ads
//        [Route("GetLastFeaturedAds")]
//        [HttpGet]
//        [Authorize]
//        public IHttpActionResult GetLastFeaturedAdsDays(int categoryId)
//        {
//            var featuredState = _featuredAdvertisementService.GetLastFeaturedAdvertisment(categoryId);
//            return Ok(featuredState);
//        }
//        #endregion

//        #region Get Featured Ads
//        [Route("GetUserFeaturedAds")]
//        [HttpGet]
//        [Authorize]
//        public IHttpActionResult GetUserFeaturedAds(int page = 1, int size = 10, OrderBy orderBy = OrderBy.Newest)
//        {
//            var userId = User.Identity.GetUserId();

//            var pagingParams = new PagingParams
//            {
//                Page = page,
//                Size = size
//            };

//            if (userId != null)
//            {
//                _featuredAdvertisementService.GetFeaturedAdvertisementsByUserId(userId, pagingParams, orderBy);
//                return Ok();
//            }
//            else
//            {
//                return BadRequest(ErrorCodes.Ins.UserNotFound.Code);
//            }
//        }

//        #endregion

//        #endregion
//    } 
//}
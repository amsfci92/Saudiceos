//using Cigarette.Enterprise.BLL.AdvertisementServ;
//using Cigarette.Enterprise.BLL.Category_SpecificationServ;
//using Cigarette.Enterprise.BLL.CategoryServ;
//using Cigarette.Enterprise.BLL.CityServ;
//using Cigarette.Enterprise.BLL.CustomHelpers;
//using Cigarette.Enterprise.BLL.SettingsServ;
//using Cigarette.Enterprise.DAL.Repository.CountryRep;
//using Cigarette.Enterprise.ViewModels.BindingModels.WepAPIBindingModel.Advertisment;
//using Cigarette.Enterprise.ViewModels.Pagination;
//using Cigarette.Enterprise.ViewModels.ViewModels.Advertisement;
//using Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel;
//using Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel.Advertisement;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using Swashbuckle.Swagger.Annotations;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity.Validation;
//using System.Linq;
//using System.Net;
//using System.Threading.Tasks;
//using System.Web.Http;
//using System.Web.Http.Description;
//using Taswiq4U.Enterprise.WebApi.Helpers;
//using Taswiq4U.Enterprise.WebApi.Models;

//namespace Taswiq4U.Enterprise.WebApi.Controllers
//{
//    /// <summary>
//    /// Ad Controller
//    /// </summary>
//    [RoutePrefix("api/Ads")]

//    public class AdvertisementController : ApiController
//    {
//        #region Fields

//        public IAdvertisementServices _advertisementServices;
//        public ICategoryServices _categoryServices;
//        public ICategory_SpecificationServices _category_SpecificationAttributeServices;
//        public ICityServices _cityServices;
//        public ISettingsService _settingsService;

//        private SettingsModel Settings = null;
//        private ApplicationUserManager UserManager;

//        #endregion

//        #region ctor 
//        public AdvertisementController(IAdvertisementServices advertisementServices,
//            ICategoryServices categoryServices,
//            ICategory_SpecificationServices category_SpecificationAttributeServices,
//            ICityServices cityServices,
//            ISettingsService settingsService)
//        {
//            _advertisementServices = advertisementServices;
//            _categoryServices = categoryServices;
//            _category_SpecificationAttributeServices = category_SpecificationAttributeServices;
//            _cityServices = cityServices;
//            _settingsService = settingsService;

//            UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>());

//            Settings = _settingsService.GetSettings();

//        }

//        #endregion

//        #region methods

//        #region Ad Details
//        [Route("AdDetails")]
//        [HttpGet]
//        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(AdvertisementVM))]
//        public async Task<IHttpActionResult> GetAdDetails(int adId)
//        {
//            var adDetails = _advertisementServices.GetAdvertisementById(adId);

//            if (adDetails == null)
//            {
//                return BadRequest(ErrorCodes.Ins.AdNotFound.ToString());
//            }

//            return Ok(adDetails);
//        }
//        #endregion
//        /// <summary>
//        /// Add Advertisment
//        /// </summary>
//        /// <param name="advertismentBM"></param>
//        /// <returns></returns>
//        #region Add Advertisment
//        [Authorize]
//        [Route("AddNewAdvertisment")]
//        [HttpPost]
//        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(bool))]

//        public async Task<IHttpActionResult> AddNewAdvertisment([FromBody] AddAdvertisementBM advertismentBM)
//        {
//            var availaleAdCount = _advertisementServices.HaveAdsalance(User.Identity.GetUserId());
//            // if (availaleAdCount <= 0)
//            //{
//            //    return BadRequest(ErrorCodes.Ins.AdBalanceFinished.ToString());
//            //}

//            if (ModelState.IsValid)
//            {
//                advertismentBM.UserId = User.Identity.GetUserId();
//                    advertismentBM.EnTitle = advertismentBM.Title;
//                    advertismentBM.ArTitle = advertismentBM.Title;
//                advertismentBM.ArabicDescription = advertismentBM.EnglishDescription;
//                try {
//                    _advertisementServices.AddAdvertisment(advertismentBM);
//                }
//                catch (DbEntityValidationException e)
//                {
//                    foreach (var eve in e.EntityValidationErrors)
//                    {
//                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
//                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
//                        foreach (var ve in eve.ValidationErrors)
//                        {
//                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
//                                ve.PropertyName, ve.ErrorMessage);
//                        }
//                    }

//                    return BadRequest(ErrorCodes.Ins.InvalidData.ToString());
//                }
//            }
//            else
//            {
//                return BadRequest(ErrorCodes.Ins.InvalidData.ToString());
//            }

//            return Ok();
//        }

//        #endregion

//        #region Get User Ad Count Balance
//        [Authorize]
//        [Route("GetUserAdBalance")]
//        [HttpPost]
//        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(int))]

//        public IHttpActionResult GetUserAdBalance()
//        {
//            var availaleAdCount = _advertisementServices.HaveAdsalance(User.Identity.GetUserId());
//            return Ok(availaleAdCount);
//        }
//        #endregion

//        /// <summary>
//        /// Edit Advertisment
//        /// </summary>
//        /// <param name="advertismentBM"></param>
//        /// <returns></returns>
//        #region Edit Advertisment
//        [Authorize]
//        [Route("EditAdvertisment")]
//        [HttpPost]
//        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(int))]
//        [SwaggerResponse(HttpStatusCode.BadRequest, Type = typeof(int))]
//        public async Task<IHttpActionResult> EditAdvertismnt([FromBody] AddAdvertisementBM advertismentBM)
//        {
//            if (ModelState.IsValid)
//            {
//                advertismentBM.UserId = User.Identity.GetUserId();

//                _advertisementServices.UpdateAdvertisement(advertismentBM);
//            }
//            else
//            {
//                return BadRequest(ErrorCodes.Ins.InvalidData.ToString());
//            }

//            return Ok();
//        }
//        #endregion

//        /// <summary>
//        /// Get Edit Ad From 
//        /// </summary>
//        /// <param name="adId"></param>
//        /// <returns></returns>
//        #region Get Edit Ad From 
//        [Route("EditAdvertismentForm/{adId}")]
//        [HttpGet] 
//        [Authorize]
//        public async Task<IHttpActionResult> EditAdvertismentForm(int adId)
//        {
//            var ad = _advertisementServices.GetAdvertisementForEditById(adId);

//            if (ad == null)
//            {
//                return BadRequest(ErrorCodes.Ins.AdNotFound.Code);
//            }
//            else
//            {
//                var adSpec = _category_SpecificationAttributeServices.GetCategorySpecificationsById(ad.CategoryId.Value);

//                for (int i = 0; i < ad.Advertisment_Specification.Count(); i++)
//                    AssignCurrentSpec(ad, adSpec, i);

//                var categorySpecefications = _category_SpecificationAttributeServices
//                    .GetCategorySpecificationsById(ad.CategoryId.Value);

//                return Ok(new
//                {
//                    AdData = ad,
//                    CategorySpecification = adSpec
//                });
//            }
//        }

//        private static void AssignCurrentSpec(AdvertisementVM ad, IEnumerable<CategorySpecificationVM> adSpec, int i)
//        {
//            var tempAdSpec = ad.Advertisment_Specification.ElementAt(i);

//            if (tempAdSpec.CustomValue != null)
//            {
//                var specAd = adSpec.FirstOrDefault(m => m.SpeceficationId == tempAdSpec.CategorySpecificationId);
//                specAd.Value = tempAdSpec.CustomValue;
//            }
//            else if (tempAdSpec.AdvertismentSpecificatioOptions.Count() > 0)
//                for (int j = 0; j < tempAdSpec.AdvertismentSpecificatioOptions.Count(); j++)
//                {
//                    var option = tempAdSpec.AdvertismentSpecificatioOptions.ElementAt(j);
//                    var specAd = adSpec.FirstOrDefault(m => m.Id == tempAdSpec.CategorySpecificationId);
//                    var specAdOption = specAd.SpecificationOptions.FirstOrDefault(m => m.Id == option.SpecificationOptionId);

//                    if (specAdOption != null)
//                      specAdOption.IsSelected = true;
//                }
//        }

//        #endregion

//        /// <summary>
//        ///  Add Advertisment Form
//        /// </summary>
//        /// <param name="catId"></param>
//        /// <returns></returns>
//        #region Add Advertisment Form
//        [Route("AddAdvertismentForm/{catId}")]
//        [HttpGet]
//        [AllowAnonymous]
//        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(IEnumerable<CategorySpecificationVM>))]
//        public async Task<IHttpActionResult> AddNewAdForm(int catId)
//        {
//            var category = _categoryServices.GetCategoryById(catId);

//            if (category == null)
//            {
//                return BadRequest(ErrorCodes.Ins.CategoryNotFound.ToString());
//            }
//            else
//            { 
//                var categorySpecefications = _category_SpecificationAttributeServices.GetCategorySpecificationsById(catId);
                 
//                return Ok(categorySpecefications);
//            }
//        }
     
//        #endregion
       
//        /// <summary>
//        /// Search Advertisment Form
//        /// </summary>
//        /// <param name="catId"></param>
//        /// <returns></returns>
//        #region Search Advertisment Form
//        [Route("SearchAdsForm/{catId}")]
//        [HttpGet] 
//        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(IEnumerable<CategorySpecificationForSearchVM>))]
//        [AllowAnonymous]
//        public async Task<IHttpActionResult> SearchAdsForm(int catId)
//        {
//            var category = _categoryServices.GetCategoryById(catId);

//            if (category == null)
//            {
//                return BadRequest(ErrorCodes.Ins.CategoryNotFound.ToString());
//            }
//            else
//            {
//                // get cat spec
//                // search spec between ads 
//                // put all spec in the same page

//                var categorySpecefications = _category_SpecificationAttributeServices.GetCategorySpecificationsForSearchById(catId);


//                return Ok(categorySpecefications);
//            }
//        }

//        #endregion


//        /// <summary>
//        /// My AAdvertisments
//        /// </summary>
//        /// <param name="Page"></param>
//        /// <param name="Size"></param>
//        /// <returns></returns>
//        #region My Advertisments 
//        [Route("GetMyAds")]
//        [Authorize]
//        [HttpGet] 
//        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(PagedList<CategorySpecificationForSearchVM>))]

//        public async Task<IHttpActionResult> GetMyAds(int Page =1, int Size = 10, OrderBy orderBy = OrderBy.Newest)
//        {
//            var userId = User.Identity.GetUserId();
            
//            var paging = new PagingParams
//            {
//                Size = Size,
//                Page = Page
//            }; 

//            var userAds = await _advertisementServices.GetAdvertisementsByUserId(userId, paging, orderBy);
            
//            return Ok(userAds); 
//        }

//        #endregion
         
//        /// <summary>
//        /// Get User Ads
//        /// </summary>
//        /// <param name="userId"></param>
//        /// <param name="Page"></param>
//        /// <param name="Size"></param>
//        /// <returns></returns>
//        #region Get User Advertisments 
//        [Route("GetUserAds")]
//        [HttpGet]
        
//        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(PagedList<AdvertisementListVM>))]

//        public async Task<IHttpActionResult> GetUserAds(string userId, int Page= 1, int Size = 10, OrderBy orderBy = OrderBy.Newest)
//        {
//            var user = await UserManager.FindByIdAsync(userId);

//            var paging = new PagingParams
//            {
//                Size = Size,
//                Page = Page
//            };

//            if (user == null)
//            {
//                return BadRequest(ErrorCodes.Ins.UserNotFound.Code);
//            }
//            else
//            {
//                var userAds = await _advertisementServices.GetAdvertisementsByUserId(user.Id, paging, orderBy);


//                return Ok(userAds);
//            }
//        }

//        #endregion

//        /// <summary>
//        /// Search With Params
//        /// </summary>
//        /// <param name="key"></param>
//        /// <param name="catId"></param>
//        /// <param name="searchParametersBMs"></param>
//        /// <param name="Page"></param>
//        /// <param name="Size"></param>
//        /// <returns></returns>
        
//        #region Search with params

//        [Route("SearchWithParams")]
//        [HttpPost]
//        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(AdvertisementWithCommercialAdsListVM))]
//        public async Task<IHttpActionResult> SearchWithParams(
//             [FromBody] AdvancedSearchMainModel searchParametersBMs,  int Page = 1, int Size = 10, OrderBy orderBy = OrderBy.Newest)
//        {
//            var paging = new PagingParams
//            {
//                Page = Page,
//                Size = Size
//            };

//            var outputModel = await _advertisementServices.AdvancedSearchAsync(searchParametersBMs, paging, orderBy, User.Identity.GetUserId());
            
//            return Ok(outputModel);
//        }
//        #endregion

//        /// <summary>
//        /// Search With Key
//        /// </summary>
//        /// <param name="key"></param>
//        /// <param name="Page"></param>
//        /// <param name="Size"></param>
//        /// <param name="orderBy"></param>
//        /// <returns></returns>
//        #region SearchWith Key
//        [Route("SearchWithKeys")]
//        [HttpPost]
//        [SwaggerResponse(HttpStatusCode.OK, Type = typeof(AdvertisementWithCommercialAdsListVM))]
//        public IHttpActionResult SearchWithKeys(string key, int countryId,  int? Page = 1, int? Size = 10,OrderBy orderBy = OrderBy.Newest)
//        {
//            var paging = new PagingParams();
//            paging.Page = Page.Value;
//            paging.Size = Size.Value;

//            var result = _advertisementServices.KeySearch(key, countryId, paging, orderBy, User.Identity.GetUserId());
             
//            return Ok(result);
//        }
    
//        #endregion
      
//       #endregion
//    } 
    
//}
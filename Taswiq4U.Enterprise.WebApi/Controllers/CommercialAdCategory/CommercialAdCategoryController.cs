//using Cigarette.Enterprise.BLL.CategoryServ;
//using Cigarette.Enterprise.BLL.CommercialAdServ;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Http; 

//namespace Taswiq4U.Enterprise.WebApi.Controllers.CommercialAdCategory
//{
//    [RoutePrefix("api/CommercialAdCategory")]
//    public class CommercialAdCategoryController : ApiController
//    {
//        #region Fields
//        private ICategoryServices _categoryService;
//        private ICommercialAdService _commercialAdService;

//        #endregion

//        #region Ctor
//        public CommercialAdCategoryController(ICategoryServices categoryServices,
//            ICommercialAdService commercialAdService)
//        {
//            _categoryService = categoryServices;
//            _commercialAdService = commercialAdService;
//        }
//        #endregion

//        #region Methods
//        /// <summary>
//        /// Get All Commercial ads Country Category
//        /// </summary>
//        /// <returns></returns>
//        [Route("GetAllCountryCategory")]
//        [HttpGet]
//        public async Task<IHttpActionResult> GetCommercialAdsCountryCategories(int countryId)
//        {
//            var categories = _categoryService.GetCountryCategories(countryId);

//            return Ok(categories);
//        }
         
//        #endregion

//    }
//}
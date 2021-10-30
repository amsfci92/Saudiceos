//using Cigarette.Enterprise.BLL.CategoryServ;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Http; 

//namespace Taswiq4U.Enterprise.WebApi.Controllers.Category
//{
//    [RoutePrefix("api/category")]
//    public class CategoryController : ApiController
//    {
//        #region Fields
//        private ICategoryServices _categoryService;

//        #endregion

//        #region Ctor
//        public CategoryController(ICategoryServices categoryServices)
//        {
//            _categoryService = categoryServices;
//        }
//        #endregion

//        #region Methods
//        /// <summary>
//        /// Get All Country Category
//        /// </summary>
//        /// <returns></returns>
//        [Route("MainCategories")]
//        [HttpGet]
//        public IHttpActionResult GetCountryCategories(int countryId, bool isCom = false)
//        {
//            var categories = _categoryService.GetCountryCategories(countryId, isCom);

//            return Ok(categories);
//        }


//        /// <summary>
//        /// Get Sub Categories
//        /// </summary>
//        /// <returns></returns>
//        [Route("SubCategories")]
//        [HttpGet]
//        public IHttpActionResult GetSubCategories(int mainCategoryId)
//        {
//            var categories = _categoryService.GetSubCategories(mainCategoryId);

//            return Ok(categories);
//        }

//        #endregion

//    }
//}
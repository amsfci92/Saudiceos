//using Cigarette.Enterprise.BLL.AdvertisementServ;
//using Cigarette.Enterprise.ViewModels.BindingModels.WepAPIBindingModel.Advertisment;
//using Cigarette.Enterprise.ViewModels.Pagination;
//using Cigarette.Enterprise.ViewModels.ViewModels.Advertisement;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Http; 

//namespace Taswiq4U.Enterprise.WebApi.Controllers
//{
//    public class SearchController : ApiController
//    {

//        #region Fields
//        private IAdvertisementServices _advertismentService;
//        #endregion

//        #region Ctor
//        public SearchController(IAdvertisementServices advertismentService)
//        {
//            _advertismentService = advertismentService;
//        }

//        #endregion
         
         
       
//        ///// <summary>
//        ///// Search With Key
//        ///// </summary>
//        ///// <returns></returns>
//        //[Route("SeachWithParams")]
//        //[HttpPost]
//        //public async Task<IHttpActionResult> SeachWithParams(string key,
//        //    int catId, [FromBody] List<AdvancedSearchParametersBM> searchParametersBMs, int? Page = 1, int? Size = 10)
//        //{
//        //    var paging = new PagingParams();
//        //    paging.Page = Page.Value;
//        //    paging.Size = Size.Value;

//        //    var result = _advertismentService.AdvancedSearch(key, searchParametersBMs, paging);

//        //    //Response.Headers.Add("X-Pagination", database.GetHeader().ToJson());

//        //    var outputModel = new AdvertisementSearchOutputModel
//        //    {
//        //        Paging = result.GetHeader(),
//        //        //Links = _paginationExtention.GetLinksForAdvSearch(database, "AdvSearch", cityId, Term),
//        //        //LinksNumbers = _paginationExtention.GetLinksNumbersForAdvSearch(database, "AdvSearch", cityId, Term),
//        //        Items = result.List.ToList(),
//        //    };

//        //    return Ok(outputModel);
//        //}
//        //#endregion
//        ///// <summary>
//        ///// Search With Parameters
//        ///// </summary>
//        ///// <returns></returns>
         

//    }
//}

using Cigarette.Enterprise.BLL.NewsServ;
using Cigarette.Enterprise.BLL.ReportServ;
using Cigarette.Enterprise.DAL;
using Cigarette.Enterprise.Extentions.ExtentionMethods.HttpFileBase;
using Cigarette.Enterprise.ViewModels.ViewModels.CommercialAd;
using Cigarette.Enterprise.ViewModels.VM.Report;
using Microsoft.AspNet.Identity; 
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Taswiq4U.Enterprise.WebApi.CustomAttribute;

namespace Saudiceos.Enterprise.WebApi.Controllers
{
    [APIKeyAuthorize]
    [RoutePrefix("api/news")]
    [EnableCors("*", "*", "*")]
    public class NewsController : ApiController
    {
        #region Fields
        private INewsService _newsService;

        #endregion

        #region Ctor 
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }
        #endregion

        #region Methods  
        [HttpGet]
        [Route("")]
        public IHttpActionResult List(int pageNo = 1, int pageSize = 10)
        {
            var reports = _newsService.GetAllPaged(pageSize, pageNo);
            return Ok(new
            {
                Data = reports.Data.Select(m => new
                {
                    m.Id,
                    m.Description,
                    Image = $"/Content/Data/News/images/{m.imageUrl}",
                    m.Note,
                    m.Title,
                    m.CreateDate,
                    m.Tags
                }).ToList(),
                reports.Data.HasNextPage,
                reports.Data.IsFirstPage,
                reports.Data.IsLastPage,
                reports.Data.Count,
                reports.Data.TotalItemCount,
                reports.Data.PageNumber,
                reports.Data.PageSize,
            });
        }
        [HttpGet]
        [Route("details/{id}")]
        public IHttpActionResult Details(long id)
        {
            var m = _newsService.Get(id);
            if (m == null)
                return NotFound();
            _newsService.IncreaseCount(id);
            return Ok(new
            {
                m.Id,
                m.Description,
                Image = $"/Content/Data/News/images/{m.imageUrl}",
                m.Note,
                m.Title,
                m.CreateDate,
                m.Tags,
            });
        } 
        #endregion

        #region Helpers

        #endregion
    }
}

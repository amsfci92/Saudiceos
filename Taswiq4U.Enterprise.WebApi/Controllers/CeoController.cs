
using Cigarette.Enterprise.BLL.CEOAddEditRequestServ;
using Cigarette.Enterprise.BLL.CEOServ;
using Cigarette.Enterprise.BLL.ReportServ;
using Cigarette.Enterprise.DAL;
using Cigarette.Enterprise.Extentions.ExtentionMethods.HttpFileBase;
using Cigarette.Enterprise.ViewModels.ViewModels.CommercialAd;
using Cigarette.Enterprise.ViewModels.VM.CEO;
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
    [RoutePrefix("api/ceo")]
    [EnableCors("*", "*", "*")]
    public class CeoController : ApiController
    {
        #region Fields
        private ICEOService _ceoService;
        private ICEOAddEditRequestService _cEOAddEditRequestService;

        #endregion

        #region Ctor 
        public CeoController(ICEOService ceoService, ICEOAddEditRequestService cEOAddEditRequestService)
        {
            _ceoService = ceoService;
            _cEOAddEditRequestService = cEOAddEditRequestService;
        }
        #endregion

        #region Methods  
     
        [HttpGet]
        [Route("")]
        public IHttpActionResult List(int pageNo = 1, int pageSize = 10, string searchText = "")
        {
            var reports = _ceoService.GetAllPaged(pageSize, pageNo, searchText);
            return Ok(new
            {
                Data = reports.Data.Select(m => new
                {
                    m.Id,
                    Image = $"/Content/Data/Ceo/images/{m.ImageUrl}",
                    m.Company,
                    m.CreatedDate,
                    m.CVDescription,
                    m.CVNote,
                    m.ImageUrl,
                    m.LinkedIn,
                    m.Name, 
                    m.Twitter,
                    m.Position, 
                    m.Email
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
        public IHttpActionResult Detail(long id)
        {
            var ceo = _ceoService.Get(id);
            if (ceo == null)
                return NotFound();

            _ceoService.IncreaseCount(id);

            return Ok( new {
               ceo.Id,
               Image = $"/Content/Data/Ceo/images/{ ceo.ImageUrl}",
               CVUrl = ceo.CVUrl != null ? $"/Content/Data/Ceo/File/{ ceo.CVUrl}" : "", 
               ceo.Company,
               ceo.CreatedDate,
               ceo.CVDescription,
               ceo.CVNote,
               ceo.ImageUrl,
               ceo.LinkedIn,
               ceo.Name,
               ceo.SnapChat,
                ceo.Twitter,
                ceo.Position,
                ceo.Email,
                CeoNews = ceo.News == null ? null : ceo.News.Select(news => new
                {
                    news.Id,
                    news.Description,
                    Image = $"/Content/Data/News/images/{news.imageUrl}",
                    news.Note,
                    news.Title,
                    news.CreateDate,
                    news.Tags
                })
            });

        }
        [HttpPost]
        [Route("updaterequest")]
        public IHttpActionResult NewUpdateRequest(CEOAddEditRequestVM ceo)
        {   
            if (!ModelState.IsValid)
            {
                return BadRequest("Please specify the required fields");
            }

            if (ceo.CEOId == null || ceo.CEOId == 0)
            {
                return BadRequest("Ceo is missed");
            }

            var ceoDetails = _ceoService.Get(ceo.CEOId.Value);
            if (ceoDetails == null)
            {
                return BadRequest("Ceo is missed");
            }

            var cntact = new CEOAddEditRequest
            {
                Email = ceo.Email,
                CEOId = ceo.CEOId,
                Name = ceo.Name,
                Phone = ceo.Phone,
                NationalIdImageUrl = ceo.NationalIDImageUrl,
                CVDescription = ceo.CVDescription,
                Position = ceo.Position,
                ImageUrl = ceo.ImageUrl,
                DateCreated = DateTime.Now,
                CVUrl = ceo.CVUrl
            };

            _cEOAddEditRequestService.Add(cntact);
             
            return Ok();
        }

        [HttpPost]
        [Route("addrequest")]
        public IHttpActionResult NewAddRequest(CEOAddEditRequestVM ceo)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Please specify the required fields");
            }

            if (ceo.CEOId != null || ceo.CEOId == 0)
            {
                return BadRequest("Ceo not needed");
            }
             
            if (ceo.CVUrl == null)
            {
                return BadRequest("CV is missed");
            }

            var cntact = new CEOAddEditRequest
            {
                Email = ceo.Email,  
                Name = ceo.Name,
                NationalIdImageUrl = ceo.NationalIDImageUrl,
                Phone = ceo.Phone,
                CVDescription = ceo.CVDescription,
                Position = ceo.Position,
                ImageUrl = ceo.ImageUrl,
                DateCreated = DateTime.Now,
                CVUrl = ceo.CVUrl
            };

            _cEOAddEditRequestService.Add(cntact);

            return Ok();
        }
        //[HttpGet]
        //public ActionResult AdsListByType(int countryId, int type)
        //{
        //    var ads = _commercialAdService.GetCommercialAdsByType(countryId, type);
        //    return PartialView("Partials/_offerAdsList", ads);
        //}

        //[Authorize(Roles = "CountryAdmin")]
        //[HttpGet]
        //public ActionResult CountryList()
        //{
        //    var userId = User.Identity.GetUserId();
        //    var countryId = _countryAdminService.AdminCountryId(userId);
        //    ViewBag.CountryId = countryId;
        //    return View("CountryList");
        //}

        //// GET: AdminPanel/Ads/Details/5
        //public ActionResult Details(int id)
        //{
        //    var model = _commercialAdService.GetCommercialAdsById(id);
        //    return View("AdsDetails", model);
        //}

        //// GET: AdminPanel/Ads/Create
        //public ActionResult New()
        //{
        //    var countries = _countryService.GetCountries();
        //    if (User.IsInRole("CountryAdmin"))
        //    {
        //        var userId = User.Identity.GetUserId();
        //        var countryId = _countryAdminService.AdminCountryId(userId);
        //        ViewBag.CountryId = new SelectList(countries, "CountryId", "ArabicDescription", countryId);
        //    }
        //    else
        //    {
        //        ViewBag.CountryId = new SelectList(countries, "CountryId", "ArabicDescription");
        //    }
        //    return View("AddAds");
        //}

        //// POST: AdminPanel/Ads/Create
        //[HttpPost]
        //public ActionResult New(CommercialAdBM bm)
        //{
        //    try
        //    {
        //        bm.CategoryId = bm.CategoryId1;

        //        var countries = _countryService.GetCountries();
        //        ViewBag.CountryId = new SelectList(countries, "CountryId", "ArabicDescription");

        //        if (!ModelState.IsValid && bm.CategoryId1 == null)
        //        {
        //            return View("AddAds", bm);
        //        }

        //        if (bm.CategoryId1 == 0)
        //        {
        //            bm.CategoryId = null;
        //            ModelState.AddModelError("", "يجب اختيار التصنيف المناسب للدوله");
        //            return View("AddAds", bm);
        //        }
        //        var res = _commercialAdService.AddCommertialAd(bm);
        //        if (res != 0)
        //        {
        //            if (User.IsInRole("Admin"))
        //                return RedirectToAction("List");
        //            else
        //                return RedirectToAction("CountryList");
        //        }
        //        else
        //        {

        //            ModelState.AddModelError("", "حدث خطاء");
        //            return View("AddAds", bm);
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        ModelState.AddModelError("", "حدث خطاء");
        //        return View("AddAds", bm);
        //    }
        //}


        //// GET: AdminPanel/Ads/Edit/5
        //public ActionResult Edit(int id)
        //{
        //    var countries = _countryService.GetCountries();
        //    ViewBag.CountryId = new SelectList(countries, "CountryId", "ArabicDescription");

        //    var model = _commercialAdService.GetCommercialAdsBindingModel(id);
        //    model.CategoryId1 = model.CategoryId;
        //    model.OldCategoryId = (int)model.CategoryId;
        //    model.OldCountryId = (int)model.CountryId;

        //    return View("EditAds", model);
        //}

        //// POST: AdminPanel/Ads/Edit/5
        //[HttpPost]
        //public ActionResult Edit(CommercialAdBM bm)
        //{
        //    try
        //    {
        //        var countries = _countryService.GetCountries();
        //        ViewBag.CountryId = new SelectList(countries, "CountryId", "ArabicDescription");
        //        bm.Category = _categoryServices.GetCategoryById((int)bm.CategoryId1);
        //        if (!ModelState.IsValid)
        //            return View("EditAds", bm);

        //        if (bm.CategoryId1 != 0)
        //        {
        //            bm.CategoryId = bm.CategoryId1;
        //        }
        //        else
        //        {
        //            bm.CategoryId = bm.OldCategoryId;
        //            if (bm.OldCountryId != bm.CountryId && bm.CategoryId == bm.OldCategoryId)
        //            {
        //                bm.CategoryId = null;
        //                ModelState.AddModelError("", "يجب اختيار التصنيف المناسب للدوله");
        //                return View("EditAds", bm);
        //            }
        //        }

        //        if (bm.CategoryId1 == 0)
        //        {
        //            bm.CategoryId = null;
        //            ModelState.AddModelError("", "يجب اختيار التصنيف المناسب للدوله");
        //            return View("EditAds", bm);
        //        }

        //        _commercialAdService.EditCommertialAd(bm);

        //        if (User.IsInRole("Admin"))
        //            return RedirectToAction("List");
        //        else
        //            return RedirectToAction("CountryList");
        //        //return View("EditAds", bm);
        //    }
        //    catch (Exception e)
        //    {
        //        ModelState.AddModelError("", "حدث خطاء");
        //        return View("EditAds", bm);
        //    }
        //}

        //// GET: AdminPanel/Ads/Delete/5
        //[HttpGet]
        //public JsonResult Delete(int id)
        //{
        //    var res = _commercialAdService.InActivateCommertialAd(id);
        //    if (res == true)
        //        return Json("Success", JsonRequestBehavior.AllowGet);
        //    else
        //        return Json("Failed", JsonRequestBehavior.AllowGet);
        //}

        //// POST: AdminPanel/Ads/Delete/5
        //[HttpPost]
        //public ActionResult Delete(int id, FormCollection collection)
        //{
        //    try
        //    {
        //        //INBetween - Slider - Offer --Popup
        //        // TODO: Add delete logic here

        //        return RedirectToAction("Index");
        //    }
        //    catch
        //    {
        //        return View();
        //    }
        //}
        #endregion

        #region Helpers

        #endregion
    }
}

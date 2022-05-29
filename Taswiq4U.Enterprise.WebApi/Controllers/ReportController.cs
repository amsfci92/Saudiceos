﻿
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
    [RoutePrefix("api/report")]
    [APIKeyAuthorize]
    [EnableCors("*", "*", "*")]
    public class ReportController : ApiController
    {
        #region Fields
        private IReportService _reportService;

        #endregion

        #region Ctor 
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }
        #endregion

        #region Methods 
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("")]
        public IHttpActionResult List(int pageNo = 1, int pageSize = 10)
        {
            var reports = _reportService.GetAllPaged(pageSize, pageNo);
            return Ok(new
            {
                Data = reports.Data.Select(m => new
                {
                    m.Id,
                    m.Title,
                    m.DateCreated,
                    m.Description,
                    Image = $"/Content/Data/Report/images/{m.ImageUrl}",
                    File = $"/Content/Data/Report/File/{m.FileUrl}",
                    m.IssueDate,
                    Link = m.Issuer,
                    m.SocialShare,
                    m.Type,
                    m.PublishDate,
                    
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
            var report = _reportService.Get(id);

            if (report == null)
                return NotFound();

            return Ok(new {
                report.Id,
                report.Title,
                report.DateCreated,
                report.Description,
                Image = $"/Content/Data/Report/images/{report.ImageUrl}",
                File = $"/Content/Data/Report/File/{report.FileUrl}",
                report.IssueDate,
                Link = report.Issuer,
                report.SocialShare,
                report.Type,
                report.PublishDate,
            });
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

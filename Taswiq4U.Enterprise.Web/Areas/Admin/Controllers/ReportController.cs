
using Cigarette.Enterprise.BLL.ReportServ;
using Cigarette.Enterprise.DAL;
using Cigarette.Enterprise.Extentions.ExtentionMethods.HttpFileBase;
using Cigarette.Enterprise.ViewModels.ViewModels.CommercialAd;
using Cigarette.Enterprise.ViewModels.VM.Report;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saudiceos.Enterprise.Web.Areas.Admin.Controllers
{ 
    [RouteArea("Admin")]
    [RoutePrefix("report")]
    [Authorize()]
    public class ReportController : BaseController
    {
        #region Fields
        private IReportService _reportService ; 

        #endregion

        #region Ctor
        public ReportController(IReportService reportService)
        {
            _reportService = reportService;
        }
        #endregion

        #region Methods  
        [HttpGet]
        [Route("all")]
        public ActionResult List()
        {
            var reports = _reportService.GetAll(); 
            return View("reportsList", reports);
        }
        [Route("View/{encodedId}")]
        public ActionResult Details(string encodedId)
        {
            var id = GetId(encodedId);
            if (id == 0)
            {
                return HttpNotFound();
            }
            var model = _reportService.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View("Details", model);
        }
       
        [Route("new")]
        public ActionResult New()
        {
            var model = new ReportVM();
            return View("Add", model);
        }

        [Route("new")]
        [HttpPost]
        public ActionResult New(ReportVM vm)
        {
            if (!ModelState.IsValid)
                return View("Add", vm);

            var news = new Report
            {
                ImageUrl = vm.ImageUrl,
                Description = vm.Description,
                Title = vm.Title,
                IssueDate = vm.IssueDate,
                Issuer = vm.Issuer,
                SocialShare = vm.SocialShare,
                PublishDate = vm.PublishDate,
                Type = vm.Type,
                FileUrl = vm.FileUrl, 
                DateCreated = DateTime.Now, 
                
            };

            _reportService.Add(news);
            if (news.ImageUrl != null)
                SaveImageThenClearTemp(news.ImageUrl, ImageType.Report);

            if (news.FileUrl != null)
                SaveFileThenClearTemp(news.FileUrl, FileType.Report);

            SetSuccessMessage("تم الحفظ بنجاح");
            return RedirectToAction("List");
        }

        [Route("edit/{encodedId}")]
        public ActionResult Edit(string encodedId)
        {
            var id = GetId(encodedId);
            if (id == 0)
            {
                return HttpNotFound();
            }
            var model = _reportService.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            var vm = new ReportVM
            {
                Id = model.Id,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                Title = model.Title,
                IssueDate = model.IssueDate,
                Issuer = model.Issuer,
                SocialShare = model.SocialShare,
                PublishDate = model.PublishDate,
                Type = model.Type,
                FileUrl = model.FileUrl
            };

            if (vm.ImageUrl != null)
                SaveImageToTemp(vm.ImageUrl, ImageType.Report);

            if (vm.FileUrl != null)
                SaveFileToTemp(vm.FileUrl, FileType.Report);

            return View("Edit", vm);
        }

        [Route("edit")]
        [HttpPost]
        public ActionResult Edit(ReportVM vm)
        {
            if (!ModelState.IsValid)
                return View("Edit", vm);

            var model = new Report
            {
                Id = vm.Id,
                ImageUrl = vm.ImageUrl,
                Description = vm.Description,
                Title = vm.Title,
                IssueDate = vm.IssueDate,
                Issuer = vm.Issuer,
                SocialShare = vm.SocialShare,
                PublishDate = vm.PublishDate,
                Type = vm.Type,
                FileUrl = vm.FileUrl
            };

            var result = _reportService.Edit(model);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "لم يتم التحديث حاول مره اخري");
                return View("Edit", vm);

            }
            if(model.ImageUrl != null)
                SaveImageThenClearTemp(model.ImageUrl, ImageType.Report);
            if (model.FileUrl != null)
                SaveFileThenClearTemp(model.FileUrl, FileType.Report);

            SetSuccessMessage("تم الحفظ بنجاح");
            return RedirectToAction("List");
        }

        [Route("del/{encodedIds}")]
        public ActionResult Delete(string encodedIds)
        {
            var ids = GetIds(encodedIds);
            if (ids.Count() == 0)
            {
                return Json(new { deleted = false }, JsonRequestBehavior.AllowGet);
            }

            var result = _reportService.DeleteRange(ids);
            return Json(new { deleted = result }, JsonRequestBehavior.AllowGet);
        } 
        #endregion

        #region Helpers

        #endregion
    }
}

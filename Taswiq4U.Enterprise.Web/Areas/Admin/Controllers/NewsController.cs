
using Cigarette.Enterprise.BLL.CEOServ;
using Cigarette.Enterprise.BLL.NewsServ;
using Cigarette.Enterprise.DAL;
using Cigarette.Enterprise.Extentions.ExtentionMethods.HttpFileBase;
using Cigarette.Enterprise.ViewModels.ViewModels.CommercialAd;
using Cigarette.Enterprise.ViewModels.VM.CEO;
using Cigarette.Enterprise.ViewModels.VM.News;
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
    [RoutePrefix("news")]
    [Authorize()]
    public class NewsController : BaseController
    {
        #region Fields
        private INewsService _newsService ;
        private ICEOService _ceoService;

        #endregion

        #region Ctor
        public NewsController(INewsService newsService,
           ICEOService ceoService)
        {
            _newsService = newsService;
            _ceoService = ceoService;
        }
        #endregion

        #region Methods 
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("all")]
        public ActionResult List()
        {
            var news = _newsService.GetAll(); 
            return View("newsList", news);
        }
        [Route("View/{encodedId}")]
        public ActionResult Details(string encodedId)
        {
            var id = GetId(encodedId);
            if (id == 0)
            {
                return HttpNotFound();
            }
            var model = _newsService.Get(id);
            
            if (model == null)
            {
                return HttpNotFound();
            }

            return View("Details", model);
        }

        [Route("new")]
        public ActionResult New()
        {
            var model = new NewsVM
            {
                CeoList = _ceoService.GetAllCeos()
            };
            return View("Add", model);
        }

        [Route("new")]
        [HttpPost]
        public ActionResult New(NewsVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.CeoList = _ceoService.GetAllCeos();
                return View("Add", vm);
            }

            var news = new News
            {
                Note = vm.Note,
                Description = vm.Description,
                Title = vm.Title,
                imageUrl = vm.imageUrl,
                Active = (vm.Active ?? false),
                CreateDate = DateTime.Now,
                CeoId = vm.CeoId,
                Views = 0,
            };

            _newsService.Add(news);
            SaveImageThenClearTemp(news.imageUrl, ImageType.News);

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
            var model = _newsService.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            var vm = new NewsVM
            {
                Id = model.Id,
                Note = model.Note,
                Description = model.Description,
                Title = model.Title,
                imageUrl = model.imageUrl,
                CreateDate = model.CreateDate,
                Views = model.Views,
                CeoId = model.CeoId,
                Active = model.Active,
                CeoList = _ceoService.GetAllCeos()
            };

            if (vm.imageUrl != null)
                SaveImageToTemp(vm.imageUrl, ImageType.News);

            return View("Edit", vm);
        }

        [Route("edit")]
        [HttpPost]
        public ActionResult Edit(NewsVM vm)
        {
            if (!ModelState.IsValid)
            {
                vm.CeoList = _ceoService.GetAllCeos();
                return View("Edit", vm);
            }

            var model = new News
            {
                Id = vm.Id,
                Note = vm.Note,
                Description = vm.Description,
                Title = vm.Title,
                imageUrl = vm.imageUrl,
                CreateDate = vm.CreateDate,
                Views = vm.Views,
                Active = vm.Active,
                CeoId = vm.CeoId
            };

            var result = _newsService.Edit(model);
            if (result == 0)
            {
                ModelState.AddModelError("", "لم يتم التحديث حاول مره اخري");
                vm.CeoList = _ceoService.GetAllCeos();

                return View("Edit", vm);

            }
            SaveImageThenClearTemp(model.imageUrl, ImageType.News);

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
            
            var result = _newsService.DeleteRange(ids);
            return Json(new { deleted = result }, JsonRequestBehavior.AllowGet);
        } 
        #endregion

        #region Helpers

        #endregion
    }
}

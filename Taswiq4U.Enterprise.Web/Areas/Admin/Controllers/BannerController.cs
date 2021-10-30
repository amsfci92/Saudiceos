
using Cigarette.Enterprise.BLL.BannerServ; 
using Cigarette.Enterprise.DAL;
using Cigarette.Enterprise.Extentions.ExtentionMethods.HttpFileBase;
using Cigarette.Enterprise.ViewModels.ViewModels.CommercialAd;
using Cigarette.Enterprise.ViewModels.VM.Banner;
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
    [RoutePrefix("banner")]
    [Authorize()]
    public class BannerController : BaseController
    {
        #region Fields
        private IBannerService _bannerService ; 

        #endregion

        #region Ctor
        public BannerController(IBannerService bannerService)
        {
            _bannerService = bannerService;
        }
        #endregion

        #region Methods 
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("all")]
        [Authorize(Roles = Permissions.Banner_ViewAll)]

        public ActionResult List()
        {
            var banners = _bannerService.GetAll(); 
            return View("bannersList", banners);
        }

        [Route("View/{encodedId}")]
        [Authorize(Roles = Permissions.Banner_ViewAll)]

        public ActionResult Details(string encodedId)
        {
            var id = GetId(encodedId);
            if (id == 0)
            {
                return HttpNotFound();
            }
            var model = _bannerService.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View("Details", model);
        }

        [Route("new")]
        [Authorize(Roles = Permissions.Banner_ADD)]

        public ActionResult New()
        {
            var model = new BannerVM();
            return View("Add", model);
        }

        [Route("new")]
        [HttpPost]
        [Authorize(Roles = Permissions.Banner_ADD)]

        public ActionResult New(BannerVM vm)
        {
            if (!ModelState.IsValid)
                return View("Add", vm);

            var news = new Banner
            {
                ImageUrl = vm.ImageUrl,
                Description = vm.Description,
                Title = vm.Title,
                AdPlace = vm.AdPlace,
                Link = vm.Link,   
                Keywords = vm.Keywords,
                Advertiser = vm.Advertiser,
                Type = vm.Type,
                CreatedDate = DateTime.Now, 
                Active = vm.Active
            };

            _bannerService.Add(news);
            if (news.ImageUrl != null)
                SaveImageThenClearTemp(news.ImageUrl, ImageType.Banner);

            SetSuccessMessage("تم الحفظ بنجاح");
            return RedirectToAction("List");
        }

        [Route("edit/{encodedId}")]
        [Authorize(Roles = Permissions.Banner_Update)]

        public ActionResult Edit(string encodedId)
        {
            var id = GetId(encodedId);
            if (id == 0)
            {
                return HttpNotFound();
            }

            var model = _bannerService.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            var vm = new BannerVM
            {
                Id = model.Id,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                Title = model.Title,
                Link = model.Link,
                Active = model.Active, 
                AdPlace = model.AdPlace, 
                CreatedDate = model.CreatedDate
            };

            if (vm.ImageUrl != null)
                SaveImageToTemp(vm.ImageUrl, ImageType.Banner);

            return View("Edit", vm);
        }

        [Route("edit")]
        [HttpPost]
        [Authorize(Roles = Permissions.Banner_Update)]

        public ActionResult Edit(BannerVM vm)
        {
            if (!ModelState.IsValid)
                return View("Edit", vm);

            var model = new Banner
            {
                Id = vm.Id,
                ImageUrl = vm.ImageUrl,
                Description = vm.Description,
                Title = vm.Title,
                Link = vm.Link,
                AdPlace = vm.AdPlace,
                Active = vm.Active,  
                CreatedDate = vm.CreatedDate
            };

            var result = _bannerService.Edit(model);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "لم يتم التحديث حاول مره اخري");
                return View("Edit", vm); 
            }
            if (model.ImageUrl != null)
                SaveImageThenClearTemp(model.ImageUrl, ImageType.Banner);

            SetSuccessMessage("تم الحفظ بنجاح");
            return RedirectToAction("List");
        }

        [Route("del/{encodedIds}")]
        [Authorize(Roles = Permissions.Banner_Delete)]

        public ActionResult Delete(string encodedIds)
        {
            var ids = GetIds(encodedIds);
            if (ids.Count() == 0)
            {
                return Json(new { deleted = false }, JsonRequestBehavior.AllowGet);
            }

            var result = _bannerService.DeleteRange(ids);
            return Json(new { deleted = result }, JsonRequestBehavior.AllowGet);
        } 
        #endregion

        #region Helpers

        #endregion
    }
}

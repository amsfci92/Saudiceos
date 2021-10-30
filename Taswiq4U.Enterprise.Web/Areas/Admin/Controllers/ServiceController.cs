
using Cigarette.Enterprise.BLL.ReportServ;
using Cigarette.Enterprise.BLL.ServiceServ;
using Cigarette.Enterprise.DAL;
using Cigarette.Enterprise.Extentions.ExtentionMethods.HttpFileBase;
using Cigarette.Enterprise.ViewModels.ViewModels.CommercialAd;
using Cigarette.Enterprise.ViewModels.VM.Report;
using Cigarette.Enterprise.ViewModels.VM.Service;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Saudiceos.Enterprise.Web.Areas.Admin.Controllers
{ 
    [RouteArea("admin")]
    [RoutePrefix("service")]
    public class ServiceController : BaseController
    {
        #region Fields
        private IServiceService _serviceService ;  

        #endregion

        #region Ctor
        public ServiceController(IServiceService serviceService)
        {
            _serviceService = serviceService;
        }
        #endregion

        #region Methods 
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("all")]
        public ActionResult List()
        {
            var reports = _serviceService.GetAll(); 
            return View("servicesList", reports);
        }
        [Route("View/{encodedId}")]
        public ActionResult Details(string encodedId)
        {
            var id = GetId(encodedId);
            if (id == 0)
            {
                return HttpNotFound();
            }
            var model = _serviceService.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            var vm = new ServiceVM { ImageUrl = model.ImageUrl };
            vm.SetImagersNames();
            ViewBag.Images = vm;
            return View("Details", model);
        }
       
        [Route("new")]
        public ActionResult New()
        {
            var model = new ServiceVM();
                var categories = _serviceService.GetAllCategoriesPaged();
            if (categories.Succeeded)
            {
                model.Categories = categories.Data.ToList();
            }
            return View("Add", model);
        }

        [Route("new")]
        [HttpPost]
        public ActionResult New(ServiceVM vm)
        {
            var categories = _serviceService.GetAllCategoriesPaged();
            if (categories.Succeeded)
            {
                vm.Categories = categories.Data.ToList();
            }
            if (!ModelState.IsValid)
                return View("Add", vm); 

            var news = new Service
            {
                CategoryId = vm.CategoryId,
                ImageUrl = vm.GetImagesNames(),
                Description = vm.Description,
                Title = vm.Title,
                Link = vm.Link,
                Code = vm.Code, 
                LogoUrl = vm.LogoUrl,
                Active = vm.Active,
                DateCreated = DateTime.Now, 
            };

            _serviceService.Add(news);

            if (vm.Image1 != null)
                SaveImageThenClearTemp(vm.Image1, ImageType.Service);
            if (vm.Image2 != null)
                SaveImageThenClearTemp(vm.Image2, ImageType.Service);
            if (vm.Image3 != null)
                SaveImageThenClearTemp(vm.Image3, ImageType.Service);
            if (vm.Image4 != null)
                SaveImageThenClearTemp(vm.Image4, ImageType.Service);

            if (news.LogoUrl != null)
                SaveImageThenClearTemp(news.LogoUrl, ImageType.Service);

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
            var model = _serviceService.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            var vm = new ServiceVM
            {
                Id = model.Id,  
                CategoryId = model.CategoryId,
                ImageUrl = model.ImageUrl,
                Description = model.Description,
                Title = model.Title,
                Code = model.Code,
                Link = model.Link,           
                LogoUrl = model.LogoUrl,
                Active = model.Active??false,
                DateCreated = model.DateCreated
            };
            var categories = _serviceService.GetAllCategoriesPaged();
            if (categories.Succeeded)
            {
                vm.Categories = categories.Data.ToList();
            }
            vm.SetImagersNames();

            if (vm.Image1 != null)
                SaveImageToTemp(vm.Image1, ImageType.Service);
            if (vm.Image2 != null)
                SaveImageToTemp(vm.Image2, ImageType.Service);
            if (vm.Image3 != null)
                SaveImageToTemp(vm.Image3, ImageType.Service);
            if (vm.Image4 != null)
                SaveImageToTemp(vm.Image4, ImageType.Service);

            if (vm.LogoUrl != null)
                SaveImageToTemp(vm.LogoUrl, ImageType.Service);

            return View("Edit", vm);
        }

        [Route("edit")]
        [HttpPost]
        public ActionResult Edit(ServiceVM vm)
        {
            var categories = _serviceService.GetAllCategoriesPaged();
            if (categories.Succeeded)
            {
                vm.Categories = categories.Data.ToList();
            }
            if (!ModelState.IsValid)
                return View("Edit", vm);

            var model = new Service
            {
                Id = vm.Id,
                LogoUrl = vm.LogoUrl,
                ImageUrl = vm.GetImagesNames(),
                Description = vm.Description,
                Title = vm.Title,
                Code = vm.Code,
                CategoryId = vm.CategoryId,
                Link = vm.Link,
                Active = vm.Active,
                DateCreated = vm.DateCreated
            };

            var result = _serviceService.Edit(model);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "لم يتم التحديث حاول مره اخري");
                return View("Edit", vm);

            }
            if (vm.Image1 != null)
                SaveImageThenClearTemp(vm.Image1, ImageType.Service);
            if (vm.Image2 != null)
                SaveImageThenClearTemp(vm.Image2, ImageType.Service);
            if (vm.Image3 != null)
                SaveImageThenClearTemp(vm.Image3, ImageType.Service);
            if (vm.Image4 != null)
                SaveImageThenClearTemp(vm.Image4, ImageType.Service);
            if (model.LogoUrl != null)
                SaveImageThenClearTemp(model.LogoUrl, ImageType.Service);


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

            var result = _serviceService.DeleteRange(ids);
            return Json(new { deleted = result }, JsonRequestBehavior.AllowGet);
        }
        [Route("delcat")]
        public ActionResult DeleteCat(long id)
        {  
            var result = _serviceService.DeleteCategory(id);
            return Json(new { deleted = result.Succeeded }, JsonRequestBehavior.AllowGet);
        }
        [Route("addcategory")]
        [HttpPost]
        public ActionResult AddCategory(CategoryVM vm)
        {
            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            var cat = new Category
            {
                ImageUrl = vm.ImageUrl, 
                Name = vm.Name, 
                CreationDate = DateTime.Now,
            };

            _serviceService.AddCategory(cat);

            if (cat.ImageUrl != null)
                SaveImageThenClearTemp(cat.ImageUrl, ImageType.Service);

            return new HttpStatusCodeResult(System.Net.HttpStatusCode.OK);
        }

        [Route("cats")]
        [HttpGet]
        public ActionResult GetAllACats()
        { 
            var result = _serviceService.GetAllCategoriesPaged(100);
            return PartialView("_Categories", result.Data.ToList()); 
        }

        #endregion

        #region Helpers

        #endregion
    }
}

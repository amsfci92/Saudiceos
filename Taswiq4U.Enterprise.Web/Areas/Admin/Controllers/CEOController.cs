﻿
using Cigarette.Enterprise.BLL.CEOAddEditRequestServ;
using Cigarette.Enterprise.BLL.CEOServ;
using Cigarette.Enterprise.DAL;
using Cigarette.Enterprise.Extentions.ExtentionMethods.HttpFileBase;
using Cigarette.Enterprise.ViewModels.ViewModels.CommercialAd;
using Cigarette.Enterprise.ViewModels.VM.CEO;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace Saudiceos.Enterprise.Web.Areas.Admin.Controllers
{ 
    [RouteArea("Admin")]
    [RoutePrefix("ceo")]
    [Authorize()]
    public class CEOController : BaseController
    {
        #region Fields
        private ICEOService _ceoService ;
        private ICEOAddEditRequestService _addEditService;
        #endregion

        #region Ctor
        public CEOController(ICEOService ceoService, ICEOAddEditRequestService addEditService)
        {
            _ceoService = ceoService;
            _addEditService = addEditService;
        }
        #endregion

        #region Methods  
        [HttpGet]
        [Route("all")]
        [Authorize(Roles = Permissions.CEO_ViewAll)]

        public ActionResult List()
        {
            var ceos = _ceoService.GetAllCeos(); 
            return View("ceosList", ceos);
        }

        [Route("View/{encodedId}")]
        [Authorize(Roles = Permissions.CEO_ViewAll)]

        public ActionResult Details(string encodedId)
        {
            var id = GetId(encodedId);
            if (id == 0)
            {
                return HttpNotFound();
            }
            var model = _ceoService.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            
            return View("Details", model);
        }

        [HttpGet]
        [Route("updaterequests")]
        [Authorize(Roles = Permissions.CEO_ViewUpdateRequests)]

        public ActionResult RequestList()
        {
            var ceos = _addEditService.GetAll(); 
            var editRequests = ceos.Where(m => m.CEOId != null).ToList();
            return View("ceosUpdateList", editRequests);
        }

        [HttpGet]
        [Route("addrequests")]
        [Authorize(Roles = Permissions.CEO_ViewAddRequests)]

        public ActionResult RequestAddList()
        {
            var ceos = _addEditService.GetAll(); 
            var addRequests = ceos.Where(m => m.CEOId == null).ToList();
            return View("ceosAddList", addRequests);
        }

        [Route("ViewRequest/{encodedId}")]
        [Authorize(Roles = Permissions.CEO_ViewAll)]

        public ActionResult RequestDetails(string encodedId)
        {
            var id = GetId(encodedId);
            if (id == 0)
            {
                return HttpNotFound();
            }
            var model = _addEditService.Get(id);
            if (!model.Succeeded)
            {
                return HttpNotFound();
            }
            if (!string.IsNullOrWhiteSpace(model.Data.ImageUrl))
                SaveImageToTemp(model.Data.ImageUrl, ImageType.CeoAPI, ImageType.Ceo, ImageType.CeoAPI);

            if (!string.IsNullOrWhiteSpace(model.Data.CVUrl))
                SaveFileToTemp(model.Data.CVUrl, FileType.CeoAPI, FileType.Ceo, FileType.CeoAPI);

            return View("updateDetails", model.Data);
        }

        [Route("new")]
        [Authorize(Roles = Permissions.CEO_ADD)]

        public ActionResult New(long addRequestId = 0)
        {
            var updateRequest = _addEditService.Get(addRequestId);

            var ceoVm = new CEOVM();
            if (updateRequest.Succeeded)
            { 
                ceoVm = new CEOVM
                {
                    Name = updateRequest.Data.Name, 
                    Position = updateRequest.Data.Position,
                    Email = updateRequest.Data.Email,
                    CVDescription = updateRequest.Data.CVDescription,
                    CVUrl = updateRequest.Data.CVUrl,
                    ImageUrl = updateRequest.Data.ImageUrl,
                };
          
                if (!string.IsNullOrWhiteSpace(updateRequest.Data.ImageUrl))
                    SaveImageToTemp(updateRequest.Data.ImageUrl, ImageType.CeoAPI, ImageType.Ceo, ImageType.Ceo);

                if (!string.IsNullOrWhiteSpace(updateRequest.Data.CVUrl))
                    SaveFileToTemp(updateRequest.Data.CVUrl, FileType.CeoAPI, FileType.Ceo, FileType.Ceo);
            }
            return View("Add", ceoVm);
        }

        [Route("new")]
        [HttpPost]
        [Authorize(Roles = Permissions.CEO_ADD)]
        public ActionResult New(CEOVM ceoVm)
        {
            if (!ModelState.IsValid)
                return View("Add", ceoVm);

            var ceo = new CEO
            {
                Name = ceoVm.Name,
                Position = ceoVm.Position,
                Email = ceoVm.Email,
                Company = ceoVm.Company,
                Active = ceoVm.Active,
                CVNote = ceoVm.CVNote,
                CVDescription = ceoVm.CVDescription,
                CVUrl = ceoVm.CVUrl,
                ImageUrl = ceoVm.ImageUrl,
                LinkedIn = ceoVm.LinkedIn,
                Location = ceoVm.Location,
                SnapChat = ceoVm.SnapChat,
                Twitter = ceoVm.Twitter,
                Views = 0,
                CreatedDate = DateTime.Now,
            };

            _ceoService.Add(ceo);
            if(ceo.ImageUrl != null)
                SaveImageThenClearTemp(ceo.ImageUrl, ImageType.Ceo);

            if (ceo.CVUrl != null)
                SaveFileThenClearTemp(ceo.CVUrl, FileType.Ceo);

            SetSuccessMessage("تم الحفظ بنجاح");
            return RedirectToAction("List");
        }

        [Route("edit/{encodedId}")]
        [Authorize(Roles = Permissions.CEO_Update)]
        public ActionResult Edit(string encodedId, long updateRequestId = 0)
        {
            var id = GetId(encodedId);
            if (id == 0)
            {
                return HttpNotFound();
            }

            var updateRequest = _addEditService.Get(updateRequestId);
            var model = _ceoService.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            var ceoVm = new CEOVM
            {
                Id = model.Id,
                Name = updateRequest.Succeeded ? updateRequest.Data.Name : model.Name,
                Position = updateRequest.Succeeded ? updateRequest.Data.Position : model.Position,
                Email = updateRequest.Succeeded ? updateRequest.Data.Email : model.Email,
                Company = model.Company,
                Active = model.Active,
                CVNote =   model.CVNote,
                CVDescription = updateRequest.Succeeded ? updateRequest.Data.CVDescription : model.CVDescription,
                CVUrl = updateRequest.Succeeded ? (!string.IsNullOrWhiteSpace(updateRequest.Data.CVUrl) ?
                updateRequest.Data.CVUrl : model.CVUrl) : model.CVUrl,
                ImageUrl = updateRequest.Succeeded ? (!string.IsNullOrWhiteSpace(updateRequest.Data.ImageUrl) ? 
                updateRequest.Data.ImageUrl : model.ImageUrl) : model.ImageUrl,
                LinkedIn = model.LinkedIn,
                Location = model.Location,
                SnapChat = model.SnapChat,
                Twitter = model.Twitter,
                Views = model.Views,
                CreatedDate = model.CreatedDate
            };

            if (updateRequest.Succeeded)
            {
                if (!string.IsNullOrWhiteSpace(updateRequest.Data.ImageUrl))
                    SaveImageToTemp(updateRequest.Data.ImageUrl, ImageType.CeoAPI, ImageType.Ceo, ImageType.Ceo);

                if (!string.IsNullOrWhiteSpace(updateRequest.Data.CVUrl))
                    SaveFileToTemp(updateRequest.Data.CVUrl, FileType.CeoAPI, FileType.Ceo, FileType.Ceo);
            }
            else
            {
                if (!string.IsNullOrWhiteSpace(ceoVm.ImageUrl))
                    SaveImageToTemp(ceoVm.ImageUrl, ImageType.Ceo);

                if (!string.IsNullOrWhiteSpace(ceoVm.CVUrl))
                    SaveFileToTemp(ceoVm.CVUrl, FileType.Ceo);
            }
           
            return View("Edit", ceoVm);
        }

        [Route("edit")]
        [HttpPost]
        [Authorize(Roles = Permissions.CEO_Update)]

        public ActionResult Edit(CEOVM ceoVm)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", ceoVm);
            }

            var ceo = new CEO
            {
                Id = ceoVm.Id,
                Name = ceoVm.Name,
                Position = ceoVm.Position,
                Email = ceoVm.Email,
                Company = ceoVm.Company,
                Active = ceoVm.Active,
                CVNote = ceoVm.CVNote,
                CVDescription = ceoVm.CVDescription,
                CVUrl = ceoVm.CVUrl,
                ImageUrl = ceoVm.ImageUrl,
                LinkedIn = ceoVm.LinkedIn,
                Location = ceoVm.Location,
                SnapChat = ceoVm.SnapChat,
                Twitter = ceoVm.Twitter,
                Views = ceoVm.Views,
                CreatedDate = ceoVm.CreatedDate
            };

            var result = _ceoService.Edit(ceo);
            if (result == 0)
            {
                ModelState.AddModelError("", "لم يتم التحديث حاول مره اخري");
                return View("Edit", ceoVm);
            }

            if (ceo.ImageUrl != null)
                SaveImageThenClearTemp(ceo.ImageUrl, ImageType.Ceo);

            if (ceo.CVUrl != null)
                SaveFileThenClearTemp(ceo.CVUrl, FileType.Ceo);

            SetSuccessMessage("تم الحفظ بنجاح");
            return RedirectToAction("List");
        }

        [Route("del/{encodedIds}")]
        [Authorize(Roles = Permissions.CEO_Delete)]

        public ActionResult Delete(string encodedIds)
        {
            var ids = GetIds(encodedIds);
            if (ids.Count() == 0)
            {
                return Json(new { deleted = false }, JsonRequestBehavior.AllowGet);
            }

            var result = _ceoService.DeleteRange(ids);
            return Json(new { deleted = result }, JsonRequestBehavior.AllowGet);
        }

        [Route("delupdate/{encodedIds}")]
        [Authorize(Roles = Permissions.CEO_Delete)]

        public ActionResult DeleteUpdate(string encodedIds)
        {
            var ids = GetIds(encodedIds);
            if (ids.Count() == 0)
            {
                return Json(new { deleted = false }, JsonRequestBehavior.AllowGet);
            }

            var result =  _addEditService.DeleteRange(ids);
            return Json(new { deleted = result }, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region Helpers

        #endregion
    }
}

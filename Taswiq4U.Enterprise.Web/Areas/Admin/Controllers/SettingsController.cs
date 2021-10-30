
using Cigarette.Enterprise.BLL.CEOServ;
using Cigarette.Enterprise.BLL.NewsServ;
using Cigarette.Enterprise.BLL.SettingsServ;
using Cigarette.Enterprise.DAL;
using Cigarette.Enterprise.Extentions.ExtentionMethods.HttpFileBase;
using Cigarette.Enterprise.ViewModels.ViewModels.CommercialAd;
using Cigarette.Enterprise.ViewModels.VM.CEO;
using Cigarette.Enterprise.ViewModels.VM.News;
using Cigarette.Enterprise.ViewModels.VM.Settings;
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
    [RoutePrefix("settings")]
    [Authorize()]
    public class SettingsController : BaseController
    {
        #region Fields
        private ISettingsService _settingsService ;

        #endregion

        #region Ctor
        public SettingsController(ISettingsService settingsService )
        {
            _settingsService = settingsService; 
        }
        #endregion

        #region Methods 
        //[Authorize(Roles = "Admin")]
        [HttpGet]
        [Route("update")]  
        public ActionResult Edit( )
        { 
            var model = _settingsService.GetSettings();
            if (model == null)
            {
                return HttpNotFound();
            }
            var vm = new SettingsVM
            {
                Id = model.Id,
                SiteDescription = model.SiteDescription,
                Address = model.Address,
                FooterSentence = model.FooterSentence,
                GoogleMaps = model.GoogleMaps,
                GoogleAnalytics = model.GoogleAnalytics,
                Mobile = model.Mobile,
                Phone = model.Phone,
                ShareCode = model.ShareCode,
                SiteEmail = model.SiteEmail,
                SiteFacebook = model.SiteFacebook,
                SiteFax = model.SiteFax,
                SiteFlicker = model.SiteFlicker,
                SiteKeywords = model.SiteKeywords,
                SiteGoogle = model.SiteGoogle,
                SiteInstagram = model.SiteInstagram,
                SiteLinkedIn = model.SiteLinkedIn,
                SiteName = model.SiteName,
                SiteTwitter = model.SiteTwitter,
                SiteViemo = model.SiteViemo,
            }; 

            return View("Edit", vm);
        }

        [Route("")]
        [HttpPost]
        public ActionResult Edit(SettingsVM model)
        {
            if (!ModelState.IsValid)
            {
                return View("Edit", model);
            }

            var db = new Setting
            {
                Id = model.Id,
                SiteDescription = model.SiteDescription,
                Address = model.Address,
                FooterSentence = model.FooterSentence,
                GoogleMaps = model.GoogleMaps,
                GoogleAnalytics = model.GoogleAnalytics,
                Mobile = model.Mobile,
                Phone = model.Phone,
                ShareCode = model.ShareCode,
                SiteEmail = model.SiteEmail,
                SiteFacebook = model.SiteFacebook,
                SiteFax = model.SiteFax,
                SiteFlicker = model.SiteFlicker,
                SiteKeywords = model.SiteKeywords,
                SiteGoogle = model.SiteGoogle,
                SiteInstagram = model.SiteInstagram,
                SiteLinkedIn = model.SiteLinkedIn,
                SiteName = model.SiteName,
                SiteTwitter = model.SiteTwitter,
                SiteViemo = model.SiteViemo,
            };

            var result = _settingsService.Update(db);
            if (!result.Succeeded)
            {
                ModelState.AddModelError("", "لم يتم التحديث حاول مره اخري"); 

                return View("Edit", model);

            }
            SetSuccessMessage("تم الحفظ بنجاح");
            return RedirectToAction("Edit");
        }
        [Route("tdm")]
        public ActionResult ToggleDarkMode(int darkMode, string returnUrl)
        {

            var cookie = Request.Cookies["darkMode"];
 
            if (cookie != null && cookie.Value != null)
            {
                Request.Cookies.Remove("darkMode");
            } 
                HttpCookie newcookie = new HttpCookie("darkMode");
                newcookie.Value = darkMode == 1 ? "Yes" : "No";
                Response.Cookies.Add(newcookie);

            return RedirectPermanent(returnUrl);
        }
            #endregion

            #region Helpers

            #endregion
        }
}

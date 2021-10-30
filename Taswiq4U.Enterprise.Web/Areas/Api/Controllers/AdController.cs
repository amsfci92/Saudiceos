//using AutoMapper;
//using Cigarette.Enterprise.BLL.AdvertisementServ;
//using Cigarette.Enterprise.BLL.Category_SpecificationServ;
//using Cigarette.Enterprise.BLL.CategoryServ;
//using Cigarette.Enterprise.BLL.CityServ;
//using Cigarette.Enterprise.BLL.CustomHelpers;
//using Cigarette.Enterprise.BLL.SettingsServ;
//using Cigarette.Enterprise.ViewModels.BindingModels.WepAPIBindingModel.Advertisment;
//using Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel;
//using Cigarette.Enterprise.ViewModels.ViewModels.WepAPIViewModel.Advertisement;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using OperationManager.Translation;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity.Validation;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Web;
//using System.Web.Mvc;
//using Saudiceos.Enterprise.Web.Models;

//namespace Saudiceos.Enterprise.Web.Areas.Api.Controllers
//{
//    public class AdController : Controller
//    {

//        #region Fields

//        public IAdvertisementServices _advertisementServices;
//        public ICategoryServices _categoryServices;
//        public ICategory_SpecificationServices _category_SpecificationAttributeServices;
//        public ICityServices _cityServices;
//        public ISettingsService _settingsService;

//        private SettingsModel Settings = null;
//        private ApplicationUserManager UserManager;
//        private GoogleTranslator translator;
//        #endregion

//        #region ctor 
//        public AdController(IAdvertisementServices advertisementServices,
//            ICategoryServices categoryServices,
//            ICategory_SpecificationServices category_SpecificationAttributeServices,
//            ICityServices cityServices,
//            ISettingsService settingsService)
//        {
//            _advertisementServices = advertisementServices;
//            _categoryServices = categoryServices;
//            _category_SpecificationAttributeServices = category_SpecificationAttributeServices;
//            _cityServices = cityServices;
//            _settingsService = settingsService;

//            UserManager = new ApplicationUserManager(new UserStore<ApplicationUser>());

//            Settings = _settingsService.GetSettings();

            

//        }

//        #endregion
//        /// <summary>
//        /// Edit Advertisment
//        /// </summary>
//        /// <param name="advertismentBM"></param>
//        /// <returns></returns>
//        #region Edit Advertisment
//        [Authorize]
//        [Route("EditAdvertisment")]
//        [HttpPost] 
//        public JsonResult EditAdvertismnt(AddAdvertisementWebBM advertismentBM)
//        {
//            translator = GoogleTranslator.Instance(Server.MapPath("/"));
//            try
//            {

//                if (ModelState.IsValid)
//                {
//                    advertismentBM.UserId = User.Identity.GetUserId();
//                    advertismentBM.CountryId = int.Parse(User.Identity.GetCountryId());
//                    var mapped = Mapper.Map<AddAdvertisementBM>(advertismentBM);
//                    mapped.EnglishDescription = translator.TranslateArabic(mapped.Title);
//                    mapped.EnglishDescription = translator.TranslateArabic(mapped.ArabicDescription);
//                    var adId = _advertisementServices.UpdateAdvertisement(mapped);

//                    return Json(new
//                    {
//                        status = true,
//                        id = adId
//                    });
//                }
//            }
//            catch (DbEntityValidationException e)
//            {
//                foreach (var eve in e.EntityValidationErrors)
//                {
//                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
//                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
//                    foreach (var ve in eve.ValidationErrors)
//                    {
//                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
//                            ve.PropertyName, ve.ErrorMessage);
//                    }
//                }
//                throw;
//            }
//            return Json(new
//            {
//                status = false,
//                advertismentBM
//            });
//        }
//        #endregion

//        [Authorize] 
//        [HttpPost]
//        public JsonResult AddAdvertismnt(AddAdvertisementWebBM advertismentBM)
//        {
//            translator = GoogleTranslator.Instance(Server.MapPath("/"));
//            try
//            {

//                if (ModelState.IsValid)
//                {
//                    advertismentBM.UserId = User.Identity.GetUserId();
//                    advertismentBM.CountryId = int.Parse(User.Identity.GetCountryId());  
//                    var mapped = Mapper.Map<AddAdvertisementBM>(advertismentBM);

//                    mapped.EnTitle= translator.TranslateArabic(mapped.Title);
//                    mapped.EnglishDescription = translator.TranslateArabic(mapped.ArabicDescription);

//                    var adId = _advertisementServices.AddAdvertisment(mapped);

//                    return Json(new
//                    {
//                        status = true,
//                        id = adId
//                    });
//                }
//            }
//            catch (DbEntityValidationException e)
//            {
//                foreach (var eve in e.EntityValidationErrors)
//                {
//                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
//                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
//                    foreach (var ve in eve.ValidationErrors)
//                    {
//                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
//                            ve.PropertyName, ve.ErrorMessage);
//                    }
//                }
//                throw;
//            }
//            return Json(new
//            {
//                status = false,
//                advertismentBM
//            });
//        }
//        /// <summary>
//        /// Get Edit Ad From 
//        /// </summary>
//        /// <param name="adId"></param>
//        /// <returns></returns>
//        #region Get Edit Ad From 
//        [Route("EditAdvertismentForm/{adId}")]
//        [HttpGet]
//        [Authorize]
//        public JsonResult EditAdvertismentForm(int adId)
//        {
//            var ad = _advertisementServices.GetAdvertisementForEditById(adId);

//            if (ad == null)
//            {
//                return Json(new { 
//                    status = false
//                }, JsonRequestBehavior.AllowGet);
//            }
//            else
//            {
//                var adSpec = _category_SpecificationAttributeServices.GetCategorySpecificationsById(ad.CategoryId.Value);

//                for (int i = 0; i < ad.Advertisment_Specification.Count(); i++)
//                    AssignCurrentSpec(ad, adSpec, i);

//                var categorySpecefications = _category_SpecificationAttributeServices
//                    .GetCategorySpecificationsById(ad.CategoryId.Value);

//                return Json(new
//                {
//                    status = true,
//                    AdData = ad,
//                    CategorySpecification = adSpec
//                }, JsonRequestBehavior.AllowGet);
//            }
//        }

//        private static void AssignCurrentSpec(AdvertisementVM ad, IEnumerable<CategorySpecificationVM> adSpec, int i)
//        {
//            var tempAdSpec = ad.Advertisment_Specification.ElementAt(i);

//            if (tempAdSpec.CustomValue != null)
//            {
//                var specAd = adSpec.FirstOrDefault(m => m.SpeceficationId == tempAdSpec.CategorySpecificationId);
//                specAd.Value = tempAdSpec.CustomValue;
//            }
//            else if (tempAdSpec.AdvertismentSpecificatioOptions.Count() > 0)
//                for (int j = 0; j < tempAdSpec.AdvertismentSpecificatioOptions.Count(); j++)
//                {
//                    var option = tempAdSpec.AdvertismentSpecificatioOptions.ElementAt(j);
//                    var specAd = adSpec.FirstOrDefault(m => m.Id == tempAdSpec.CategorySpecificationId);
//                    var specAdOption = specAd.SpecificationOptions.FirstOrDefault(m => m.Id == option.SpecificationOptionId);

//                    if (specAdOption != null)
//                        specAdOption.IsSelected = true;
//                }
//        }

//        #endregion

//        public ActionResult index()
//        {
//            return View();
//        }

//    }
//}

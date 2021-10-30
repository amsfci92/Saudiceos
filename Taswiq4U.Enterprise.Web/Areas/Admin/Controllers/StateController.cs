//using Cigarette.Enterprise.BLL.CityServ;
//using Cigarette.Enterprise.BLL.CountryServ;
//using Cigarette.Enterprise.BLL.StateServ;
//using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.State;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace Saudiceos.Enterprise.Web.Areas.AdminPanel.Controllers
//{
//    [Authorize(Roles = "Admin,CountryAdmin")]
//    public class StateController : Controller
//    {
//        ICountryService countryService;
//        ICityServices cityService;
//        IStateService stateService;
//        public StateController(ICountryService countryService,
//            ICityServices cityServices,
//            IStateService stateService)
//        {
//            this.countryService = countryService;
//            this.cityService = cityServices;
//            this.stateService = stateService;
//        }
//        // GET: AdminPanel/State
//        public ActionResult Index()
//        {
//            return View();
//        }


//        [HttpGet]
//        public ActionResult AddState(int cityId = 1)
//        {
//            var city = cityService.GetCitiesWithCountry().SingleOrDefault(x=>x.Id==cityId);
//            var model = new AddStateAdminBindingModel();
//            model.CountryId = city.CountryId;
//            model.CityId = cityId;
//            if ( city==null)
//                return HttpNotFound();
//            ViewBag.Country = city.Country;
//            ViewBag.City = city;
//            return View(model);
//        }

//        [HttpPost]
//        public ActionResult AddState(AddStateAdminBindingModel addStateAdminBindingModel)
//        {
//            var city = cityService.GetCitiesWithCountry().SingleOrDefault(x => x.Id == addStateAdminBindingModel.CityId);
//            ViewBag.Country = city.Country;
//            ViewBag.City = city;
//            if (!ModelState.IsValid)
//            {
//                if (city == null)
//                    return HttpNotFound();
//                return View(addStateAdminBindingModel);
//            }

//            addStateAdminBindingModel.isActive = true;
//            addStateAdminBindingModel.IsDeleted = false;
//            addStateAdminBindingModel.IsUpdated = false;
//            addStateAdminBindingModel.UpdateDate = DateTime.Now;
//            addStateAdminBindingModel.CreatoinTime = DateTime.Now;
//            stateService.AddState(addStateAdminBindingModel);
//            var add = true;
//            if (!add)
//            {
//                if (city == null)
//                    return HttpNotFound();
//                return View(addStateAdminBindingModel);
//            }

//            return Redirect(string.Format("/Admin/City/CityDetails/{0}", addStateAdminBindingModel.CityId));
//        }

//        [HttpGet]
//        public ActionResult EditState(int stateId)
//        {
//            var model = stateService.GetBindingModelState(stateId);
//            return View(model);
//        }

//        [HttpPost]
//        public ActionResult EditState(AddStateAdminBindingModel addStateAdminBindingModel)
//        {
//            if (!ModelState.IsValid)
//            {
//                return View(addStateAdminBindingModel);
//            }
//            addStateAdminBindingModel.UpdateDate = DateTime.Now;
//            addStateAdminBindingModel.IsUpdated = true;
//            stateService.EditState(addStateAdminBindingModel);
//            return Redirect(string.Format("/Admin/City/CityDetails/{0}", addStateAdminBindingModel.CityId));
//        }

//        [HttpGet]
//        public JsonResult Delete(int stateId)
//        {
//            var res = stateService.Delete(stateId);
//            if (res == true)
//                return Json("Success", JsonRequestBehavior.AllowGet);
//            else
//                return Json("Failed", JsonRequestBehavior.AllowGet);
//        }

//    }
//}
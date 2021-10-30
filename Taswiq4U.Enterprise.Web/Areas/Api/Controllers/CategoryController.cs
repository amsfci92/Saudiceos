//using Cigarette.Enterprise.BLL.CategoryServ;
//using Cigarette.Enterprise.DAL.Repository.AdvertisementRep;
//using Cigarette.Enterprise.DAL.Repository.CategoryRep;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;

//namespace Saudiceos.Enterprise.Web.Areas.Api.Controllers
//{
//    public class CategoryController : Controller
//    {
//        #region Fields
//        private ICategoryServices _categoryService; 
//        #endregion

//        #region Ctor
//        public CategoryController(ICategoryServices categoryServices)
//        {
//            _categoryService = categoryServices;
//        }
//        #endregion

//        #region Methods
//        // GET: Api/Category
//        [HttpGet]
//        public ActionResult GetSubCategoriesList(int id, bool all = false)
//        {
//            var categoryList = _categoryService.GetSubCategories(id, all, true);
//            return Json(categoryList, JsonRequestBehavior.AllowGet);
//        }

//        #endregion


         
//        // GET: Api/Category/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: Api/Category/Create
//        [HttpPost]
//        public ActionResult Create(FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add insert logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: Api/Category/Edit/5
//        public ActionResult Edit(int id)
//        {
//            return View();
//        }

//        // POST: Api/Category/Edit/5
//        [HttpPost]
//        public ActionResult Edit(int id, FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add update logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }

//        // GET: Api/Category/Delete/5
//        public ActionResult Delete(int id)
//        {
//            return View();
//        }

//        // POST: Api/Category/Delete/5
//        [HttpPost]
//        public ActionResult Delete(int id, FormCollection collection)
//        {
//            try
//            {
//                // TODO: Add delete logic here

//                return RedirectToAction("Index");
//            }
//            catch
//            {
//                return View();
//            }
//        }
//    }
//}

//using AutoMapper;
//using Cigarette.Enterprise.BLL.ProductServ;
//using Cigarette.Enterprise.DAL;
//using Cigarette.Enterprise.ViewModels.Pagination;
//using Cigarette.Enterprise.ViewModels.ViewModels.Product;
//using Microsoft.AspNet.Identity;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using Saudiceos.Enterprise.Web.helper;

//namespace Saudiceos.Enterprise.Web.Controllers
//{
    
//    public class ProductController : Controller
//    {
//        #region Fields

//        public IProductServices _productServices;
//        private PaginationExtention _paginationExtention;

//        #endregion



//        #region ctor

//        public ProductController(IProductServices productServices)
//        {
//            _productServices = productServices;
//            _paginationExtention = new PaginationExtention();
//        }

//        #endregion


        



//        #region methods

//        [HttpGet]
//        [Authorize]
//        public ActionResult Products(PagingParams pagingParams)
//        {
//            var userID = User.Identity.GetUserId();

//            var model = _productServices.UserProducts(pagingParams, userID);

//            Response.Headers.Add("X-Pagination", model.GetHeader().ToJson());

//            var outputModel = new ProductOutputModel
//            {
//                Paging = model.GetHeader(),
//                Links = _paginationExtention.GetLinks(model, "Products"),
//                LinksNumbers = _paginationExtention.GetLinksNumbers(model, "Products"),
//                Items = model.List.Select(m => Mapper.Map<ProductViewModel>(m)).ToList(),
//            };

//            return View(outputModel);
//        }

//        public ActionResult ProductDetails(int id,string slug)
//        {
//            var product= _productServices.GetById(id);
//            var model = Mapper.Map<ProductViewModel>(product);

//            if (model != null)
//            {
//                if (string.IsNullOrEmpty(slug) || model.Name != slug.Replace('-', ' '))
//                    return RedirectToRoute("ProductDetails", new { id = id, slug = model.Name.Replace(' ', '-').Replace('/', '-').Replace('$', '-').Replace('#', '-') });

//                return View(model);
//            }
//            else
//            {
//                return Content("Not Found!");
//            }
//        }
              

//        #endregion

//    }
//}
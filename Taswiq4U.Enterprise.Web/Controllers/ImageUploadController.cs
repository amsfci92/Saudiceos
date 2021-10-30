 
using Cigarette.Enterprise.Extentions.ExtentionMethods.HttpFileBase;
using Newtonsoft.Json;
using Saudiceos.Enterprise.Web.Areas.Admin.Controllers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web; 
using System.Web.Mvc;
using static Cigarette.Enterprise.Extentions.ExtentionMethods.HttpFileBase.ExtensionMethods;

namespace SaudiCeos.Enterprise.Web.Controllers
{ 
    [RoutePrefix("Admin/uploader")] 
    public class ImageUploadController : BaseController
    { 
        #region Fields 
        #endregion
        
        #region Ctor
        public ImageUploadController( )
        {
            
        }
        #endregion
         
        #region Methods

        [Route("img")]
        [HttpPost]
        public ActionResult UploadCeoImages(int type, int r = 0, int h = 0, int w = 0)
        {
            if (HttpContext.Request.Files.Count == 0)
            {
                return HttpNotFound("لا يوجد ملفات");
            }
            HttpPostedFileBase file = HttpContext.Request.Files[0];
             
           var errors = new List<string>();

            if (file.HasFile())
            {
                var image = file.SaveImage(errors, (ImageType)type, r, h, w);

                if (image == null)
                {
                    return HttpNotFound(string.Join(", ", errors));
                }
                 

                return Json(image, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return HttpNotFound(string.Join(", ", errors));
            }
        }
        [Route("file")]
        [HttpPost]
        public ActionResult UploadFiles(int type)
        {
            if (HttpContext.Request.Files.Count == 0)
            {
                return HttpNotFound("لا يوجد ملفات");
            }
            HttpPostedFileBase file = HttpContext.Request.Files[0];

            var errors = new List<string>();

            if (file.HasFile())
            {
                var image = file.SaveFile(errors, (FileType)type);

                if (image == null)
                {
                    return HttpNotFound(string.Join(", ", errors));
                }


                return Json(image, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return HttpNotFound(string.Join(", ", errors));
            }
        }
        #endregion
    }

    public  class img{
        public string ImageName { get; set; }
    }
}

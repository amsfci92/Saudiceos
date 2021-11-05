 
using Cigarette.Enterprise.Extentions.ExtentionMethods.HttpFileBase;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;
using Taswiq4U.Enterprise.WebApi.Helpers;

namespace Saudiceos.Enterprise.WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]

    [RoutePrefix("api/uploader")]
    public class ImageUploadController : ApiController
    {
        #region Fields 
        #endregion

        #region Ctor
        public ImageUploadController()
        {

        }
        #endregion

        #region Methods

        [Route("img")]
        [HttpPost]
        public IHttpActionResult UploadCeoImages(int type, int r = 0, int h = 0, int w = 0)
        {
            if (System.Web.HttpContext.Current.Request.Files.Count <= 0)
            {
                return BadRequest("No files");
            }
            HttpPostedFile file = System.Web.HttpContext.Current.Request.Files.Get(0);

            var errors = new List<string>();

            if (file.HasFile())
            {
                var image = file.SaveImage(errors, (ImageType)type, r, h, w);

                if (image == null)
                {
                    return BadRequest("2 nd" + string.Join(", ", errors));
                }


                return Json(image);
            }
            else
            {
                return BadRequest("3 third" + string.Join(", ", errors));
            }
        }
        [Route("file")]
        [HttpPost]
        public IHttpActionResult UploadFiles(int type)
        {
            if (System.Web.HttpContext.Current.Request.Files.Count <= 0)
            {
                return BadRequest("No files");
            }
            HttpPostedFile file = System.Web.HttpContext.Current.Request.Files.Get(0);

            var errors = new List<string>();

            if (file.HasFile())
            {
                var image = file.SaveFile(errors, (FileType)type);

                if (image == null)
                {
                    return BadRequest("2 nd" + string.Join(", ", errors));
                }


                return Json(image);
            }
            else
            {
                return BadRequest("3 third" + string.Join(", ", errors));
            }
        }
        #endregion
    }

    public class img
    {
        public string ImageName { get; set; }
    }
}
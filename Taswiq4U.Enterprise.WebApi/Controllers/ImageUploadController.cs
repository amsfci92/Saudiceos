//using Cigarette.Enterprise.BLL.AdvertisementImageServ;
//using Cigarette.Enterprise.BLL.AdvertisementServ;
//using Cigarette.Enterprise.BLL.SystemDataFileService;
//using Cigarette.Enterprise.Extentions.ExtentionMethods.HttpFileBase;
//using Newtonsoft.Json;
//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Net;
//using System.Net.Http;
//using System.Web;
//using System.Web.Http;
//using System.Web.Http.Cors;
//using Taswiq4U.Enterprise.WebApi.Helpers;

//namespace Taswiq4U.Enterprise.WebApi.Controllers
//{
//    [EnableCors(origins: "*", headers: "*", methods: "*")]
//    [RoutePrefix("Api/ImageUpload")]
//    public class ImageUploadController : ApiController
//    { 
//        #region Fields
//        private IAdvertisementImageServices _advertisementImageServices;
//        private ISystemDataFileService _systemDataFileService;
//        #endregion
        
//        #region Ctor
//        public ImageUploadController(IAdvertisementImageServices advertisementServices,
//            ISystemDataFileService  systemDataFileService)
//        {
//            _advertisementImageServices = advertisementServices;
//            _systemDataFileService = systemDataFileService;
//        }
//        #endregion
         
//        #region Methods

//        [Route("AddAdvertismentImage")]
//        [HttpPost]
//        public IHttpActionResult AddAdvertismentImage()
//        {
//            if (HttpContext.Current.Request.Files.Count == 0)
//            {
//                return BadRequest(ErrorCodes.Ins.FileNotFound.Code);
//            }
//            HttpPostedFile file = HttpContext.Current.Request.Files[0];
             
//           var errors = new List<string>();

//            if (file.HasFile())
//            {
//                var image = file.SaveAdvertismentImage(errors);

//                if (image == null)
//                {
//                    return BadRequest(JsonConvert.SerializeObject(errors));
//                }

//                var savedImageId = _advertisementImageServices.AddAdvertismentImage(image);

//                return Ok(new { id = savedImageId , url = image.Url });
//            }
//            else
//            {
//                return BadRequest(ErrorCodes.Ins.FileNotFound.Code);
//            }
//        }

//        /// <summary>
//        /// Add Commercial Images
//        /// </summary>
//        /// <returns></returns>
//        [Route("AddCommercialAdImage")]
//        [HttpPost] 
//        public IHttpActionResult AddCommercialAdImage()
//        {
//            HttpPostedFile file = HttpContext.Current.Request.Files[0];

//            var errors = new List<string>();

//            if (file.HasFile())
//            {

//                var image = file.SaveAdsImage(errors);

//                if (image == null)
//                {
//                    return BadRequest(JsonConvert.SerializeObject(errors));
//                }

//                var savedImageId = _systemDataFileService.AddCommercialAdsImage(image);

//                return Ok(new { id = savedImageId, url = image.Url });

//            }
//            else
//            {
//                return BadRequest(ErrorCodes.Ins.FileNotFound.Code);
//            }
//        }

//        [Route("AddSystemImage/{type}")]
//        [HttpPost]
//        public IHttpActionResult AddCategoryImage(int type)
//        {
//            HttpPostedFile file = HttpContext.Current.Request.Files[0];

//            var errors = new List<string>();

//            if (file.HasFile())
//            {
//                var image = file.SaveSystemImage(errors, type);

//                if (image == null)
//                {
//                    return BadRequest(JsonConvert.SerializeObject(errors));
//                }

//                var savedImageId = _systemDataFileService.AddCommercialAdsImage(image);

//                return Ok(new { id = savedImageId, url = image.Url });

//            }
//            else
//            {
//                return BadRequest(ErrorCodes.Ins.FileNotFound.Code);
//            }
//        }

        

//        [Route("GetCommercialAdImage/{imageId}")]
//        public string GetAdsImage(int imageId)
//        {
//            var img = _systemDataFileService.GetCommercialAdsImage(imageId);
//            var path = System.Web.Hosting.HostingEnvironment.MapPath("~/DynamicResources/CommercialAdsImages/" + img.Url);
//            //var root = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
//            //var path = Path.Combine(root, url);

//            var bytes = File.ReadAllBytes(path);
//            var base64 = Convert.ToBase64String(bytes);

//            return "data:image/jpeg;base64," + base64;
//        }

//        [Route("GetSystemImage/{imageId}/{type}")]
//        public string GetSystemImage(int imageId,int type)
//        {
//            var img = _systemDataFileService.GetCommercialAdsImage(imageId);
//            var path = "";
//            if(type==1)
//                path = System.Web.Hosting.HostingEnvironment.MapPath("~/DynamicResources/CategoryImages/" + img.Url);
//            else
//                path = System.Web.Hosting.HostingEnvironment.MapPath("~/DynamicResources/CountryImages/" + img.Url);

//            //var root = AppDomain.CurrentDomain.SetupInformation.ApplicationBase;
//            //var path = Path.Combine(root, url);

//            var bytes = File.ReadAllBytes(path);
//            var base64 = Convert.ToBase64String(bytes);

//            return "data:image/jpeg;base64," + base64;
//        }

//        [Route("GetAdvertismentImage/{imageId}")]
//        public string GetAdvertismentImage(int imageId)
//        {
//            var img = _advertisementImageServices.GetAdvertismentImage(imageId);

//            var path = System.Web.Hosting.HostingEnvironment.MapPath("~/DynamicResources/AdvertismentImages/" + img.Url);
             
//            var bytes = File.ReadAllBytes(path);
//            var base64 = Convert.ToBase64String(bytes);

//            return "data:image/jpeg;base64," + base64;
//        }

//        [Route("image")]
//        public string GetAdvertismentImageUrl(string url, int type = 0)
//        {
//            try
//            {
//                var path = "";

//                if (type == 1)
//                {
//                    path = System.Web.Hosting.HostingEnvironment.MapPath("~/DynamicResources/CommercialAdsImages/" + url);
//                }
//                else
//                {
//                    path = System.Web.Hosting.HostingEnvironment.MapPath("~/DynamicResources/AdvertismentImages/" + url);
//                }

//                var bytes = File.ReadAllBytes(path);
//                var base64 = Convert.ToBase64String(bytes);

//                return "data:image/jpeg;base64," + base64;
//            }catch (Exception ee)
//            {
//                return "";
//            }
//        }
//        [Route("i")]
//        public HttpResponseMessage GetImageUrl(string url, int type = 0)
//        {
//            try
//            {
//                var path = "";

//                if (type == 1)
//                {
//                    path = System.Web.Hosting.HostingEnvironment.MapPath("~/DynamicResources/CommercialAdsImages/" + url);
//                }
//                else if (type == 3)
//                {
//                    path = System.Web.Hosting.HostingEnvironment.MapPath("~/DynamicResources/CategoryImages/" + url);
//                }
//                else if (type == 4)
//                {
//                    path = System.Web.Hosting.HostingEnvironment.MapPath("~/DynamicResources/CountryImages/" + url);
//                } 
//                else
//                {
//                    path = System.Web.Hosting.HostingEnvironment.MapPath("~/DynamicResources/AdvertismentImages/" + url);
//                }

//                var response = new HttpResponseMessage(HttpStatusCode.OK);
//                var stream = new System.IO.FileStream(path, System.IO.FileMode.Open);
//                response.Content = new StreamContent(stream);
//                response.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("image/jpeg");
//                return response;
//            }
//            catch (Exception ee)
//            {
//                return new HttpResponseMessage(HttpStatusCode.NotFound);
//            }

//        }

//        [Route("GetAdImage")]
//        [HttpPost]
//        public string GetAdImage(img model)
//        {
//            if (model == null || string.IsNullOrWhiteSpace(model.ImageName))
//                return string.Empty;
            
//            var path = "";
//            try
//            {
//                path = System.Web.Hosting.HostingEnvironment.MapPath("~/DynamicResources/AdvertismentImages/" + model.ImageName);
//            }
//            catch (Exception)
//            {

//                return string.Empty;
                
//            }
            
//            try
//            {
//                var bytes = File.ReadAllBytes(path);
//                var base64 = Convert.ToBase64String(bytes);
//                return "data:image/jpeg;base64," + base64;
//            }
//            catch (Exception)
//            {

//                return string.Empty;
//            }
            
//        }


//        #endregion
//    }

//    public  class img{
//        public string ImageName { get; set; }
//    }
//}

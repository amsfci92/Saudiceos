using Cigarette.Enterprise.Extentions.ExtentionMethods.HttpFileBase;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using static Cigarette.Enterprise.Extentions.ExtentionMethods.HttpFileBase.ExtensionMethods;

namespace Saudiceos.Enterprise.Web.Areas.Admin.Controllers
{
    public class BaseController : Controller
    { 
        public ActionResult Index()
        {
            return View();
        }
        protected void SetSuccessMessage(string message)
        {
            TempData["SuccessMessage"] = message;
        }
        #region Helpers
        protected long GetId(string encodedId)
        {
            try
            {
                var idBytes = Convert.FromBase64String(encodedId);
                var id = Encoding.UTF8.GetString(idBytes);
                var result = Int64.TryParse(id, out long value);
                if (result)
                {
                    return value;
                }
            }
            catch (Exception e)
            {
                return 0;
            }
            return 0;
        }
        protected string GetB64Id(long id)
        {
            try
            {
                var ids = Encoding.UTF8.GetBytes(id.ToString());
                var base64 = Convert.ToBase64String(ids);
                return base64;
            }
            catch (Exception e)
            {
                return null;
            } 
        }

        protected string GetB64Id(string id)
        {
            try
            {
                var ids = Encoding.UTF8.GetBytes(id);
                var base64 = Convert.ToBase64String(ids);
                return base64;
            }
            catch (Exception e)
            {
                return null;
            }
        }
        protected string GetIdGUID(string encodedId)
        {
            try
            {
                var idBytes = Convert.FromBase64String(encodedId);
                var id = Encoding.UTF8.GetString(idBytes);
                   return id; 
            }
            catch (Exception e)
            {
                return null;
            } 
        }

        protected List<long> GetIds(string encodedIds)
        {
            var idList = new List<long>();
            try
            { 
                var idBytes = Convert.FromBase64String(encodedIds);
                var id = Encoding.UTF8.GetString(idBytes);
                var parsedIds = id.Split('$');
                foreach (var item in parsedIds)
                {
                    var result = Int64.TryParse(item, out long value);
                    if (result)
                    {
                        idList.Add(value);
                    }
                }
                return idList;
            }
            catch (Exception e)
            {
                return idList; 
            } 
        }
        protected List<string> GetGUIDs(string encodedIds)
        {
            var idList = new List<string>();
            try
            {
                var idBytes = Convert.FromBase64String(encodedIds);
                var id = Encoding.UTF8.GetString(idBytes);
                var parsedIds = id.Split('$');
                foreach (var item in parsedIds)
                { 
                        idList.Add(item); 
                }
                return idList;
            }
            catch (Exception e)
            {
                return idList;
            }
        }
        protected void SaveFileThenClearTemp(string fileName, FileType imageType)
        {
            string pathFrom = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath($"/Content/Data/{imageType.ToString()}/FileTMP"), fileName);
            string pathTo = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath($"/Content/Data/{imageType.ToString()}/File"), fileName);
            if (System.IO.File.Exists(pathFrom))
            {
                System.IO.File.Copy(pathFrom, pathTo, true);
                System.IO.File.Delete(pathFrom);
            }
        }

        protected void SaveImageThenClearTemp(string fileName, ImageType imageType)
        { 
            string pathFrom = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath($"/Content/Data/{imageType.ToString()}/imagesTMP"), fileName);
            string pathTo = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath($"/Content/Data/{imageType.ToString()}/images"), fileName);
            if (System.IO.File.Exists(pathFrom))
            {
                System.IO.File.Copy(pathFrom, pathTo, true);
                System.IO.File.Delete(pathFrom);
            }
        }

        protected void DeleteImage(string fileName, ImageType imageType)
        { 
             string pathTo = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath($"/Content/Data/{imageType.ToString()}/images"), fileName); 
            System.IO.File.Delete(pathTo); 
        }

        protected void SaveImageToTemp(string fileName, ImageType imageType)
        {
            try
            {
                string pathFrom = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath($"/Content/Data/{imageType.ToString()}/images"), fileName);
                string pathTo = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath($"/Content/Data/{imageType.ToString()}/imagesTMP"), fileName);
                
                if (System.IO.File.Exists(pathFrom))
                    System.IO.File.Copy(pathFrom, pathTo, true); 
            }
            catch(Exception e)
            {

            }
        }
        protected void SaveImageToTemp(string fileName, ImageType fromType, ImageType fromType2, ImageType toType)
        {
            try
            {
                string pathFrom = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath($"/Content/Data/{fromType.ToString()}/imagesTMP"), fileName);
                string pathFrom2 = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath($"/Content/Data/{fromType2.ToString()}/images"), fileName);
                
                string pathTo = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath($"/Content/Data/{toType.ToString()}/imagesTMP"), fileName);
                if (System.IO.File.Exists(pathFrom))
                    System.IO.File.Copy(pathFrom, pathTo, true);
                if (System.IO.File.Exists(pathFrom2))
                    System.IO.File.Copy(pathFrom2, pathTo, true);
            }
            catch (Exception e)
            {

            }
        }
        protected void SaveFileToTemp(string fileName, FileType imageType)
        {
            try
            {
                string pathFrom = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath($"/Content/Data/{imageType.ToString()}/File"), fileName);
                string pathTo = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath($"/Content/Data/{imageType.ToString()}/FileTMP"), fileName);
                
                if (System.IO.File.Exists(pathFrom))
                    System.IO.File.Copy(pathFrom, pathTo, true);
            }
            catch (Exception e)
            {

            }
        }
        protected void SaveFileToTemp(string fileName, FileType fromType, FileType fromType2, FileType toType)
        {
            try
            {
                string pathFrom = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath($"/Content/Data/{fromType.ToString()}/FileTMP"), fileName);
                string pathFrom2 = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath($"/Content/Data/{fromType2.ToString()}/File"), fileName);
                string pathTo = Path.Combine(System.Web.Hosting.HostingEnvironment.MapPath($"/Content/Data/{toType.ToString()}/FileTMP"), fileName);
                if (System.IO.File.Exists(pathFrom))
                    System.IO.File.Copy(pathFrom, pathTo, true);
                if (System.IO.File.Exists(pathFrom2))
                    System.IO.File.Copy(pathFrom2, pathTo, true);
            }
            catch (Exception e)
            {

            }
        }
        #endregion
    }
}
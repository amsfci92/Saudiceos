using Cigarette.Enterprise.ViewModels.BindingModels.CommercialAd;
using Cigarette.Enterprise.ViewModels.ViewModels.AdvertismentImage;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Cigarette.Enterprise.Extentions.ExtentionMethods.HttpFileBase
{
    public enum ImageType
    {
        Ceo = 0,
        Banner = 1,
        News = 2,
        Report = 3,
        User = 4,
        Service = 5,
        CeoAPI = 6,
    }
    public enum FileType
    {
        Ceo = 0, 
        Report = 1,
        CeoAPI = 2
    }
    public static class ExtensionMethods
    {

        public static bool HasFile(this HttpPostedFileBase file)
        {
            return file != null && file.ContentLength > 0;
        }
        public static bool HasFile(this HttpPostedFile file)
        {
            return file != null && file.ContentLength > 0;
        }
        public static string SaveFile(this HttpPostedFileBase file, List<string> errors, FileType fileType)
        {

            var validExt = new[] { "pdf", "doc", "docx" };
            var mappedPath = System.Web.Hosting.HostingEnvironment.MapPath($"/Content/Data/{fileType.ToString()}/FileTMP");

            var valid = validExt.Contains(Path.GetExtension(file.FileName).Substring(1)?.ToLower());
            var r = Path.GetExtension(file.FileName).Substring(1)?.ToLower();
            if (!valid)
            {
                errors.Add("صيغه الملف غير مدعومه");
                return null;
            }

            if (file.ContentLength > 30 * 1024 * 1024)
            {
                errors.Add("لقد تجاوزت الحجم المسموح");
                return null;
            }

            try
            {

                var newFileName = $"{Guid.NewGuid().ToString()}.{new Random().Next()}{Path.GetExtension(file.FileName)?.ToLower()}";


                string path = Path.Combine(mappedPath, newFileName);

                file.SaveAs(path);

                return newFileName;
            }
            catch (Exception ee)
            {
                errors.Add("لم يتم إضافة الملف");
                return null;
            }
        }
        public static string SaveFile(this HttpPostedFile file, List<string> errors, FileType fileType)
        {

            var validExt = new[] { "pdf", "doc", "docx" };
            var mappedPath = System.Web.Hosting.HostingEnvironment.MapPath($"/Content/Data/{fileType.ToString()}/FileTMP");

            var valid = validExt.Contains(Path.GetExtension(file.FileName).Substring(1)?.ToLower());
            var r = Path.GetExtension(file.FileName).Substring(1)?.ToLower();
            if (!valid)
            {
                errors.Add("صيغه الملف غير مدعومه");
                return null;
            }

            if (file.ContentLength > 30 * 1024 * 1024)
            {
                errors.Add("لقد تجاوزت الحجم المسموح");
                return null;
            }

            try
            {

                var newFileName = $"{Guid.NewGuid().ToString()}.{new Random().Next()}{Path.GetExtension(file.FileName)?.ToLower()}";


                string path = Path.Combine(mappedPath, newFileName);

                file.SaveAs(path);

                return newFileName;
            }
            catch (Exception ee)
            {
                errors.Add("لم يتم إضافة الملف");
                return null;
            }
        }
        public static string SaveImage(this HttpPostedFileBase file, List<string> errors, ImageType imageType, int r = 0, int h = 0, int w = 0)
        {

            var supportedVideoTypes = new[] { "mp4" };
            var supportedImageTypes = new[] { "jpg", "jpeg", "png" };

            var mappedPath = System.Web.Hosting.HostingEnvironment.MapPath($"/Content/Data/{imageType.ToString()}/imagesTMP");

            var isImage = supportedImageTypes.Contains(Path.GetExtension(file.FileName).Substring(1)?.ToLower());
            var isVideo = supportedVideoTypes.Contains(Path.GetExtension(file.FileName).Substring(1)?.ToLower()) && !isImage;

            if (!isImage && !isVideo)
            {
                errors.Add("صيغه الملف غير مدعومه");
                return null;
            }

            if (file.ContentLength > 15 * 1024 * 1024)
            {
                errors.Add("لقد تجاوزت الحجم المسموح");
                return null;
            }

            try
            {
                var newFileName = $"{Guid.NewGuid().ToString()}.{new Random().Next()}{Path.GetExtension(file.FileName)?.ToLower()}";

                string path = Path.Combine(mappedPath, newFileName);

                //using (Image imageFile = Image.FromStream(file.InputStream))
                //using (Image watermarkImage = Image.FromFile(Path.Combine(mappedPath, "Saudiceos_logo.png")))
                //using (Graphics imageGraphics = Graphics.FromImage(imageFile))
                //using (TextureBrush watermarkBrush =
                //    new TextureBrush(((Bitmap)ResizeImageKeepAspectRatio(watermarkImage,
                //    (int)(imageFile.Width/3), (int)(imageFile.Height/3)))))
                //{
                //    int x = (imageFile.Width - imageFile.Width/3);
                //    int y = (imageFile.Height - imageFile.Height/3);

                //    // watermarkBrush.TranslateTransform(x, y);
                //    imageGraphics.FillRectangle(watermarkBrush, new Rectangle(new Point(x, y), new Size(watermarkImage.Width + 1, watermarkImage.Height)));
                //    imageFile.Save(path);
                //} 
                var image = Image.FromStream(file.InputStream);
                int height = h == 0 ? 350 : h;
                int width = w == 0 ? 300 : w;
                if (r > 0)
                {
                    double ratio = (double)width / image.Width;
                    int newWidth = (int)(image.Width * ratio);
                    int newHeight = (int)(image.Height * ratio);
                    Bitmap newImage = new Bitmap(width, height);
                    using (Graphics g = Graphics.FromImage(newImage))
                    {
                        g.DrawImage(image, 0, 0, newWidth, newHeight);
                    }
                    image.Dispose();
                    newImage.Save(path);
                }
                else
                {
                    file.SaveAs(path);
                }

                return newFileName;
            }
            catch (Exception ee)
            {
                errors.Add("Api-Err-F3" + ee.Message);
                return null;
            }
        }
        public static string SaveImage(this HttpPostedFile file, List<string> errors, ImageType imageType, int r = 0, int h = 0, int w = 0)
        {

            var supportedVideoTypes = new[] { "mp4" };
            var supportedImageTypes = new[] { "jpg", "jpeg", "png" };

            var mappedPath = System.Web.Hosting.HostingEnvironment.MapPath($"/Content/Data/{imageType.ToString()}/imagesTMP");

            var isImage = supportedImageTypes.Contains(Path.GetExtension(file.FileName).Substring(1)?.ToLower());
            var isVideo = supportedVideoTypes.Contains(Path.GetExtension(file.FileName).Substring(1)?.ToLower()) && !isImage;

            if (!isImage && !isVideo)
            {
                errors.Add("صيغه الملف غير مدعومه");
                return null;
            }

            if (file.ContentLength > 15 * 1024 * 1024)
            {
                errors.Add("لقد تجاوزت الحجم المسموح");
                return null;
            }

            try
            {
                var newFileName = $"{Guid.NewGuid().ToString()}.{new Random().Next()}{Path.GetExtension(file.FileName)?.ToLower()}";

                string path = Path.Combine(mappedPath, newFileName);

                //using (Image imageFile = Image.FromStream(file.InputStream))
                //using (Image watermarkImage = Image.FromFile(Path.Combine(mappedPath, "Saudiceos_logo.png")))
                //using (Graphics imageGraphics = Graphics.FromImage(imageFile))
                //using (TextureBrush watermarkBrush =
                //    new TextureBrush(((Bitmap)ResizeImageKeepAspectRatio(watermarkImage,
                //    (int)(imageFile.Width/3), (int)(imageFile.Height/3)))))
                //{
                //    int x = (imageFile.Width - imageFile.Width/3);
                //    int y = (imageFile.Height - imageFile.Height/3);

                //    // watermarkBrush.TranslateTransform(x, y);
                //    imageGraphics.FillRectangle(watermarkBrush, new Rectangle(new Point(x, y), new Size(watermarkImage.Width + 1, watermarkImage.Height)));
                //    imageFile.Save(path);
                //} 
                var image = Image.FromStream(file.InputStream);
                int height = h == 0 ? 350 : h;
                int width = w == 0 ? 300 : w;
                if (r > 0)
                {
                    double ratio = (double)width / image.Width;
                    int newWidth = (int)(image.Width * ratio);
                    int newHeight = (int)(image.Height * ratio);
                    Bitmap newImage = new Bitmap(width, height);
                    using (Graphics g = Graphics.FromImage(newImage))
                    {
                        g.DrawImage(image, 0, 0, newWidth, newHeight);
                    }
                    image.Dispose();
                    newImage.Save(path);
                }
                else
                {
                    file.SaveAs(path);
                }

                return newFileName;
            }
            catch (Exception ee)
            {
                errors.Add("Api-Err-F3" + ee.Message);
                return null;
            }
        }

        public static SystemDataFileBM SaveAdsImage(this HttpPostedFile file, List<string> errors)
        {

            var supportedVideoTypes = new[] { "mp4" };
            var supportedImageTypes = new[] { "jpg", "jpeg", "png" };
            var mappedPath = System.Web.Hosting.HostingEnvironment.MapPath("~/DynamicResources/CommercialAdsImages");


            var isImage = supportedImageTypes.Contains(Path.GetExtension(file.FileName).Substring(1)?.ToLower());
            var isVideo = supportedVideoTypes.Contains(Path.GetExtension(file.FileName).Substring(1)?.ToLower()) && !isImage;

            if (!isImage && !isVideo)
            {
                errors.Add($"Api-Err-F1");
                return null;
            }

            if (file.ContentLength > 10 * 1024 * 1024)
            {
                errors.Add("Api-Err-F2");
                return null;
            }

            try
            {

                var newFileName = $"{Guid.NewGuid().ToString()}.{new Random().Next()}{Path.GetExtension(file.FileName)}";

                var image = new SystemDataFileBM
                {
                    Extention = Path.GetExtension(file.FileName),
                    IsDeleted = false,
                    Size = (decimal)file.ContentLength,
                    CreationDate = DateTime.Now,
                    Type = (isImage && !isVideo) ? 0 : 1,
                    Url = newFileName
                };

                string path = Path.Combine(mappedPath, newFileName);

                file.SaveAs(path);

                return image;
            }
            catch (Exception ee)
            {
                errors.Add("Api-Err-F3");
                return null;
            }
        }

        public static SystemDataFileBM SaveSystemImage(this HttpPostedFile file, List<string> errors,int type)
        {
            var supportedImageTypes = new[] { "jpg", "jpeg", "png" };
            var mappedPath = "";

            if (type==1)
                mappedPath = System.Web.Hosting.HostingEnvironment.MapPath("~/DynamicResources/CategoryImages");
            else
                mappedPath = System.Web.Hosting.HostingEnvironment.MapPath("~/DynamicResources/CountryImages");

            var isImage = supportedImageTypes.Contains(Path.GetExtension(file.FileName).Substring(1)?.ToLower());

            if (!isImage)
            {
                errors.Add("Api-Err-F1");
                return null;
            }

            if (file.ContentLength > 10 * 1024 * 1024)
            {
                errors.Add("Api-Err-F2");
                return null;
            }

            try
            {
                var newFileName = $"{Guid.NewGuid().ToString()}.{new Random().Next()}{Path.GetExtension(file.FileName)?.ToLower()}";

                var image = new SystemDataFileBM
                {
                    Extention = Path.GetExtension(file.FileName),
                    IsDeleted = false,
                    Size = (decimal)file.ContentLength,
                    CreationDate = DateTime.Now,
                    Type = 0 ,
                    Url = newFileName
                };

                string path = Path.Combine(mappedPath, newFileName);

                file.SaveAs(path);
                return image;
            }
            catch (Exception ee)
            {
                errors.Add("Api-Err-F3");
                return null;
            }
        }

        /// <summary>
        /// Resize an image keeping its aspect ratio (cropping may occur).
        /// </summary>
        /// <param name="source"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static Image ResizeImageKeepAspectRatio(Image source, int width, int height)
        {
            Image result = null;

            try
            {
                if (source.Width != width || source.Height != height)
                {
                    // Resize image
                    float sourceRatio = (float)source.Width / source.Height;

                    using (var target = new Bitmap(width, height))
                    {
                        using (var g = System.Drawing.Graphics.FromImage(target))
                        {
                            g.CompositingQuality = CompositingQuality.HighQuality;
                            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                            g.SmoothingMode = SmoothingMode.HighQuality;

                            // Scaling
                            float scaling;
                            float scalingY = (float)source.Height / height;
                            float scalingX = (float)source.Width / width;
                            if (scalingX < scalingY) scaling = scalingX; else scaling = scalingY;

                            int newWidth = (int)(source.Width / scaling);
                            int newHeight = (int)(source.Height / scaling);

                            // Correct float to int rounding
                            if (newWidth < width) newWidth = width;
                            if (newHeight < height) newHeight = height;

                            // See if image needs to be cropped
                            int shiftX = 0;
                            int shiftY = 0;

                            if (newWidth > width)
                            {
                                shiftX = (newWidth - width) / 2;
                            }

                            if (newHeight > height)
                            {
                                shiftY = (newHeight - height) / 2;
                            }

                            // Draw image
                            g.DrawImage(source, -shiftX, -shiftY, newWidth, newHeight);
                        }

                        result = (Image)target.Clone();
                    }
                }
                else
                {
                    // Image size matched the given size
                    result = (Image)source.Clone();
                }
            }
            catch (Exception)
            {
                result = null;
            }

            return result;
        }

    }
}

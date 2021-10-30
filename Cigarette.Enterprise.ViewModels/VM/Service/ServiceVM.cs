using Cigarette.Enterprise.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.VM.Service
{
    public class ServiceVM
    {
        public ServiceVM()
        {
            Categories = new List<Category>();
        }
        public long Id { get; set; }
        [Required(ErrorMessage = "العنوان مطلوب")]
        public string Title { get; set; }
        [Required(ErrorMessage = "الوصف مطلوب")]

        public string Description { get; set; } 

        public string ImageUrl { get; set; }
        [Required(ErrorMessage = "الشعار مطلوب")]
        public string LogoUrl { get; set; }
        public string Link { get; set; }
        public string Code { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; } 
        public bool Active { get; set; }
        public long? CategoryId { get; set; }
        public string Image1 { get; set; }
        public string Image2 { get; set; }
        public string Image3 { get; set; }
        public string Image4 { get; set; }
        public List<Category> Categories { get; set; }

        public string GetImagesNames() {
            var imagesList = new List<string>();

            if (!string.IsNullOrWhiteSpace(Image1))
            {
                imagesList.Add(Image1);
            }
            if (!string.IsNullOrWhiteSpace(Image2))
            {
                imagesList.Add(Image2);
            }
            if (!string.IsNullOrWhiteSpace(Image3))
            {
                imagesList.Add(Image3);
            }
            if (!string.IsNullOrWhiteSpace(Image4))
            {
                imagesList.Add(Image4);
            }

            return string.Join(",", imagesList);
        }

        public void SetImagersNames()
        { 
            var imageList = !string.IsNullOrWhiteSpace(ImageUrl) ? ImageUrl.Split(',') : null;
            
            if (imageList != null)
            {
                if (imageList.Length > 0 && !string.IsNullOrWhiteSpace(imageList[0]))
                {
                    Image1 = imageList[0];
                }
                if (imageList.Length > 1 && !string.IsNullOrWhiteSpace(imageList[1]))
                {
                    Image2 = imageList[1];
                }
                if (imageList.Length > 2 && !string.IsNullOrWhiteSpace(imageList[2]))
                {
                    Image3 = imageList[2];
                }
                if (imageList.Length > 3 && !string.IsNullOrWhiteSpace(imageList[3]))
                {
                    Image4 = imageList[3];
                }
            } 
        }
    }
}

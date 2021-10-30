using System;
using System.ComponentModel.DataAnnotations;

namespace Cigarette.Enterprise.ViewModels.VM.Service
{
    public class CategoryVM
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "العنوان مطلوب")]
        public string Name { get; set; } 
         
        [Required(ErrorMessage = "الصورة مطلوبه")]

        public string ImageUrl { get; set; } 
        public Nullable<System.DateTime> DateCreated { get; set; } 
    }
}

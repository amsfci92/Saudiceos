using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace Cigarette.Enterprise.ViewModels.VM.News
{
    public class NewsVM
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "العنوان مطلوب")]
        public string Title { get; set; }
        [Required(ErrorMessage = "الملخص مطلوب")]
        [AllowHtml]
        public string Description { get; set; } 
        public string Note { get; set; }
        [Required(ErrorMessage = "الصورة مطلوبه")]
        public string imageUrl { get; set; }
        public Nullable<System.DateTime> CreateDate { get; set; }
        public Nullable<int> Views { get; set; }
        public Nullable<bool> Active { get; set; }
        public long? CeoId { get; set; }
        public IEnumerable<DAL.CEO> CeoList { get; set; }
    }
}

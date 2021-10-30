using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.VM.Banner
{
    public class BannerVM
    { 
       
        public long Id { get; set; }
        public string Title { get; set; }
        [Required(ErrorMessage = "الصورة مطلوبه")]
        public string ImageUrl { get; set; }
        public string Type { get; set; }
        public string Link { get; set; }
        public string FileUrl { get; set; }
        public string Description { get; set; }
        public string Advertiser { get; set; }
        public string Keywords { get; set; }
        [Required(ErrorMessage = "  مطلوب مكان الاعلان")] 
        public int? AdPlace { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<bool> Active { get; set; }
    }
}

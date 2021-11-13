using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace Cigarette.Enterprise.ViewModels.VM.Report
{
    public class ReportVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "العنوان مطلوب")]
        public string Title { get; set; }
        [Required(ErrorMessage = "الوصف مطلوب")]
        [AllowHtml]
        public string Description { get; set; }
        [Required(ErrorMessage = "الصورة مطلوبه")]

        public string ImageUrl { get; set; }
        public string FileUrl { get; set; }
        public string SocialShare { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
    
        public string Type { get; set; }
        [AllowHtml]
        public string Issuer { get; set; }
 
        public Nullable<System.DateTime> IssueDate { get; set; }
        public Nullable<System.DateTime> PublishDate { get; set; }
        public bool Active { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.VM.Report
{
    public class ReportVM
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "العنوان مطلوب")]
        public string Title { get; set; }
        [Required(ErrorMessage = "الوصف مطلوب")]

        public string Description { get; set; }
        [Required(ErrorMessage = "الصورة مطلوبه")]

        public string ImageUrl { get; set; }
        public string FileUrl { get; set; }
        public string SocialShare { get; set; }
        public Nullable<System.DateTime> DateCreated { get; set; }
        [Required(ErrorMessage = "النوع مطلوب")]

        public string Type { get; set; }
        [Required(ErrorMessage = "المصدر مطلوب")]

        public string Issuer { get; set; }
        [Required(ErrorMessage = "تاريخ الاصدار مطلوب")]

        public Nullable<System.DateTime> IssueDate { get; set; }
        public Nullable<System.DateTime> PublishDate { get; set; }
        public bool Active { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.VM.CEO
{
    public class CEOVM
    {
        public long Id { get; set; }
        [Required(ErrorMessage = "الاسم مطلوب")]
        public string Name { get; set; }
        public string Position { get; set; }
        public string LinkedIn { get; set; }
        public string Twitter { get; set; }
        public string SnapChat { get; set; } 
        public string CVNote { get; set; }
        [Required(ErrorMessage = "الصورة مطلوبه")] 
        public string ImageUrl { get; set; }

        public string CVDescription { get; set; }
        public string Company { get; set; }
        public string Email { get; set; }
        public string Location { get; set; }
        public Nullable<System.DateTime> CreatedDate { get; set; }
        public Nullable<bool> Active { get; set; }
        public Nullable<int> Views { get; set; }
        public string CVUrl { get; set; }
    }
}

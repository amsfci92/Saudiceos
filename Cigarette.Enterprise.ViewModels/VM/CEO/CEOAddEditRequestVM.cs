using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.VM.CEO
{
    public class CEOAddEditRequestVM
    {
        public CEOAddEditRequestVM()
        {
        }
        [Required(ErrorMessage = "الاسم مطلوب")] 
        public string Name { get; set; }
        public long Id { get; set; }
        public string Phone { get; set; } 
        public string Email { get; set; }

        public string CVUrl { get; set; }
        public string Position { get; set; }
        public string CVDescription { get; set; }
        public string ImageUrl { get; set; }
        public string NationalIDImageUrl { get; set; }
        public Nullable<long> CEOId { get; set; }
    } 
}

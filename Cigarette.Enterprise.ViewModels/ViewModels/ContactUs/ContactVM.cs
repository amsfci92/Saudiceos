using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.ContactUs
{
    public class ContactVM
    {
        [Required]
        public string Email { get; set; }

        public string Phone { get; set; }
        [Required] 
        public string Subject { get; set; }

        [Required]
        public string Message { get; set; }
        [Required] 
        public string Name { get; set; }
    }
}

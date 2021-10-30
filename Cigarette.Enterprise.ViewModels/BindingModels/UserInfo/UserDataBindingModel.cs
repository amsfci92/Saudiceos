using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.BindingModels.UserInfo
{
    public class UserDataBindingModel
    {
        [Required]
        public string FirstName { get; set; }
        //[Required]
        public string SecondName { get; set; }
        //[Phone]
        //[Required]
        public string Phone { get; set; }
        //[EmailAddress]
        //[Required]
        public string Email { get; set; }
    }
}

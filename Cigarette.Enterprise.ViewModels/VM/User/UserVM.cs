using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.VM.User
{
    public class UserVM
    {
        public UserVM()
        {
        }
        public string Id { get; set; }
        [Required(ErrorMessage = "الهاتف مطلوب")]
        public string Phone { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "البريد الالكتروني مطلوب")]
        public string Email { get; set; }
        public string Image { get; set; }
        [Required(ErrorMessage = "الاسم مطلوب")]
        public string Name { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "كلمه المرور لابد ان تكةن 6 حروف,ارقام علي الاقل", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "كلمه المارور وتاكيد كلمه المرور لا تتطابقان")]
        public string ConfirmPassword { get; set; }
        public bool Active { get; set; }
        public string ImageUrl { get; set; }
    }
}

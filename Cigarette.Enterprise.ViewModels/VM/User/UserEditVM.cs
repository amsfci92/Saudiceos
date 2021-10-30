using System.ComponentModel.DataAnnotations;

namespace Cigarette.Enterprise.ViewModels.VM.User
{
    public class UserEditVM
    {
        public UserEditVM()
        {
        }
        public string Id { get; set; }
        [Required(ErrorMessage = "الهاتف مطلوب")]
        public string Phone { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage = "البريد الالكتروني مطلوب")]
        public string Email { get; set; } 
        [Required(ErrorMessage = "الاسم مطلوب")]
        public string Name { get; set; }  
        public bool Active { get; set; }
        public string ImageUrl { get; set; }
    }
}

using Cigarette.Enterprise.ResourceManager.LanguagesResourceFiles;
using Cigarette.Enterprise.ViewModels.ViewModels.AdminViewModels.Country;
using Cigarette.Enterprise.ViewModels.ViewModels.Country;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.ContactUs
{
    public class ContactUsBM
    {
        [EmailAddress(ErrorMessageResourceType = typeof(HomeResource), ErrorMessageResourceName = "email_invalid")]

        [Display(Name = "email", ResourceType = typeof(HomeResource))]
        [Required(ErrorMessageResourceType = typeof(HomeResource), ErrorMessageResourceName = "required")]

        public string Email { get; set; } 
        [Required(ErrorMessageResourceType = typeof(HomeResource), ErrorMessageResourceName = "required")]

        [Display(Name = "UserPhone", ResourceType = typeof(HomeResource))]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^[-_, #+0-9]*$", ErrorMessage = "Not a valid phone number")]
        //[RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Not a valid phone number")]
        public string Phone { get; set; }
        [Required(ErrorMessageResourceType = typeof(HomeResource), ErrorMessageResourceName = "contactus_please_add_message")]
        [Display(Name = "contact_message", ResourceType = typeof(HomeResource))]
        public string Message { get; set; }
        public int CountryId { get; set; }

    }
}

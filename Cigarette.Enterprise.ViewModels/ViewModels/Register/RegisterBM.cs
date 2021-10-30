using Cigarette.Enterprise.ResourceManager.LanguagesResourceFiles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cigarette.Enterprise.ViewModels.ViewModels.Register
{
    public class RegisterBM
    {

        [Display(ResourceType = typeof(HomeResource), Name = "UserName")]
        [Required(ErrorMessageResourceType = typeof(HomeResource), ErrorMessageResourceName = "W_Registeration_FirstName_Required")]
        public string FirstName { get; set; }

        [Display(ResourceType = typeof(HomeResource), Name = "W_Registeration_SecondName")]
        public string SecondName { get; set; }

        [Display(ResourceType = typeof(HomeResource), Name = "W_Registeration_Country")]
        [Required(ErrorMessageResourceType = typeof(HomeResource), ErrorMessageResourceName = "W_Registeration_Country_Required")]
        public int CountryId { get; set; }

        [Display(ResourceType = typeof(HomeResource), Name = "W_Register_Phone")]
        [Required(ErrorMessageResourceType = typeof(HomeResource), ErrorMessageResourceName = "W_Registeration_Phone_Required")]
        //[RegularExpression("(01)[0-9]{9}", ErrorMessageResourceType = typeof(HomeResource), ErrorMessageResourceName = "W_Registeration_Phone_NotValid")]
        [MinLength(8, ErrorMessageResourceType = typeof(HomeResource), ErrorMessageResourceName = "W_Registeration_Phone_Short")]
        public string Phone { get; set; }
         
        [MinLength(6, ErrorMessageResourceType = typeof(HomeResource),
            ErrorMessageResourceName = "W_Registeration_PasswordNotValid_Required")]
        [Display(ResourceType = typeof(HomeResource), Name = "W_Registeration_Password_Required")]
        [Required(ErrorMessageResourceType = typeof(HomeResource), ErrorMessageResourceName = "W_Registeration_PasswordNotvalid")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(ResourceType = typeof(HomeResource), Name = "W_Registeration_Password_Confirm")]
        [Required(ErrorMessageResourceType = typeof(HomeResource), ErrorMessageResourceName = "W_Registeration_PasswordConfirm_Required")]
        [Compare("Password", ErrorMessageResourceType = typeof(HomeResource), ErrorMessageResourceName = "W_Registeration_Password_DonMatch")]
        public string ConfirmPassword { get; set; }
    }
}

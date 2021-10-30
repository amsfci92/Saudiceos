using Cigarette.Enterprise.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Saudiceos.Enterprise.Web.Areas.AdminPanel.Models.AuthBindingModel
{
    public class AddUserRoleBindingModel : BaseModel
    {
        [Required]
        public string RoleName { get; set; } 
    }
}
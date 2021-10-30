using Cigarette.Enterprise.ViewModels;

namespace Saudiceos.Enterprise.Web.Areas.AdminPanel.Models.AuthBindingModel
{
    public class AssignUserRoleBindingModel : BaseModel
    {
        public string RoleId { get; set; }
        public string UserId { get; set; }
        public string RoleType { get; set; } 
    }
}
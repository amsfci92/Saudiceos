using System.Collections.Generic;
using Saudiceos.Enterprise.Web.Areas.AdminPanel.Models.AuthBindingModel;
using Saudiceos.Enterprise.Web.Areas.AdminPanel.Models.AuthViewModel;

namespace Saudiceos.Enterprise.Web.Areas.AdminPanel.AuthServices.UserRoleService
{
    public interface IUserRoleService
    {
        bool AssignUserRole(AssignUserRoleBindingModel userRoleBindingModel);
        void AddNewRole(AddUserRoleBindingModel userRoleBindingModel);
        List<UserRoleListItemViewModel> GetAllRoles();
        bool DeleteUserRoles(string roleId);

    }
}
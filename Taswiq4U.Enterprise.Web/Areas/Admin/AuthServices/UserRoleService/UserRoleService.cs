using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Saudiceos.Enterprise.Web.Areas.AdminPanel.Models.AuthBindingModel;
using Saudiceos.Enterprise.Web.Areas.AdminPanel.Models.AuthViewModel;
using Saudiceos.Enterprise.Web.Models;

namespace Saudiceos.Enterprise.Web.Areas.AdminPanel.AuthServices.UserRoleService
{
    public class UserRoleService : IUserRoleService
    {
        ApplicationDbContext _context;
        private RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> userManager;

        public UserRoleService()
        {
            _context = new ApplicationDbContext();
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context)); 
        }

        // In this method we will create default User roles and Admin user for login    
        public bool AssignUserRole(AssignUserRoleBindingModel userRoleBindingModel)
        {
            
            // Check if User Exists
            var userCheck = userManager.FindById(userRoleBindingModel.UserId);

            if (userCheck == null)
            {
                return  false;
            }
            //Here we create a Admin super user who will maintain the website                   

            //Add default User to the passed Role     
            var result1 = userManager.AddToRole(userRoleBindingModel.UserId, userRoleBindingModel.RoleType);

            if (result1.Succeeded)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        // In this method we will create default User roles and Admin user for login    
        public void AddNewRole(AddUserRoleBindingModel userRoleBindingModel)
        {
            
            // In Startup iam creating first Admin Role and creating a default Admin User     
            if (!roleManager.RoleExists("Admin"))
            {

                // first we create Admin rool    
                var role = new IdentityRole();
                role.Name = "Admin";
                roleManager.Create(role);
            }
            else
            { 
                // first we create Admin rool    
                var role = new IdentityRole();
                role.Name = userRoleBindingModel.RoleName;
                roleManager.Create(role);
            }
        
        }

        public List<UserRoleListItemViewModel> GetAllRoles()
        {
            var roles = roleManager.Roles;

            var rolesModel = roles.Select(m =>
            new UserRoleListItemViewModel
            {
                RoleName = m.Name,
                Id = m.Id
            }).ToList();

            return rolesModel;
        }

        public bool DeleteUserRoles(string roleId)
        {
            var role = roleManager.FindById(roleId);

            if (role == null) return false;

            var roles = roleManager.Delete(role);

            return true;
        }
    }
}
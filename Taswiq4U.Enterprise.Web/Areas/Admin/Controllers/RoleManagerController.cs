using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Saudiceos.Enterprise.Web.Areas.AdminPanel.AuthServices.UserRoleService;
using Saudiceos.Enterprise.Web.Areas.AdminPanel.Models.AuthBindingModel;

namespace Saudiceos.Enterprise.Web.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,CountryAdmin")]
    public class RoleManagerController : Controller
    {
        public IUserRoleService userRoleService { get; set; }
        public RoleManagerController(IUserRoleService userRoleService)
        {
            this.userRoleService = userRoleService;
        }

        [HttpGet]
        public ActionResult UserRoles()
        {
            var roles = userRoleService.GetAllRoles();
            return View(roles);
        }

        [HttpGet]
        public ActionResult AddUserRoles()
        {
            if (!ModelState.IsValid)
            {
                return View(userRoleService);
            }

            return View();
        }

        [HttpPost]
        public ActionResult AddUserRoles(AddUserRoleBindingModel userRoleBindingModel)
        {
            if (!ModelState.IsValid)
            {
                return View(userRoleService);
            }

            userRoleService.AddNewRole(userRoleBindingModel);
            return RedirectToRoute("Admin.UserRoles.All");
        }

        [HttpGet]
        public ActionResult UpdateUserRoles(string roleId)
        {
            return View();
        }

        [HttpGet]
        public ActionResult DeleteUserRoles(string roleId)
        {
            userRoleService.DeleteUserRoles(roleId);
            return RedirectToRoute("Admin.UserRoles.All");
        }
    }
}
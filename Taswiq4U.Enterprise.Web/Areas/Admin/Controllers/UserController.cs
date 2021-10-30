 
using Cigarette.Enterprise.ResourceManager.Helpers;
using Cigarette.Enterprise.ViewModels.ViewModels.CountryAdmin;
using Cigarette.Enterprise.ViewModels.ViewModels.UserInfo;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Saudiceos.Enterprise.Web.Models;
using Cigarette.Enterprise.BLL.UserServ;
using Saudiceos.Enterprise.Web.Areas.Admin.Controllers;
using Cigarette.Enterprise.ViewModels.VM.User;
using Cigarette.Enterprise.Extentions.ExtentionMethods.HttpFileBase;
using Cigarette.Enterprise.DAL;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security.DataProtection;

namespace Saudiceos.Enterprise.Web.Areas.AdminPanel.Controllers
{ 
    [RouteArea("admin")]
    [RoutePrefix("user")]
    [Authorize()]
    public class UserController : BaseController
    { 
        ApplicationDbContext _context;
        private RoleManager<IdentityRole> roleManager;
        private UserManager<ApplicationUser> userManager;
        private IUserService _userService;
        public UserController()
        {
             
            _context = new ApplicationDbContext();
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
        }

        #region Ctor
        public UserController(IUserService userService)
        {
            _userService = userService;
            _context = new ApplicationDbContext();
            roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(_context));
            userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(_context));
        }
        #endregion

        #region Methods  
        [HttpGet]
        [Route("all")]
        [Authorize(Roles = Permissions.User_ViewAll)]

        public ActionResult List()
        {
            var news = _userService.GetAll();
            if (news.Data != null)
            {
                foreach (var item in news.Data)
                {
                    item.DeleteAllowed = !userManager.IsInRole(item.Id, Permissions.User_Permission);
                }
            }
            return View("usersList", news.Data);
        }
        [Route("View/{encodedId}")]
        [Authorize(Roles = Permissions.User_ViewAll)]

        public ActionResult Details(string encodedId)
        {
            var id = GetIdGUID(encodedId);
            if (id == null)
            {
                return HttpNotFound();
            }
            var model = _userService.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }

            return View("Details", model);
        }

        [Route("new")]
        [Authorize(Roles = Permissions.User_ADD)]

        public ActionResult New()
        {
            var model = new UserVM();
            return View("Add", model);
        }

        [Route("new")]
        [HttpPost]
        [Authorize(Roles = Permissions.User_ADD)]

        public async Task<ActionResult> NewAsync(UserVM vm)
        {
            if (!ModelState.IsValid)
                return View("Add", vm);
             
            var user = new ApplicationUser()
            {
                Email = vm.Email,
                UserName = vm.Email,
                Type = 2,
                Phone = vm.Phone,
                PhoneNumber = vm.Phone,
                Name = vm.Name, 
                IsActive = vm.Active, 
                CreationTime = DateTime.Now,
                Image = vm.ImageUrl,
                PhoneNumberConfirmed = true,
                PhoneVerifyToken = string.Empty

            };
            userManager.UserValidator = new UserValidator<ApplicationUser>(userManager)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = false,

            };

            // Configure validation logic for passwords
            userManager.PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireNonLetterOrDigit = false,
                RequireDigit = false,
                RequireLowercase = false,
                RequireUppercase = false,
            };


            // Configure user lockout defaults
            userManager.UserLockoutEnabledByDefault = true;
            userManager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            userManager.MaxFailedAccessAttemptsBeforeLockout = 5;
            try
            {
                var found = await userManager.FindByEmailAsync(user.Email); 

                if (found != null )
                {
                    ModelState.AddModelError("", "هذا البريد مسجل بالفعل");
                    return View("Add", vm);
                }

                var result = await userManager.CreateAsync(user, vm.Password);

                if (result.Succeeded)
                {
                    SaveImageThenClearTemp(vm.ImageUrl, ImageType.User);
                    SetSuccessMessage("تم الحفظ بنجاح");
                    return RedirectToAction("List");
                }
                else  
                {
                    ModelState.AddModelError("", "حدث خطا اثناء التسجيل حاول مره اخري");
                    return View("Add", vm);
                }
            }catch(Exception e)
            {
                ModelState.AddModelError("", "حدث خطا اثناء التسجيل حاول مره اخري");
                return View("Add", vm);
            }
        }
 
        [Route("edit/{encodedId}")]
        [Authorize(Roles = Permissions.User_Update)]

        public ActionResult Edit(string encodedId)
        {
            var id = GetIdGUID(encodedId);
            if (id == null)
            {
                return HttpNotFound();
            }
            var model = _userService.GetAsNoTracking(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            var vm = new UserEditVM
            {
                Id= model.Id,
                Email= model.Email,
                Active= model.IsActive??false,
                Name= model.Name,
                Phone= model.PhoneNumber,
                ImageUrl= model.Image,
                UserName= model.Email, 
            };

            if (vm.ImageUrl != null)
                SaveImageToTemp(vm.ImageUrl, ImageType.User);

            return View("Edit", vm);
        }

        [Route("edit")]
        [HttpPost]
        [Authorize(Roles = Permissions.User_Update)]

        public async Task<ActionResult> EditAsync(UserEditVM vm)
        {
            if (!ModelState.IsValid)
                return View("Edit", vm);
            var current = _userService.GetAsNoTracking(vm.Id);
            var model = new ApplicationUser 
            {
                Id = vm.Id,
                Email = vm.Email,
                UserName = vm.Email,
                Type = 2,
                PhoneNumber = vm.Phone,
                Phone = vm.Phone,
                Name = vm.Name,
                IsActive = vm.Active,
                PhoneNumberConfirmed = true,
                PhoneVerifyToken = string.Empty,
                Image = vm.ImageUrl,
                PasswordHash = current.PasswordHash,
                NotificationToken = current.PasswordHash,
                MembershipType =           current.MembershipType,
                AccessFailedCount =        current.AccessFailedCount      ,
                PasswordVerifyToken =      current.PasswordVerifyToken    ,
                ResetPasswordToken =       current.ResetPasswordToken     ,
                SecondName =               current.SecondName             ,
                TokenExpiredDate =         current.TokenExpiredDate       ,
                PasswordTokenExpiredDate = current.PasswordTokenExpiredDate,
                LockoutEnabled =           current.LockoutEnabled         ,
                LastSeen =                 current.LastSeen               ,
                FirstName =                current.FirstName              ,
                CountryId =                current.CountryId              ,
                CreationTime =             current.CreationTime           ,
                SecurityStamp =            current.SecurityStamp          ,
                EmailConfirmed =           current.EmailConfirmed         ,
                Address =                  current.Address                ,
                CanAddAds =                current.CanAddAds              ,
                CityId =                   current.CityId                 ,
                TwoFactorEnabled =         current.TwoFactorEnabled       ,
                FreeAdCount =              current.FreeAdCount            ,
                LockoutEndDateUtc =        current.LockoutEndDateUtc      ,

            };

            var found = _userService.Exists(model.Id, model.Email);  
            if (found)
            {
                ModelState.AddModelError("Email", "هذا البريد مستخدم من قبل");
                return View("Edit", vm);
            }
            _context.Entry(model).State = System.Data.Entity.EntityState.Modified;
            int result = _context.SaveChanges(); 

            if (result == 0)
            {
                ModelState.AddModelError("", "لم يتم التحديث حاول مره اخري");
                return View("Edit", vm);

            }

            if(model.Image != null)
                SaveImageThenClearTemp(model.Image, ImageType.User);
            SetSuccessMessage("تم الحفظ بنجاح");

            return RedirectToAction("List");
        }

        [Route("del")]
        [Authorize(Roles = Permissions.User_Delete)]

        public ActionResult Delete(string encodedIds)
        {
            var ids = GetGUIDs(encodedIds);
            if (ids.Count() == 0)
            {
                return Json(new { deleted = false }, JsonRequestBehavior.AllowGet);
            }
            var result = _userService.DeleteRange(ids);
            return Json(new { deleted = result }, JsonRequestBehavior.AllowGet);
        }
         
        [AllowAnonymous]
        [Route("passreset/{encodedId}")]
        [Authorize(Roles = Permissions.User_PassReset)]

        public ActionResult ResetPassword(string encodedId)
        {
            var id = GetIdGUID(encodedId);
            if (id == null)
            {
                return HttpNotFound();
            }
            var model = _userService.Get(id);
            if (model == null)
            {
                return HttpNotFound();
            }
            var vm = new ResetPasswordViewModel
            {
                Id = model.Id, 
                Name = model.Name
            };

            return View("ResetPassword", vm);
        }
         
        [HttpPost]
        [Route("passreset")]
        [Authorize(Roles = Permissions.User_PassReset)]
        public async Task<ActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            var user = await userManager.FindByIdAsync(model.Id);
            if (user == null)
            {
                return HttpNotFound();
            }
            var hashedPass = userManager.PasswordHasher.HashPassword(model.Password);
            user.PasswordHash = hashedPass;
            var result = await userManager.UpdateAsync(user);
            if (result.Succeeded)
            {
                var redirectLink = $"/admin/user/view/{GetB64Id(user.Id)}";
                SetSuccessMessage( "تم تغيير كلمه المرور بنجاح");
                return RedirectPermanent(redirectLink);
            } 
            return View();
        }
        [HttpGet]
        [Route("assign/{encodedId}")]
        [Authorize(Roles = Permissions.User_Permission)]
        public ActionResult AssignPermission(string encodedId)
        {
            var userId = GetIdGUID(encodedId);
            if (userId == null)
            {
                return HttpNotFound();
            }
            if (userManager.FindById(userId) != null)
            {
                ViewBag.UserId = userId;
            var userPermissions = userManager.GetRoles(userId);
                return View("UserPermissions", userPermissions);
            }
            return HttpNotFound();
        }
        [HttpPost]
        [Route("assign/{userId}/{type}")]
       [Authorize(Roles = Permissions.User_Permission)]
        public ActionResult AssignPermission(string model, string userId, bool type)
        {
            CreateRoles();
            if (roleManager.RoleExists(model) && userManager.FindById(userId) != null)
            {
                if (userManager.IsInRole(userId, model) && !type)
                {
                    var result = userManager.RemoveFromRole(userId, model);
                    if (!result.Succeeded)
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                }
                else if (!userManager.IsInRole(userId, model) && type)
                {
                    var result = userManager.AddToRole(userId, model);
                    if (!result.Succeeded)
                    {
                        return Json(false, JsonRequestBehavior.AllowGet);
                    }
                }

            }

            return Json(true, JsonRequestBehavior.AllowGet);
        }
        private void CreateRoles()
        {
            var roles = new List<string>();
            roles.AddRange(Permissions.Service_All.Split(','));
            roles.AddRange(Permissions.CEO_All.Split(','));
            roles.AddRange(Permissions.Banner_All.Split(','));
            roles.AddRange(Permissions.User_All.Split(','));
            roles.AddRange(Permissions.Settings_All.Split(','));
            roles.AddRange(Permissions.Inbox_All.Split(','));
            roles.AddRange(Permissions.Report_All.Split(','));
            roles.AddRange(Permissions.News_All.Split(','));
            roles.AddRange(Permissions.Dashboard_All.Split(','));

            foreach (var item in roles)
            {
                if (!roleManager.RoleExists(item))
                {
                    var result = roleManager.Create(new IdentityRole(item));
                }
            }
        }
        #endregion Methods
    }
}
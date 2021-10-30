using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Cigarette.Enterprise.ViewModels.ViewModels.Country;
using Cigarette.Enterprise.ViewModels.ViewModels.CountryAdmin;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Saudiceos.Enterprise.Web.Attributes;

namespace Saudiceos.Enterprise.Web.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public ApplicationUser()
        { 
        }
        public string PhoneVerifyToken { get; set; }
        public DateTime? TokenExpiredDate { get; set; }
        public string PasswordVerifyToken { get; set; }
        public DateTime? PasswordTokenExpiredDate { get; set; }
         
        public string ResetPasswordToken { get; set; }
        [Required(ErrorMessage = "الهاتف مطلوب")]

        public string Phone { get; set; }
        [Required(ErrorMessage = "البريد الالكتروني مطلوب")]

        public override string Email { get; set; }
        public string Address { get; set; }
        public Nullable<int> CityId { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreationTime { get; set; }
        public Nullable<System.DateTime> LastSeen { get; set; } 
        public string Image { get; set; }
        public Nullable<bool> CanAddAds { get; set; }
        public Nullable<bool> MembershipType { get; set; }
        [Required(ErrorMessage = "الاسم مطلوب")]

        public string Name { get; set; }
        public string NotificationToken { get; set; }

        public Nullable<int> FreeAdCount { get; set; }
        public string FirstName { get; set; }
        public string SecondName { get; set; }
         
        public int? CountryId { get; set; }
        public byte? Type { get; set; }
 
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
 
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("Image", string.IsNullOrWhiteSpace(Image) ? "" : Image));
            userIdentity.AddClaim(new Claim("Name", string.IsNullOrWhiteSpace(Name) ? "" : Name));
            userIdentity.AddClaim(new Claim("SecondName", string.IsNullOrWhiteSpace(SecondName) ? "" : SecondName));
            userIdentity.AddClaim(new Claim("PhoneNumber", string.IsNullOrWhiteSpace(PhoneNumber) ? "" : PhoneNumber));
            userIdentity.AddClaim(new Claim("UserPermissions", string.IsNullOrWhiteSpace(PhoneNumber) ? "" : PhoneNumber));
            
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("SaudiceosAuthDB", throwIfV1Schema: false)
        {
        }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext(); 
        }

    }

    public static class IdentityExtensions
    {
        public static bool HasPermissions(this IIdentity identity, string permission)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }

            var ci = identity as ClaimsIdentity;
            var userPermissions = string.Empty;

            if (ci != null)
            {
                userPermissions = ci.FindFirstValue("UserPermissions");
            } 

            if(!string.IsNullOrWhiteSpace(userPermissions))
            {
                var permissionsPermissionsList = new List<string>(userPermissions.Split(','));

                return permissionsPermissionsList.Any(m => m == permission);
            }
            return false;
        }

        public static string GetCountryId(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var ci = identity as ClaimsIdentity;
            if (ci != null)
            {
                return ci.FindFirstValue("CountryId");
            }
            return null;
        }
        public static string GetImage(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var ci = identity as ClaimsIdentity;
            if (ci != null)
            {
                return ci.FindFirstValue("Image");
            }
            return null;
        }

        public static string GetPhoneNumber(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var ci = identity as ClaimsIdentity;
            if (ci != null)
            {
                return ci.FindFirstValue("PhoneNumber");
            }
            return null;
        }

        public static string GetFullName(this IIdentity identity)
        {
            if (identity == null)
            {
                throw new ArgumentNullException("identity");
            }
            var ci = identity as ClaimsIdentity;
            if (ci != null)
            {
                return string.Format("{0}", ci.FindFirstValue("Name") ?? string.Empty);
            }
            return null;
        }
    }

}

 
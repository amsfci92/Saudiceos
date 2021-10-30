using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Cigarette.Enterprise.DAL;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;

namespace Taswiq4U.Enterprise.WebApi.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
 
        public string PhoneVerifyToken { get; set; }
        public string ResetPasswordToken { get; set; }
    
        public string Phone { get; set; }
        public string Address { get; set; }
        public Nullable<int> CountryId { get; set; }
        public Nullable<int> CityId { get; set; }
        public Nullable<bool> IsActive { get; set; }
        public Nullable<System.DateTime> CreationTime { get; set; }
        public Nullable<System.DateTime> LastSeen { get; set; }
        public string Image { get; set; }
        public Nullable<bool> CanAddAds { get; set; }
        public Nullable<bool> MembershipType { get; set; }
        public string Name { get;  set; }
        public string NotificationToken { get; set; }
         
        public Nullable<int> FreeAdCount { get; set; }
        public Nullable<byte> Type { get; set; } 
        public string FirstName { get; set; }
        public string SecondName { get; set; }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager, string authenticationType)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, authenticationType);
            // Add custom user claims here
            userIdentity.AddClaim(new Claim("CountryId", CountryId?.ToString()));
            userIdentity.AddClaim(new Claim("PhoneNumber", Phone?.ToString()));
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("TaswiqAuthDB", throwIfV1Schema: false)
        {
        }
        
        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }

    public static class IdentityExtensions
    {
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
    }
}
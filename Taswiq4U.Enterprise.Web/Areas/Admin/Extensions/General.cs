using Saudiceos.Enterprise.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace System
{
    public static class General
    {
        public static string Base64Encode(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

        public static ApplicationUser GetUser(this HttpSessionStateBase httpSessionStateBase)
        {
            if(httpSessionStateBase.Count > 0 && httpSessionStateBase["User"] != null)
            {
                return (ApplicationUser)httpSessionStateBase["User"];
            }

            return null;
        }
        public static bool IsRolesAny(this IPrincipal principal, params string[] roles)
        {
            foreach (var item in roles)
            {
                foreach (var role in item.Split(','))
                {
                    if (principal.IsInRole(role)) return true;
                }
            }

            return false;
        }

        public static bool IsRolesAll(this IPrincipal principal, params string[] roles)
        {
            foreach (var item in roles)
            {
                foreach (var role in item.Split(','))
                {
                    if (!principal.IsInRole(role)) return false;
                }
            }

            return true;
        }
    }
}
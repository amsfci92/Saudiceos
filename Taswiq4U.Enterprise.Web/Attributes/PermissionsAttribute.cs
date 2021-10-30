using System;
using System.Security.Authentication;
using System.Web.Mvc;

namespace Saudiceos.Enterprise.Web.Attributes
{

    public partial class CountryFilterAttribute
    {
        public class PermissionsAttribute : ActionFilterAttribute
        {
            private readonly Permissions required;

            public PermissionsAttribute(Permissions required)
            {
                this.required = required;
            }

            public override void OnActionExecuting(ActionExecutingContext filterContext)
            {
                var user = filterContext.HttpContext.Session.GetUser();
                if (user == null)
                {
                    //send them off to the login page

                    var url = new UrlHelper(filterContext.RequestContext);
                    var loginUrl = url.Content("/");
                    filterContext.HttpContext.Response.Redirect(loginUrl, true);
                }
                else
                {
                  
                }
            }
        }


    }
}

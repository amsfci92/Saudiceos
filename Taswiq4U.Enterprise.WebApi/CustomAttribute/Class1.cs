using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;

namespace Taswiq4U.Enterprise.WebApi.CustomAttribute
{
    public class APIKeyAuthorize : AuthorizeAttribute
    {
        public const string APIKeyConfigured = "saudiceos-api";
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            IEnumerable<string> headerAPIkeyValues = null;
            if (actionContext.Request.RequestUri.Query != null && actionContext.Request.RequestUri.Query.Contains(APIKeyConfigured))
            {
                base.OnAuthorization(actionContext);
            }
            else if (actionContext.Request.Headers.TryGetValues("apiKey", out headerAPIkeyValues))
            {
                var secretKey = headerAPIkeyValues.First();

                if (!string.IsNullOrEmpty(secretKey) && APIKeyConfigured.Equals(secretKey))
                {
                    //base.OnAuthorization(actionContext);
                }
                else
                {
                    actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
                }
            }
            else
            {
                actionContext.Response = new System.Net.Http.HttpResponseMessage(System.Net.HttpStatusCode.Forbidden);
            }

        }

    }
}
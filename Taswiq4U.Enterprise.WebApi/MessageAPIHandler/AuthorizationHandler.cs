using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;

namespace Taswiq4U.Enterprise.WebApi.MessageAPIHandler
{
    public class AuthorizationHandler : DelegatingHandler
    {
        public const string APIKeyConfigured = "saudiceos-api";
        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, CancellationToken cancellationToken)
        {
            IEnumerable<string> headerAPIkeyValues = null;
            if (request.RequestUri.Query != null && request.RequestUri.Query.Contains(APIKeyConfigured))
            {
                return await base.SendAsync(request, cancellationToken);
            }
            if (request.Headers.TryGetValues("apiKey", out headerAPIkeyValues))
            {
                var secretKey = headerAPIkeyValues.First();

                if (!string.IsNullOrEmpty(secretKey) && APIKeyConfigured.Equals(secretKey))
                {
                    return await base.SendAsync(request, cancellationToken);
                }
            }
            return request.CreateResponse(System.Net.HttpStatusCode.Forbidden, "API key is invalid.");
        }

    }

}
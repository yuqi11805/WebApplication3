using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Net;

namespace WebApplication3.MassageHandles
{
    public class APIKeyMassageHandler : DelegatingHandler
    {
        private const String APIKey = "jbhifi-PengYuqi";

        protected override async Task<HttpResponseMessage> SendAsync(HttpRequestMessage httpRequestMessage, CancellationToken cancellationToken)
        {
            bool validkey = false;
            IEnumerable<String> requestHeaders;
            var checkApiKeyExists = httpRequestMessage.Headers.TryGetValues("APIKey", out requestHeaders);
            if (IsSwagger(httpRequestMessage)) {
                validkey = true;
            }
            else if (checkApiKeyExists)
            {
                if (requestHeaders.FirstOrDefault().Equals(APIKey))
                {
                    validkey = true;
                }
            }

            if (!validkey)
            {
                return httpRequestMessage.CreateResponse(HttpStatusCode.Forbidden, "Invalid api key");
            }

            var response = await base.SendAsync(httpRequestMessage, cancellationToken);
            return response;
        }

        private bool IsSwagger(HttpRequestMessage request)
        {
            return request.RequestUri.PathAndQuery.Contains("/swagger");
        }

    }
}
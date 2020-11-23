using Lazlo.Common.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gamification.Platform.SDK.CSharp
{
    public class GamificationClientBase
    {
        protected HttpClient _httpClient;

        protected async Task<HttpResponseMessage> SendAsJsonAsync(
            HttpMethod method,
            string pathAndQuery,
            Guid correlationRefId,
            object request,
            Dictionary<string, string> requestHeaders,
            CancellationToken cancellationToken = default)
        {
            HttpRequestMessage httpreq = new HttpRequestMessage(method, $"{_httpClient.BaseAddress.AbsoluteUri}{pathAndQuery}");

            httpreq.Headers.Add("lazlo-correlationrefid", correlationRefId.ToString());

            if (requestHeaders != null)
            {
                foreach (string key in requestHeaders.Keys)
                {
                    httpreq.Headers.Add(key, requestHeaders[key]);
                }
            }

            if (request == null)
            {
                return await _httpClient.SendAsync(httpreq, cancellationToken).ConfigureAwait(false);
            }

            else
            {
                string json = JsonConvert.SerializeObject(request);

                httpreq.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                return await _httpClient.SendAsync(httpreq, cancellationToken).ConfigureAwait(false);
            }
        }

        protected async Task<string> ExtractResponseErrorAsync(HttpResponseMessage httpResponse)
        {
            if (httpResponse.IsSuccessStatusCode)
            {
                return null;
            }

            if (httpResponse.Content == null)
            {
                return $"Http Response Status Code: {httpResponse.StatusCode}";
            }

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponse<object>>(responseJson);

            if (response == null || response.Error == null)
            {
                return $"Error Response Status Code: {((int)httpResponse.StatusCode)} {httpResponse.StatusCode}. {responseJson}";
            }

            else
            {
                return $"Error Received From Gaming: {response.Error.Message}";
            }
        }
    }
}


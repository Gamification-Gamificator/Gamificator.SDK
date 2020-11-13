using Gamification.Platform.Common;
using Lazlo.Common.Requests;
using Lazlo.Common.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gamification.Platform.SDK.CSharp
{
    public partial class GamificationClient
    {
        protected HttpClient HttpClient { get; set; }

        Uri Uri;

        /// <summary>
        /// ***
        /// Deprecated
        /// ***
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="baseUri"></param>
        public GamificationClient(HttpClient httpClient, string baseUri)
        {
            Uri = new Uri(baseUri.ToLower());

            HttpClient = httpClient;
        }

        public GamificationClient(HttpClient httpClient, Uri baseUri)
        {
            Uri = baseUri;

            HttpClient = httpClient;
        }

        private Uri GetUri(string relativeUri)
        {
            if (Uri.Host == "localhost")
            {
                return new Uri($"{Uri.Scheme}://{Uri.Host}:{Uri.Port}/{relativeUri}");
            }

            else
            {
                return new Uri($"https://{Uri.Host}/{relativeUri}");
            }
        }

        public async Task<bool> ActionCompletedV1Async(
            Guid correlationRefId,
            ActionRequest actionRequest,
            double latitude,
            double longitude,
            CancellationToken cancellationToken = default)
        {
            SmartRequest<ActionRequest> req = new SmartRequest<ActionRequest>
            {
                Data = actionRequest,
                Latitude = latitude,
                Longitude = longitude,
                Uuid = Guid.NewGuid().ToString()
            };

            string requestUrl = GetUri("api/action/completed").AbsoluteUri;

            HttpResponseMessage response = await SendAsJsonAsync(
                HttpMethod.Post,
                requestUrl,
                correlationRefId,
                req,
                null,
                cancellationToken).ConfigureAwait(false);

            var responseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

            //SmartResponse<GenerateSelectionsResponse> smartResponse = JsonConvert.DeserializeObject<SmartResponse<GenerateSelectionsResponse>>(responseJson);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return true;
            }

            return false;
        }

        public async Task<PlayerWebPushSubscription> WebPushSubscriptionRetrieve(
            Guid correlationRefId,
            Guid playerRefId,
            double latitude,
            double longitude,
            CancellationToken cancellationToken = default)
        {
            string requestUrl = GetUri("api/webpush/subscription").AbsoluteUri;

            HttpResponseMessage response = await HttpClient.GetAsync(requestUrl);

            if (response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                var responseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                var subscription = JsonConvert.DeserializeObject<PlayerWebPushSubscription>(responseJson);

                return subscription;
            }

            return null;
        }

        public async Task<bool> WebPushSubscriptionStore(
            Guid correlationRefId,
            PlayerWebPushSubscription playerWebPushSubscription,
            double latitude,
            double longitude,
            CancellationToken cancellationToken = default)
        {
            SmartRequest<PlayerWebPushSubscription> req = new SmartRequest<PlayerWebPushSubscription>
            {
                Data = playerWebPushSubscription,
                Latitude = latitude,
                Longitude = longitude,
                Uuid = Guid.NewGuid().ToString()
            };

            string requestUrl = GetUri("api/webpush/subscription").AbsoluteUri;

            HttpResponseMessage response = await SendAsJsonAsync(
                HttpMethod.Post,
                requestUrl,
                correlationRefId,
                req,
                null,
                cancellationToken).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        private async Task<string> ExtractResponseErrorAsync(HttpResponseMessage httpResponse)
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

        private async Task<HttpResponseMessage> SendAsJsonAsync(
            HttpMethod method,
            string absoluteUri,
            Guid correlationRefId,
            object request,
            Dictionary<string, string> requestHeaders,
            CancellationToken cancellationToken = default)
        {
            HttpRequestMessage httpreq = new HttpRequestMessage(method, absoluteUri);

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
                return await HttpClient.SendAsync(httpreq, cancellationToken).ConfigureAwait(false);
            }

            else
            {
                string json = JsonConvert.SerializeObject(request);

                httpreq.Content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");

                return await HttpClient.SendAsync(httpreq, cancellationToken).ConfigureAwait(false);
            }
        }
    }
}


using Gamification.Platform.Common;
using Lazlo.Common.Requests;
using Lazlo.Common.Responses;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gamification.Platform.SDK.CSharp
{
    public class GamificationClientOptions : IGamificationClientOptions
    {
        public string ApiKey { get; set; }
    }

    //public static class GamificationExtensions
    //{
    //    public static IServiceCollection AddGamificationClient(
    //        this IServiceCollection services, 
    //        IOptions<GamificationClientOptions> gamificationClientOptions,
    //        Uri baseAddress
    //        )
    //    {
    //        services.AddHttpClient<GamificationClient>(c => c.BaseAddress = baseAddress);

    //        services.AddOptions();

    //        services.Configure<GamificationClientOptions>(o => o = gamificationClientOptions.Value);

    //        services.AddTransient<IGamificationClient, GamificationClient>();

    //        return services;
    //    }
    //}

    /// <summary>
    /// The HttpClient.BaseAddress should NOT be part of the GamificationClientOptions
    /// A second instance could be created with a different base address etc
    /// Only those Options associated with ALL instances should be injected in the client
    /// </summary>
    public partial class GamificationClient : IGamificationClient
    {
        private HttpClient _httpClient;

        public GamificationClient(HttpClient httpClient, IOptions<GamificationClientOptions> options)
        {
            _httpClient = httpClient;

            if(!httpClient.DefaultRequestHeaders.Contains("gamificator-apikey"))
            {
                _httpClient.DefaultRequestHeaders.Add("gamificator-apikey", options.Value.ApiKey);
            }
        }

        public async Task<bool> ActionCompletedV1Async(
            Guid correlationRefId,
            string gamificatorApiKey,
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

            string requestUrl = "api/action/completed";

            HttpResponseMessage response = await SendAsJsonAsync(
                HttpMethod.Post,
                requestUrl,
                correlationRefId,
                req,
                new Dictionary<string, string> { { "gamificator-apikey", gamificatorApiKey } },
                cancellationToken).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        private async Task<HttpResponseMessage> SendAsJsonAsync(
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

    }
}


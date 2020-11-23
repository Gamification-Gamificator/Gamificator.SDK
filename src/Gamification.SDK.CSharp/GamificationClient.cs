using Gamification.Platform.Common;
using Lazlo.Common.Requests;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gamification.SDK.CSharp
{
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

    public partial class GamificationClient : GamificationClientBase, IGamificationClient
    {
        public GamificationClient(HttpClient httpClient, IOptions<GamificationClientOptions> options)
        {
            _httpClient = httpClient;

            if (!httpClient.DefaultRequestHeaders.Contains("gamificator-apikey"))
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

            string pathAndQuery = "api/action/completed";

            HttpResponseMessage response = await SendAsJsonAsync(
                HttpMethod.Post,
                pathAndQuery,
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
    }
}


﻿using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Gamification.SDK.Responses;
using Gamification.SDK.CSharp.Abstractions;
using Gamification.SDK.Common;
using Gamification.SDK.Requests;
using Gamification.SDK.CSharp.Clients;

namespace Gamification.SDK.CSharp.Clients
{
    public partial class GamificationClient : GamificationClientBase
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
            SmartRequestV2<ActionRequest> req = new SmartRequestV2<ActionRequest>
            {
                Data = actionRequest,
                Uuid = Guid.NewGuid().ToString()
            };

            string pathAndQuery = "api/v1/action/completed";

            Dictionary<string, string> requestHeaders = new Dictionary<string, string>();

            requestHeaders["gamificator-apikey"] = gamificatorApiKey;

            HttpResponseMessage response = await SendAsJsonAsync(
                HttpMethod.Post,
                pathAndQuery,
                correlationRefId,
                req,
                requestHeaders,
                cancellationToken).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }

        public async Task<PlayerStatisticsResponse> GetPlayerStatisticsV1Async(
            Guid correlationRefId,
            Guid playerRefId,
            double latitude,
            double longitude,
            CancellationToken cancellationToken = default)
        {
            string pathAndQuery = string.Format("api/v1/player/{0}/statistics", playerRefId);

            Dictionary<string, string> requestHeaders = new Dictionary<string, string>();

            requestHeaders["gamificator-apikey"] = playerRefId.ToString();

            HttpResponseMessage response = await SendAsJsonAsync(
                HttpMethod.Get,
                pathAndQuery,
                correlationRefId,
                null,
                requestHeaders,
                cancellationToken).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                var stringifyResponse = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<PlayerStatisticsResponse>(stringifyResponse);
            }

            return null;
        }
    }
}


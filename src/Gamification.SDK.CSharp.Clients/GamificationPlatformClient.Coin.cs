using Gamification.SDK.Common;
using Gamification.SDK.Requests;
using Gamification.SDK.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gamification.SDK.CSharp.Clients
{
    public partial class GamificationPlatformClient
    {
        public async Task<Coin> RetrieveCoinAsync(Guid correlationRefId, Guid coinRefId, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Get,
                            pathAndQuery: $"api/v1/coin/{coinRefId}",
                            correlationRefId: correlationRefId,
                            request: null,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<Coin>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Get Coin failed. ");
        }

        public async Task<List<Coin>> RetrieveAllCoinsAsync(Guid correlationRefId, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Get,
                            pathAndQuery: $"api/v1/coins/all",
                            correlationRefId: correlationRefId,
                            request: null,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<List<Coin>>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Get All Coin failed. ");
        }

        public async Task<Coin> CreateCoinAsync(Guid correlationRefId, CoinCreateRequest coin, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Post,
                            pathAndQuery: $"api/v1/coin",
                            correlationRefId: correlationRefId,
                            request: coin,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<Coin>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Create Coin failed. ");
        }

        public async Task UpdateCoinAsync(Guid correlationRefId, CoinUpdateRequest coin, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Put,
                            pathAndQuery: $"api/v1/coin",
                            correlationRefId: correlationRefId,
                            request: coin,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<string>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return;
            }

            throw new Exception($"Update Coin failed. ");
        }

        public async Task DeleteCoinAsync(Guid correlationRefId, Guid coinRefId, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Delete,
                            pathAndQuery: $"api/v1/coin/{coinRefId}",
                            correlationRefId: correlationRefId,
                            request: null,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<string>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return;
            }

            throw new Exception($"Delete Coin failed. ");
        }

        public async Task<Coin> RetrieveDeletedCoinAsync(Guid correlationRefId, Guid coinRefId, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Get,
                            pathAndQuery: $"api/v1/coin/deleted/{coinRefId}",
                            correlationRefId: correlationRefId,
                            request: null,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<Coin>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Get Deleted Coin failed. ");
        }

        public async Task<List<Coin>> RetrieveDeletedCoinsAsync(Guid correlationRefId, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Get,
                            pathAndQuery: $"api/v1/coins/deleted",
                            correlationRefId: correlationRefId,
                            request: null,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<List<Coin>>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Get Deleted Coins failed. ");
        }
    }
}

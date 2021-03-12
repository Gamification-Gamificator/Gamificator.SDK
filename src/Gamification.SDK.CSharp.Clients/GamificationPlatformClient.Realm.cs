using Gamification.SDK.Common;
using Gamification.SDK.Requests;
using Gamification.SDK.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using ThreeTwoSix.Core;

namespace Gamification.SDK.CSharp.Clients
{
    public partial class GamificationPlatformClient
    {
        public async Task<string> RegisterRealmAsync(Guid correlationRefId, RealmRegisterRequest realmRegisterRequest, CancellationToken cancellationToken = default)
        {
            SmartContextV2<RealmRegisterRequest> smartRequest = new SmartContextV2<RealmRegisterRequest>
            {
                Uuid = Guid.Empty.ToString(),
                Data = realmRegisterRequest
            };

            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Post,
                            pathAndQuery: $"api/v1/realm/register",
                            correlationRefId: correlationRefId,
                            request: smartRequest,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartContextV2<string>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Register Realm failed. ");
        }


        public async Task<Realm> RetrieveRealmAsync(Guid correlationRefId, Guid realmRefId, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Get,
                            pathAndQuery: $"api/v1/realm/{realmRefId}",
                            correlationRefId: correlationRefId,
                            request: null,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<Realm>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Get Realm failed. ");
        }

        public async Task<List<Realm>> RetrieveAllRealmsAsync(Guid correlationRefId, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Get,
                            pathAndQuery: $"api/v1/realms/all",
                            correlationRefId: correlationRefId,
                            request: null,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<List<Realm>>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Get All Realm failed. ");
        }

        public async Task<Realm> CreateRealmAsync(Guid correlationRefId, RealmCreateRequest realm, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Post,
                            pathAndQuery: $"api/v1/realm",
                            correlationRefId: correlationRefId,
                            request: realm,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<Realm>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Create Realm failed. ");
        }

        public async Task UpdateRealmAsync(Guid correlationRefId, RealmUpdateRequest realm, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Put,
                            pathAndQuery: $"api/v1/realm",
                            correlationRefId: correlationRefId,
                            request: realm,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<string>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return;
            }

            throw new Exception($"Update Realm failed. ");
        }

        public async Task DeleteRealmAsync(Guid correlationRefId, Guid realmRefId, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Delete,
                            pathAndQuery: $"api/v1/realm/{realmRefId}",
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

            throw new Exception($"Delete Realm failed. ");
        }

        public async Task<Realm> RetrieveDeletedRealmAsync(Guid correlationRefId, Guid realmRefId, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Get,
                            pathAndQuery: $"api/v1/realm/deleted/{realmRefId}",
                            correlationRefId: correlationRefId,
                            request: null,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<Realm>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Get Deleted Realm failed. ");
        }

        public async Task<List<Realm>> RetrieveDeletedRealmsAsync(Guid correlationRefId, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Get,
                            pathAndQuery: $"api/v1/realms/deleted",
                            correlationRefId: correlationRefId,
                            request: null,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<List<Realm>>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Get Deleted Realms failed. ");
        }
    }
}

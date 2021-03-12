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
        public async Task<List<Award>> RetrieveAllAwardsAsync(Guid correlationRefId, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Get,
                            pathAndQuery: $"api/v1/awards/all",
                            correlationRefId: correlationRefId,
                            request: null,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<List<Award>>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Get All Award failed. ");
        }

        public async Task<Award> CreateAwardAsync(Guid correlationRefId, AwardCreateRequest award, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Post,
                            pathAndQuery: $"api/v1/award",
                            correlationRefId: correlationRefId,
                            request: award,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<Award>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Create Award failed. ");
        }

        public async Task UpdateAwardAsync(Guid correlationRefId, AwardUpdateRequest award, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Put,
                            pathAndQuery: $"api/v1/award",
                            correlationRefId: correlationRefId,
                            request: award,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<string>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return;
            }

            throw new Exception($"Update Award failed. ");
        }

        public async Task DeleteAwardAsync(Guid correlationRefId, Guid awardRefId, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Delete,
                            pathAndQuery: $"api/v1/award/{awardRefId}",
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

            throw new Exception($"Delete Award failed. ");
        }

        public async Task<Award> RetrieveDeletedAwardAsync(Guid correlationRefId, Guid awardRefId, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Get,
                            pathAndQuery: $"api/v1/award/deleted/{awardRefId}",
                            correlationRefId: correlationRefId,
                            request: null,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<Award>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Get Deleted Award failed. ");
        }

        public async Task<List<Award>> RetrieveDeletedAwardsAsync(Guid correlationRefId, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Get,
                            pathAndQuery: $"api/v1/awards/deleted",
                            correlationRefId: correlationRefId,
                            request: null,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<List<Award>>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Get Deleted Awards failed. ");
        }
    }
}

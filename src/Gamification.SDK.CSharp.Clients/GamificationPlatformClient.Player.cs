using Gamification.SDK.Common;
using Gamification.SDK.Requests;
using Gamification.SDK.Responses;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gamification.SDK.CSharp.Clients
{
    public partial class GamificationPlatformClient
    {
        public async Task<PlayerProfile> RetrievePlayerProfileByIdAsync(Guid correlationRefId, Guid playerRefId, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Get,
                            pathAndQuery: $"api/v1/player/{playerRefId}",
                            correlationRefId: correlationRefId,
                            request: null,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<PlayerProfile>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Get Player Profile by Id failed. ");
        }

        public async Task<PlayerProfile> RetrievePlayerProfileRequestAsync(Guid correlationRefId, PlayerProfileRequest playerProfileRequest, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Post,
                            pathAndQuery: $"api/v1/player/profile",
                            correlationRefId: correlationRefId,
                            request: playerProfileRequest,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<PlayerProfile>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Get Player Profile failed. ");
        }

        public async Task<PlayerProfile> CreatePlayerProfileAsync(Guid correlationRefId, PlayerProfile playerProfile, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Post,
                            pathAndQuery: $"api/v1/player",
                            correlationRefId: correlationRefId,
                            request: playerProfile,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<PlayerProfile>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Create Player Profile failed. ");
        }

        public async Task UpdatePlayerProfileAsync(Guid correlationRefId, PlayerProfile contact, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Put,
                            pathAndQuery: $"api/v1/player",
                            correlationRefId: correlationRefId,
                            request: contact,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<string>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return;
            }

            throw new Exception($"Update Player failed. ");
        }

        public async Task DeletePlayerAsync(Guid correlationRefId, Guid playerRefId, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Delete,
                            pathAndQuery: $"api/v1/player/{playerRefId}",
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

            throw new Exception($"Delete Player failed. ");
        }
    }
}

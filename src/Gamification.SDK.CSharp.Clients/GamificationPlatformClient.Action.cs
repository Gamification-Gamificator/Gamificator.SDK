using Gamification.SDK.Requests;
using Gamification.SDK.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Action = Gamification.SDK.Common.Action;

namespace Gamification.SDK.CSharp.Clients
{
    public partial class GamificationPlatformClient
    {
        public async Task<Action> RetrieveActionAsync(Guid correlationRefId, Guid actionRefId, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Get,
                            pathAndQuery: $"api/v1/action/{actionRefId}",
                            correlationRefId: correlationRefId,
                            request: null,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<Action>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Get Action failed. ");
        }

        public async Task<Action> RetrieveActionByIdAsync(Guid correlationRefId, string actionId, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Get,
                            pathAndQuery: $"api/v1/action/{actionId}",
                            correlationRefId: correlationRefId,
                            request: null,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<Action>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Get Action By Id failed. ");
        }

        public async Task<List<Action>> RetrieveAllActionsAsync(Guid correlationRefId, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Get,
                            pathAndQuery: $"api/v1/actions/all",
                            correlationRefId: correlationRefId,
                            request: null,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<List<Action>>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Get Action failed. ");
        }

        public async Task<Action> CreateActionAsync(Guid correlationRefId, ActionCreateRequest action, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Post,
                            pathAndQuery: $"api/v1/action",
                            correlationRefId: correlationRefId,
                            request: action,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<Action>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Get Action failed. ");
        }

        public async Task UpdateActionAsync(Guid correlationRefId, ActionUpdateRequest action, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Put,
                            pathAndQuery: $"api/v1/action",
                            correlationRefId: correlationRefId,
                            request: action,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<string>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return;
            }

            throw new Exception($"Get Action failed. ");
        }

        public async Task DeleteActionAsync(Guid correlationRefId, Guid actionRefId, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Delete,
                            pathAndQuery: $"api/v1/action/{actionRefId}",
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

            throw new Exception($"Get Action failed. ");
        }

        public async Task<Action> RetrieveDeletedActionAsync(Guid correlationRefId, Guid actionRefId, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Get,
                            pathAndQuery: $"api/v1/action/deleted/{actionRefId}",
                            correlationRefId: correlationRefId,
                            request: null,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<Action>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Get Action failed. ");
        }

        public async Task<List<Action>> RetrieveDeletedActionsAsync(Guid correlationRefId, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Get,
                            pathAndQuery: $"api/v1/actions/deleted",
                            correlationRefId: correlationRefId,
                            request: null,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<List<Action>>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Get Action failed. ");
        }
    }

}

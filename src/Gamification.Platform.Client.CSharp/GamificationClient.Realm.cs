using Gamification.Platform.Common;
using Lazlo.Common;
using Lazlo.Common.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gamification.Platform.SDK.CSharp
{
    public partial class GamificationClient
    {


        public async Task<Realm> RegisterRealmAsync(Guid correlationRefId, Contact contact, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Post,
                            absoluteUri: GetUri($"api/v1/realm").AbsoluteUri,
                            correlationRefId: correlationRefId,
                            request: contact,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponse<Realm>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Register Realm failed. {response.Error.Message}");
        }



        public async Task<Realm> RetrieveRealmAsync(Guid correlationRefId, Guid realmRefId, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Get,
                            absoluteUri: GetUri($"api/v1/realm/{realmRefId}").AbsoluteUri,
                            correlationRefId: correlationRefId,
                            request: null,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponse<Realm>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Get Realm failed. {response.Error.Message}");
        }

        public async Task<List<Realm>> RetrieveAllRealmsAsync(Guid correlationRefId, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Get,
                            absoluteUri: GetUri($"api/v1/realms/all").AbsoluteUri,
                            correlationRefId: correlationRefId,
                            request: null,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponse<List<Realm>>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Get All Realm failed. {response.Error.Message}");
        }

        public async Task<Realm> CreateRealmAsync(Guid correlationRefId, Realm realm, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Post,
                            absoluteUri: GetUri($"api/v1/realm").AbsoluteUri,
                            correlationRefId: correlationRefId,
                            request: realm,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponse<Realm>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Create Realm failed. {response.Error.Message}");
        }

        public async Task UpdateRealmAsync(Guid correlationRefId, Realm realm, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Put,
                            absoluteUri: GetUri($"api/v1/realm").AbsoluteUri,
                            correlationRefId: correlationRefId,
                            request: realm,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponse<string>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return;
            }

            throw new Exception($"Update Realm failed. {response.Error.Message}");
        }

        public async Task DeleteRealmAsync(Guid correlationRefId, Guid realmRefId, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Delete,
                            absoluteUri: GetUri($"api/v1/realm/{realmRefId}").AbsoluteUri,
                            correlationRefId: correlationRefId,
                            request: null,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponse<string>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return;
            }

            throw new Exception($"Delete Realm failed. {response.Error.Message}");
        }

        public async Task<Realm> RetrieveDeletedRealmAsync(Guid correlationRefId, Guid realmRefId, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Get,
                            absoluteUri: GetUri($"api/v1/realm/deleted/{realmRefId}").AbsoluteUri,
                            correlationRefId: correlationRefId,
                            request: null,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponse<Realm>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Get Deleted Realm failed. {response.Error.Message}");
        }

        public async Task<List<Realm>> RetrieveDeletedRealmsAsync(Guid correlationRefId, CancellationToken cancellationToken = default)
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Get,
                            absoluteUri: GetUri($"api/v1/realms/deleted").AbsoluteUri,
                            correlationRefId: correlationRefId,
                            request: null,
                            requestHeaders: null,
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponse<List<Realm>>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Get Deleted Realms failed. {response.Error.Message}");
        }
    }
}

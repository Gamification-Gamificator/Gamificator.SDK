using Gamification.SDK.Common;
using Gamification.SDK.Requests;
using Gamification.SDK.Responses;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gamification.SDK.CSharp
{
    public partial class GamificationClient
    {
        public async Task<Realm> RegisterRealmAsync(
            SmartRequestV2<RealmRegisterRequest> request, 
            CancellationToken cancellationToken = default
            )
        {
            HttpResponseMessage httpResponse = await SendAsJsonAsync(
                            method: HttpMethod.Post,
                            pathAndQuery: $"api/v1/realm/register",
                            correlationRefId: Guid.NewGuid(),
                            request: request,
                            requestHeaders: null, // apiKey is injected
                            cancellationToken).ConfigureAwait(false);

            string responseJson = await httpResponse.Content.ReadAsStringAsync().ConfigureAwait(false);

            var response = JsonConvert.DeserializeObject<SmartResponseV2<Realm>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Register Realm failed. ");
        }
    }
}

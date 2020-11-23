using Gamification.Platform.Common;
using Gamification.Platform.Common.Core;
using Gamification.Platform.Common.Requests;
using Lazlo.Common;
using Lazlo.Common.Requests;
using Lazlo.Common.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Gamification.SDK.CSharp
{
    public partial class GamificationClient
    {
        public async Task<Realm> RegisterRealmAsync(
            SmartRequest<RealmRegisterRequest> request, 
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

            var response = JsonConvert.DeserializeObject<SmartResponse<Realm>>(responseJson);

            if (httpResponse.IsSuccessStatusCode)
            {
                return response.Data;
            }

            throw new Exception($"Register Realm failed. {response.Error.Message}");
        }
    }
}

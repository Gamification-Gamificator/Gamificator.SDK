using Gamification.Platform.Common;
using Lazlo.Common.Requests;
using Lazlo.Common.Responses;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Action = Gamification.Platform.Common.Action;

namespace Gamification.SDK.CSharp
{
    public partial class GamificationClient
    {

        public async Task<PlayerWebPushSubscription> WebPushSubscriptionRetrieve(
            Guid correlationRefId,
            Guid playerRefId,
            double latitude,
            double longitude,
            CancellationToken cancellationToken = default)
        {
            string requestUrl = "api/webpush/subscription";

            HttpResponseMessage response = await _httpClient.GetAsync(requestUrl);

            if (response.IsSuccessStatusCode)
            {
                var responseJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);

                var subscription = JsonConvert.DeserializeObject<PlayerWebPushSubscription>(responseJson);

                return subscription;
            }

            return null;
        }

        public async Task<bool> WebPushSubscriptionStore(
            Guid correlationRefId,
            PlayerWebPushSubscription playerWebPushSubscription,
            double latitude,
            double longitude,
            CancellationToken cancellationToken = default)
        {
            SmartRequest<PlayerWebPushSubscription> req = new SmartRequest<PlayerWebPushSubscription>
            {
                Data = playerWebPushSubscription,
                Latitude = latitude,
                Longitude = longitude,
                Uuid = Guid.NewGuid().ToString()
            };

            string requestUrl = "api/webpush/subscription";

            HttpResponseMessage response = await SendAsJsonAsync(
                HttpMethod.Post,
                requestUrl,
                correlationRefId,
                req,
                null,
                cancellationToken).ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                return true;
            }

            return false;
        }
    }

}

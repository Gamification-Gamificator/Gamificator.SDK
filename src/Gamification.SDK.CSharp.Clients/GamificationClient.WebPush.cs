using Gamification.SDK.Common;
using Gamification.SDK.Requests;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Gamification.SDK.CSharp.Clients
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
            SmartRequestV2<PlayerWebPushSubscription> req = new SmartRequestV2<PlayerWebPushSubscription>
            {
                Data = playerWebPushSubscription,
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

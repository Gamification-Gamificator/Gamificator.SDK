using Gamification.Platform.Common;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Gamification.SDK.CSharp
{
    public interface IGamificationClient
    {
        Task<bool> ActionCompletedV1Async(Guid correlationRefId, string gamificatorApiKey, ActionRequest actionRequest, double latitude, double longitude, CancellationToken cancellationToken = default);
        Task<PlayerWebPushSubscription> WebPushSubscriptionRetrieve(Guid correlationRefId, Guid playerRefId, double latitude, double longitude, CancellationToken cancellationToken = default);
        Task<bool> WebPushSubscriptionStore(Guid correlationRefId, PlayerWebPushSubscription playerWebPushSubscription, double latitude, double longitude, CancellationToken cancellationToken = default);
    }
}
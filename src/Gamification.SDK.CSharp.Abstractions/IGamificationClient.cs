using Gamification.SDK.Common;
using Gamification.SDK.Requests;
using Gamification.SDK.Responses;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Gamification.SDK.CSharp.Abstractions
{
    public interface IGamificationClient
    {
        Task<bool> ActionCompletedV1Async(Guid correlationRefId, string gamificatorApiKey, ActionRequest actionRequest, double latitude, double longitude, CancellationToken cancellationToken = default);
        Task<Contact> CreateContactAsync(Guid correlationRefId, Contact contact, CancellationToken cancellationToken = default);
        Task DeleteContactAsync(Guid correlationRefId, Guid contactRefId, CancellationToken cancellationToken = default);
        Task<PlayerStatisticsResponse> GetPlayerStatisticsV1Async(Guid correlationRefId, Guid playerRefId, double latitude, double longitude, CancellationToken cancellationToken = default);
        Task<Realm> RegisterRealmAsync(SmartRequestV2<RealmRegisterRequest> request, CancellationToken cancellationToken = default);
        Task<List<Contact>> RetrieveAllContactsAsync(Guid correlationRefId, CancellationToken cancellationToken = default);
        Task<Contact> RetrieveContactAsync(Guid correlationRefId, Guid contactRefId, CancellationToken cancellationToken = default);
        Task<Contact> RetrieveDeletedContactAsync(Guid correlationRefId, Guid contactRefId, CancellationToken cancellationToken = default);
        Task<List<Contact>> RetrieveDeletedContactsAsync(Guid correlationRefId, CancellationToken cancellationToken = default);
        Task UpdateContactAsync(Guid correlationRefId, Contact contact, CancellationToken cancellationToken = default);
        Task<PlayerWebPushSubscription> WebPushSubscriptionRetrieve(Guid correlationRefId, Guid playerRefId, double latitude, double longitude, CancellationToken cancellationToken = default);
        Task<bool> WebPushSubscriptionStore(Guid correlationRefId, PlayerWebPushSubscription playerWebPushSubscription, double latitude, double longitude, CancellationToken cancellationToken = default);
    }
}
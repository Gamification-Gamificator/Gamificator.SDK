using Gamification.Platform.Common;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Gamification.Platform.SDK.CSharp
{

    public interface IGamificationClient
    {
        Task<Common.Action> CreateActionAsync(Guid correlationRefId, Common.Action action, CancellationToken cancellationToken = default);
        Task<Realm> CreateRealmAsync(Guid correlationRefId, Realm realm, CancellationToken cancellationToken = default);
        Task DeleteActionAsync(Guid correlationRefId, Guid actionRefId, CancellationToken cancellationToken = default);
        Task DeleteRealmAsync(Guid correlationRefId, Guid realmRefId, CancellationToken cancellationToken = default);
        Task<Realm> RegisterRealmAsync(Guid correlationRefId, Contact contact, CancellationToken cancellationToken = default);
        Task<Common.Action> RetrieveActionAsync(Guid correlationRefId, Guid actionRefId, CancellationToken cancellationToken = default);
        Task<List<Common.Action>> RetrieveAllActionsAsync(Guid correlationRefId, CancellationToken cancellationToken = default);
        Task<List<Realm>> RetrieveAllRealmsAsync(Guid correlationRefId, CancellationToken cancellationToken = default);
        Task<Common.Action> RetrieveDeletedActionAsync(Guid correlationRefId, Guid actionRefId, CancellationToken cancellationToken = default);
        Task<List<Common.Action>> RetrieveDeletedActionsAsync(Guid correlationRefId, CancellationToken cancellationToken = default);
        Task<Realm> RetrieveDeletedRealmAsync(Guid correlationRefId, Guid realmRefId, CancellationToken cancellationToken = default);
        Task<List<Realm>> RetrieveDeletedRealmsAsync(Guid correlationRefId, CancellationToken cancellationToken = default);
        Task<Realm> RetrieveRealmAsync(Guid correlationRefId, Guid realmRefId, CancellationToken cancellationToken = default);
        Task UpdateActionAsync(Guid correlationRefId, Common.Action action, CancellationToken cancellationToken = default);
        Task UpdateRealmAsync(Guid correlationRefId, Realm realm, CancellationToken cancellationToken = default);
    }
}
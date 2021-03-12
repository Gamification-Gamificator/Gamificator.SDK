using Gamification.SDK.Common;
using Gamification.SDK.Requests;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Action = Gamification.SDK.Common.Action;

namespace Gamification.SDK.CSharp.Clients
{
    public interface IGamificationPlatformClient
    {
        Task<Action> CreateActionAsync(Guid correlationRefId, ActionCreateRequest action, CancellationToken cancellationToken = default);
        Task<Award> CreateAwardAsync(Guid correlationRefId, AwardCreateRequest award, CancellationToken cancellationToken = default);
        Task<Coin> CreateCoinAsync(Guid correlationRefId, CoinCreateRequest coin, CancellationToken cancellationToken = default);
        Task<Contact> CreateContactAsync(Guid correlationRefId, Contact contact, CancellationToken cancellationToken = default);
        Task<Goal> CreateGoalAsync(Guid correlationRefId, GoalCreateRequest goal, CancellationToken cancellationToken = default);
        Task<GoalTrigger> CreateGoalTriggerAsync(Guid correlationRefId, GoalTriggerCreateRequest goalTrigger, CancellationToken cancellationToken = default);
        Task<Realm> CreateRealmAsync(Guid correlationRefId, RealmCreateRequest realm, CancellationToken cancellationToken = default);
        Task DeleteActionAsync(Guid correlationRefId, Guid actionRefId, CancellationToken cancellationToken = default);
        Task DeleteAwardAsync(Guid correlationRefId, Guid awardRefId, CancellationToken cancellationToken = default);
        Task DeleteCoinAsync(Guid correlationRefId, Guid coinRefId, CancellationToken cancellationToken = default);
        Task DeleteContactAsync(Guid correlationRefId, Guid contactRefId, CancellationToken cancellationToken = default);
        Task DeleteGoalAsync(Guid correlationRefId, Guid goalRefId, CancellationToken cancellationToken = default);
        Task DeleteGoalTriggerAsync(Guid correlationRefId, Guid goalTriggerRefId, CancellationToken cancellationToken = default);
        Task DeleteRealmAsync(Guid correlationRefId, Guid realmRefId, CancellationToken cancellationToken = default);
        Task<string> RegisterRealmAsync(Guid correlationRefId, RealmRegisterRequest realmRegisterRequest, CancellationToken cancellationToken = default);
        Task<Common.Action> RetrieveActionAsync(Guid correlationRefId, Guid actionRefId, CancellationToken cancellationToken = default);
        Task<Common.Action> RetrieveActionByIdAsync(Guid correlationRefId, string actionId, CancellationToken cancellationToken = default);
        Task<List<Common.Action>> RetrieveAllActionsAsync(Guid correlationRefId, CancellationToken cancellationToken = default);
        Task<List<Award>> RetrieveAllAwardsAsync(Guid correlationRefId, CancellationToken cancellationToken = default);
        Task<List<Coin>> RetrieveAllCoinsAsync(Guid correlationRefId, CancellationToken cancellationToken = default);
        Task<List<Contact>> RetrieveAllContactsAsync(Guid correlationRefId, CancellationToken cancellationToken = default);
        Task<List<Goal>> RetrieveAllGoalsAsync(Guid correlationRefId, CancellationToken cancellationToken = default);
        Task<List<GoalTrigger>> RetrieveAllGoalTriggersAsync(Guid correlationRefId, CancellationToken cancellationToken = default);
        Task<List<Realm>> RetrieveAllRealmsAsync(Guid correlationRefId, CancellationToken cancellationToken = default);
        Task<Coin> RetrieveCoinAsync(Guid correlationRefId, Guid coinRefId, CancellationToken cancellationToken = default);
        Task<Contact> RetrieveContactAsync(Guid correlationRefId, Guid contactRefId, CancellationToken cancellationToken = default);
        Task<Common.Action> RetrieveDeletedActionAsync(Guid correlationRefId, Guid actionRefId, CancellationToken cancellationToken = default);
        Task<List<Common.Action>> RetrieveDeletedActionsAsync(Guid correlationRefId, CancellationToken cancellationToken = default);
        Task<Award> RetrieveDeletedAwardAsync(Guid correlationRefId, Guid awardRefId, CancellationToken cancellationToken = default);
        Task<List<Award>> RetrieveDeletedAwardsAsync(Guid correlationRefId, CancellationToken cancellationToken = default);
        Task<Coin> RetrieveDeletedCoinAsync(Guid correlationRefId, Guid coinRefId, CancellationToken cancellationToken = default);
        Task<List<Coin>> RetrieveDeletedCoinsAsync(Guid correlationRefId, CancellationToken cancellationToken = default);
        Task<Contact> RetrieveDeletedContactAsync(Guid correlationRefId, Guid contactRefId, CancellationToken cancellationToken = default);
        Task<List<Contact>> RetrieveDeletedContactsAsync(Guid correlationRefId, CancellationToken cancellationToken = default);
        Task<Goal> RetrieveDeletedGoalAsync(Guid correlationRefId, Guid goalRefId, CancellationToken cancellationToken = default);
        Task<List<Goal>> RetrieveDeletedGoalsAsync(Guid correlationRefId, CancellationToken cancellationToken = default);
        Task<GoalTrigger> RetrieveDeletedGoalTriggerAsync(Guid correlationRefId, Guid goalTriggerRefId, CancellationToken cancellationToken = default);
        Task<List<GoalTrigger>> RetrieveDeletedGoalTriggersAsync(Guid correlationRefId, CancellationToken cancellationToken = default);
        Task<Realm> RetrieveDeletedRealmAsync(Guid correlationRefId, Guid realmRefId, CancellationToken cancellationToken = default);
        Task<List<Realm>> RetrieveDeletedRealmsAsync(Guid correlationRefId, CancellationToken cancellationToken = default);
        Task<Goal> RetrieveGoalAsync(Guid correlationRefId, Guid goalRefId, CancellationToken cancellationToken = default);
        Task<GoalTrigger> RetrieveGoalTriggerAsync(Guid correlationRefId, Guid refId, CancellationToken cancellationToken = default);
        Task<Realm> RetrieveRealmAsync(Guid correlationRefId, Guid realmRefId, CancellationToken cancellationToken = default);
        Task UpdateActionAsync(Guid correlationRefId, ActionUpdateRequest action, CancellationToken cancellationToken = default);
        Task UpdateAwardAsync(Guid correlationRefId, AwardUpdateRequest award, CancellationToken cancellationToken = default);
        Task UpdateCoinAsync(Guid correlationRefId, CoinUpdateRequest coin, CancellationToken cancellationToken = default);
        Task UpdateContactAsync(Guid correlationRefId, Contact contact, CancellationToken cancellationToken = default);
        Task UpdateGoalAsync(Guid correlationRefId, GoalUpdateRequest goal, CancellationToken cancellationToken = default);
        Task UpdateGoalTriggerAsync(Guid correlationRefId, GoalTriggerUpdateRequest goalTrigger, CancellationToken cancellationToken = default);
        Task UpdateRealmAsync(Guid correlationRefId, RealmUpdateRequest realm, CancellationToken cancellationToken = default);
    }
}
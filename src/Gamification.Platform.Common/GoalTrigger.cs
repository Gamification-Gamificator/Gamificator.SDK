using Gamification.Platform.Common.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace Gamification.Platform.Common
{
    /// <summary>
    /// A rule defining how a Goal is triggered
    /// The basic Process of Gamification
    /// GoalTriggers process per Player/Tag until a Goal is accomplished OR it expires
    /// </summary>
    public class GoalTrigger : GoalTriggerCore
    {
        /// <summary>
        /// ** New pattern **
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid EntityRefId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// All root entities require RealmRefId for multi-tenancy
        /// </summary>
        [JsonRequired]
        [JsonProperty(PropertyName = "realmRefId")]
        public Guid RealmRefId { get; set; }

        /// <summary>
        /// Goal that is achieved?? whats ana cheivement then
        /// </summary>
        [JsonRequired]
        [JsonProperty(PropertyName = "goalRefId")]
        public Guid GoalRefId { get; set; }

        [JsonProperty(PropertyName = "steps")]
        public TriggerSteps Steps { get; set; } = new TriggerSteps();

        /// <summary>
        /// As multiple Actions per TimeSpan match GoalTriggers, limit the GoalEvents created within Periods
        /// RateLimits effect Qualifying Actions POST GoalTrigger Step calculations
        /// You qualify on the Steps but not on the RateLimit, so we burn the actions on RateLimitRefId
        /// </summary>
        [JsonRequired]
        [JsonProperty(PropertyName = "rateLimitRules")]
        public RateLimitRules RateLimitRules { get; set; } = new RateLimitRules();

        /// <summary>
        /// This Goal triggers a push notification
        /// No PushNotificationTemplate means the Goal only shows in Player State GET
        /// </summary>
        [JsonProperty(PropertyName = "pushNotificationTemplate")]
        public PushNotificationTemplate PushNotificationTemplate { get; set; } = new PushNotificationTemplate();

    }

    public class GoalTriggers : List<GoalTrigger>
    {
        public new void Add(GoalTrigger item)
        {
            if (base.Exists(e => e.GoalRefId == item.GoalRefId && e.Priority == item.Priority))
            {
                throw new ArgumentException($"A {nameof(GoalTrigger)} with the same {nameof(GoalTrigger.Priority)} already exists.");
            }

            if (base.Exists(e => e.GoalRefId == item.GoalRefId && e.SimpleName == item.SimpleName))
            {
                throw new ArgumentException($"A {nameof(GoalTrigger)} with the same {nameof(GoalTrigger.SimpleName)} already exists.");
            }

            base.Add(item);
        }
    }
}

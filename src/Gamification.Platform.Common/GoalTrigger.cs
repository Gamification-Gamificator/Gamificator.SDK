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
        [JsonProperty(PropertyName = "goalTriggerRefId")]
        public Guid GoalTriggerRefId { get { return Id; } set { Id = value; } }

        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; } = Guid.NewGuid();
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
    }

    public class GoalTriggerCore
    {
        [JsonProperty(PropertyName = "simpleName")]
        public string SimpleName { get; set; }

        [JsonProperty(PropertyName = "nameTranslations")]
        public List<StringTranslation> NameTranslations { get; set; } = new List<StringTranslation>();

        [JsonProperty(PropertyName = "isCheckPointed")]
        public bool IsCheckPointed { get; set; }

        [JsonProperty(PropertyName = "steps")]
        public List<TriggerStep> Steps { get; set; } = new List<TriggerStep>();

        /// <summary>
        /// A GoalTrigger with a Tag["Fuu"] will ONLY apply to Player(s) with a Tag["Fuu"]
        /// </summary>
        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags { get; set; } = new List<string>();

        /// <summary>
        /// Priority when multiple GoalTriggers are being evaluated
        /// </summary>
        [JsonProperty(PropertyName = "priority")]
        public int Priority { get; set; }

        /// <summary>
        /// What Actions do we use in this Trigger
        /// How far back to query for Actions from NOW
        /// </summary>
        [JsonProperty(PropertyName = "rollingPeriodActionFilter")]
        public TimeSpan? RollingPeriodActionFilter { get; set; }

        /// <summary>
        /// What Actions do we use in this Trigger
        /// Allow back to Easter
        /// </summary>
        [JsonProperty(PropertyName = "fixedDateActionFilter")]
        public DateTimeOffset? FixedDateActionFilter { get; set; }

        /// <summary>
        /// What Actions do we use in this Trigger
        /// Include Actions already used by an accompished Goal
        /// </summary>
        [JsonProperty(PropertyName = "includeAccomplished")]
        public bool IncludeAccomplished { get; set; }

        /// <summary>
        /// As multiple Actions per TimeSpan match GoalTriggers, limit the GoalEvents created within Periods
        /// RateLimits effect Qualifying Actions POST GoalTrigger Step calculations
        /// You qualify on the Steps but not on the RateLimit, so we burn the actions on RateLimitRefId
        /// </summary>
        [JsonRequired]
        [JsonProperty(PropertyName = "rateLimitRules")]
        public RateLimitRules RateLimitRules { get; set; } = new RateLimitRules();

        /// <summary>
        /// GoalTriggers are released on creation unless extended
        /// </summary>
        [JsonProperty(PropertyName = "releaseOn")]
        public DateTimeOffset ReleaseOn { get; set; } = DateTimeOffset.UtcNow;

        /// <summary>
        /// GoalTriggers can be released early
        /// </summary>
        [JsonProperty(PropertyName = "releasedOn")]
        public DateTimeOffset? ReleasedOn { get; set; }

        /// <summary>
        /// NULL means no expiration
        /// </summary>
        [JsonProperty(PropertyName = "expireOn")]
        public DateTimeOffset? ExpireOn { get; set; }

        /// <summary>
        /// NULL untill > ExpireOn OR manually set
        /// </summary>
        [JsonProperty(PropertyName = "expiredOn")]
        public DateTimeOffset? ExpiredOn { get; set; }
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

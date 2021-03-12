using Gamification.SDK.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using ThreeTwoSix.Core;

namespace Gamification.SDK.Core
{   
    public abstract class GoalTriggerCore
    {
        [JsonProperty(PropertyName = "simpleName")]
        public string SimpleName { get; set; }

        [JsonProperty(PropertyName = "nameTranslations")]
        public StringTranslationsCore NameTranslations { get; set; } = new StringTranslationsCore();

        [JsonProperty(PropertyName = "isCheckPointed")]
        public bool IsCheckPointed { get; set; }

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
        public DateTimeOffset ExpireOn { get; set; } = DateTimeOffset.MaxValue;

        /// <summary>
        /// NULL untill > ExpireOn OR manually set
        /// </summary>
        [JsonProperty(PropertyName = "expiredOn")]
        public DateTimeOffset? ExpiredOn { get; set; }
    }
}

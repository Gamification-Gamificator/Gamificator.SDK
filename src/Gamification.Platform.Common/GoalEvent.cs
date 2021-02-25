using Gamification.Platform.Common.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common
{
    /// <summary>
    /// The Goal instance transaction
    /// </summary>
    public class GoalEvent : GoalEventCore
    {
        [JsonRequired]
        [JsonProperty(PropertyName = "id")]
        public Guid EntityRefId { get; set; }

        [JsonRequired]
        [JsonProperty(PropertyName = "playerRefId")]
        public Guid PlayerRefId { get; set; }

        /// <summary>
        /// All root entities require RealmRefId for multi-tenancy
        /// </summary>
        [JsonRequired]
        [JsonProperty(PropertyName = "realmRefId")]
        public Guid RealmRefId { get; set; }

        [JsonRequired]
        [JsonProperty(PropertyName = "goalRefId")]
        public Guid GoalRefId { get; set; }

        /// <summary>
        /// A Goal is accomplished
        /// </summary>
        [JsonRequired]
        [JsonProperty(PropertyName = "accomplishedOn")]
        public DateTimeOffset AccomplishedOn { get; set; }
    }

    public class GoalEvents : List<GoalEvent>
    {

    }
}

using Gamification.Platform.Common.Core;
using Newtonsoft.Json;
using System;

namespace Gamification.Platform.Common
{
    /// <summary>
    /// The persisted Goal transaction
    /// </summary>
    public class GoalEvent : OccurrenceBase
    {
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
}

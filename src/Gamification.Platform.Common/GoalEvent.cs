using Newtonsoft.Json;
using System;

namespace Gamification.Platform.Common
{
    /// <summary>
    /// The persisted Goal transaction
    /// </summary>
    public class GoalEvent
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
        /// An ActionRequest may occur out of sync with the Action
        /// This is WHEN the Action Occurred NOT when it was sent
        /// </summary>
        [JsonRequired]
        [JsonProperty(PropertyName = "occurredOn")]
        public DateTimeOffset OccurredOn { get; set; }

        /// <summary>
        /// A Goal is accomplished
        /// </summary>
        [JsonRequired]
        [JsonProperty(PropertyName = "accomplishedOn")]
        public DateTimeOffset AccomplishedOn { get; set; }
    }
}

using Newtonsoft.Json;
using System;

namespace Gamification.Platform.Common
{
    /// <summary>
    /// The persisted Goal transaction
    /// </summary>
    public class AchievementEvent
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
        [JsonProperty(PropertyName = "achievementRefId")]
        public Guid AchievementRefId { get; set; }

        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }

        [JsonProperty(PropertyName = "pathPriority")]
        public int PathPriority { get; set; }

        [JsonProperty(PropertyName = "currencyMultiplierRule")]
        public CurrencyMultiplierRule CurrencyMultiplierRule { get; set; }

        /// <summary>
        /// An ActionRequest may occur out of sync with the Action
        /// This is WHEN the Action Occurred NOT when it was sent
        /// </summary>
        [JsonRequired]
        [JsonProperty(PropertyName = "occurredOn")]
        public DateTimeOffset OccurredOn { get; set; }
    }
}

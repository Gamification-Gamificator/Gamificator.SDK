using Gamification.Platform.Common.Core;
using Newtonsoft.Json;
using System;

namespace Gamification.Platform.Common
{
    /// <summary>
    /// The persisted Goal transaction
    /// </summary>
    public class AchievementEvent : OccurrenceBase
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
        public CoinMultiplierRule CurrencyMultiplierRule { get; set; }
    }
}

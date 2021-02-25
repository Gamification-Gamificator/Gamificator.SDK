using Gamification.Platform.Common.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common
{
    /// <summary>
    /// The Achievement instance transaction
    /// </summary>
    public class AchievementEvent : AchievementEventCore
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
        [JsonProperty(PropertyName = "achievementRefId")]
        public Guid AchievementRefId { get; set; }

        [JsonProperty(PropertyName = "currencyMultiplierRule")]
        public CoinMultiplierRule CurrencyMultiplierRule { get; set; }

        [JsonProperty(PropertyName = "createdOn")]
        public DateTimeOffset CreatedOn { get; set; } = DateTimeOffset.UtcNow;

        [JsonProperty(PropertyName = "deletedOn")]
        public DateTimeOffset? DeletedOn { get; set; }
    }

    public class AchievementEvents : List<AchievementEvent>
    {

    }
}

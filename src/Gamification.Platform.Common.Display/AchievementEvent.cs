using Gamification.Platform.Common.Core;
using Newtonsoft.Json;
using System;

namespace Gamification.Platform.Common.Display
{
    /// <summary>
    /// The persisted Goal transaction
    /// </summary>
    public class AchievementEventDisplay : AchievementEventCore
    {
        [JsonRequired]
        [JsonProperty(PropertyName = "id")]
        public Guid EntityRefId { get; set; }

        /// <summary>
        /// This is the Action
        /// </summary>
        [JsonRequired]
        [JsonProperty(PropertyName = "action")]
        public ActionDisplay Action { get; set; }

        //[JsonRequired]
        //[JsonProperty(PropertyName = "player")]
        //public PlayerDisplay Player { get; set; }

        [JsonRequired]
        [JsonProperty(PropertyName = "realm")]
        public RealmDisplay Realm { get; set; }

        [JsonRequired]
        [JsonProperty(PropertyName = "achievement")]
        public AchievementDisplay Achievement { get; set; }

        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }

        [JsonProperty(PropertyName = "pathPriority")]
        public int PathPriority { get; set; }

        [JsonProperty(PropertyName = "currencyMultiplierRule")]
        public CoinMultiplierRuleDisplay CurrencyMultiplierRule { get; set; }
    }
}

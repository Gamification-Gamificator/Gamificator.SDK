using Gamification.SDK.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.SDK.Common
{
    /// <summary>
    /// Result of a Goal, the award
    /// </summary>
    public class Achievement : AchievementCore
    {
        /// <summary>
        /// ** New pattern **
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid EntityRefId { get; set; } = Guid.NewGuid();

        //TODO goals can be ordered, timespan of achievement etc etc
        [JsonProperty(PropertyName = "goals")]
        public List<Guid> Goals { get; set; } = new List<Guid>();

        /// <summary>
        /// Provides a grouping context of the PathPriority
        /// Example: Path = Miles
        /// If yu have achieved Silver AND Gold AND Platinum Achievements, your awards ONLY multiply at the Platinum PathPriority
        /// </summary>
        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }

        /// <summary>
        /// An Achievement can only Multiply Awards based on ONE Achievement
        /// </summary>
        [JsonProperty(PropertyName = "pathPriority")]
        public int PathPriority { get; set; }

        /// <summary>
        /// When achieved, all future Awards of Currency are multiplied
        /// </summary>
        [JsonProperty(PropertyName = "currencyMultiplierRule")]
        public CoinMultiplierRule CurrencyMultiplierRule { get; set; }        
    }
}

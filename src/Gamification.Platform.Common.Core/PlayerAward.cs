using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common.Core
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class PlayerAwardCore : AwardCore
    {
        /// <summary>
        /// If no AwardRefId then why?
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "occurredOn")]
        public DateTimeOffset OccurredOn { get; set; }

        /// <summary>
        /// Ephemeral Award experation
        /// Default from Coin.ExpireIn (Null would be DateTime.MaxValue)
        /// </summary>
        [JsonProperty(PropertyName = "expireOn")]
        public DateTimeOffset ExpireOn { get; set; } = DateTimeOffset.MaxValue;

        /// <summary>
        /// Explicit Ephemeral expiration
        /// </summary>
        [JsonProperty(PropertyName = "expiredOn")]
        public DateTimeOffset? ExpiredOn { get; set; } = DateTimeOffset.MaxValue;
    }

    public class PlayerAwardCores : List<PlayerAwardCore>
    {
        public new void Add(PlayerAwardCore item)
        {
            //TODO Add rules here

            base.Add(item);
        }
    }


}

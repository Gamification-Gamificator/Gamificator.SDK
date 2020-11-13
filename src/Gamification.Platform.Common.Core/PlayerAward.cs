using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common.Core
{
    /// <summary>
    /// 
    /// </summary>
    public class PlayerAwardCore
    {

        [JsonProperty(PropertyName = "value")]
        public decimal Value { get; set; }

        ///// <summary>
        ///// Debit = 1, Credit = 2
        ///// </summary>
        //[JsonProperty(PropertyName = "accountingTransactionType")]
        //public int AccountingTransactionType { get; set; }

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
        public DateTimeOffset ExpireOn { get; set; } = DateTime.MaxValue;

        /// <summary>
        /// Explicit Ephemeral expiration
        /// </summary>
        [JsonProperty(PropertyName = "expireOn")]
        public DateTimeOffset? ExpiredOn { get; set; } = DateTime.MaxValue;
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

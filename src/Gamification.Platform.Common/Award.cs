using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common
{
    /// <summary>
    /// A defined amount of Coin
    /// </summary>
    public class Award : AwardCore
    {
        [JsonProperty(PropertyName = "awardRefId")]
        public Guid AwardRefId { get { return Id; } set { Id = value; } }

        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; } = Guid.NewGuid();
        /// <summary>
        /// All root entities require RealmRefId for multi-tenancy
        /// </summary>
        [JsonRequired]
        [JsonProperty(PropertyName = "realmRefId")]
        public Guid RealmRefId { get; set; }

        [JsonProperty(PropertyName = "CoinRefId")]
        public Guid CoinRefId { get; set; }
    }

    public class AwardCore
    {
        [JsonProperty(PropertyName = "value")]
        public decimal Value { get; set; }
    }

    public class Awards : List<Award>
    {
    }

    public class AwardRule
    {
        [JsonProperty(PropertyName = "awardRefId")]
        public Guid AwardRefId { get; set; }

        /// <summary>
        /// Causes an ActionCheckpoint to be persisted
        /// </summary>
        //[JsonProperty(PropertyName = "actionToCheckpoint")]
        //public Guid? ActionToCheckpoint { get; set; }
    }


    public class AwardRuleDisplay : AwardCore
    {
        [JsonProperty(PropertyName = "actionToCheckpoint")]
        public ActionDisplay ActionToCheckpoint { get; set; }
    }
}

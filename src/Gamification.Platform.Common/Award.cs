using Gamification.Platform.Common.Core;
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
        /// <summary>
        /// ** New pattern **
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid EntityRefId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// All root entities require RealmRefId for multi-tenancy
        /// </summary>
        [JsonRequired]
        [JsonProperty(PropertyName = "realmRefId")]
        public Guid RealmRefId { get; set; }

        [JsonProperty(PropertyName = "CoinRefId")]
        public Guid CoinRefId { get; set; }
    }

    public class Awards : List<Award>
    {
    }

}

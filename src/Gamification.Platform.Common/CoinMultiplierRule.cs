using Gamification.Platform.Common.Core;
using Newtonsoft.Json;
using System;

namespace Gamification.Platform.Common
{
    public class CoinMultiplierRule : CoinMultiplierRuleCore
    {
        [JsonProperty(PropertyName = "coinRefId")]
        public Guid CoinRefId { get; set; }
    }
}

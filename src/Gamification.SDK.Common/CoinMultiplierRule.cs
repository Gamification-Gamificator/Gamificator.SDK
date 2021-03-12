using Gamification.SDK.Core;
using Newtonsoft.Json;
using System;

namespace Gamification.SDK.Common
{
    public class CoinMultiplierRule : CoinMultiplierRuleCore
    {
        [JsonProperty(PropertyName = "coinRefId")]
        public Guid CoinRefId { get; set; }
    }
}

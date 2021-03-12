using Newtonsoft.Json;
using System;

namespace Gamification.SDK.Core
{
    public class CoinMultiplierRuleCore
    {
        [JsonProperty(PropertyName = "multiplier")]
        public decimal Multiplier { get; set; }
    }
}

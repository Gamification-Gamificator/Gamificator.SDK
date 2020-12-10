using Newtonsoft.Json;
using System;

namespace Gamification.Platform.Common.Core
{
    public class CoinMultiplierRuleCore
    {
        [JsonProperty(PropertyName = "multiplier")]
        public decimal Multiplier { get; set; }
    }
}

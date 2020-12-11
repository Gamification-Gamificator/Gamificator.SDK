using Gamification.Platform.Common.Display;
using Newtonsoft.Json;
using System;

namespace Gamification.Platform.Common.Core
{
    public class CoinMultiplierRuleDisplay : CoinMultiplierRuleCore
    { 
        [JsonProperty(PropertyName = "coin")]
        public CoinDisplay Coin { get; set; }
    }
}

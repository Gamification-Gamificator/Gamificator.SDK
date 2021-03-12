using Gamification.SDK.Core;
using Gamification.SDK.Display;
using Newtonsoft.Json;
using System;

namespace Gamification.SDK.Core
{
    public class CoinMultiplierRuleDisplay : CoinMultiplierRuleCore
    { 
        [JsonProperty(PropertyName = "coin")]
        public CoinDisplay Coin { get; set; }
    }
}

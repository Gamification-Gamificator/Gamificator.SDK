using Gamification.SDK.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.SDK.Display
{    
    public class CoinDisplay : CoinCore
    {
    }

    public class CoinBalanceDisplay
    {
        [JsonProperty(PropertyName = "coin")]
        public CoinDisplay Coin { get; set; }

        [JsonProperty(PropertyName = "balance")]
        public decimal Balance { get; set; }

        [JsonProperty(PropertyName = "asOf")]
        public DateTimeOffset AsOf { get; set; } = DateTimeOffset.UtcNow;
    }
}

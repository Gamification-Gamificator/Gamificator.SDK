using Newtonsoft.Json;
using System;

namespace Gamification.Platform.Common
{
    public class CoinMultiplierRule
    {
        [JsonProperty(PropertyName = "coinRefId")]
        public Guid CoinRefId { get; set; }

        [JsonProperty(PropertyName = "multiplier")]
        public decimal Multiplier { get; set; }
    }
}

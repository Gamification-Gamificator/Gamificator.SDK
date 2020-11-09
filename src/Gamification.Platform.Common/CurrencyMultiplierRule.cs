using Newtonsoft.Json;
using System;

namespace Gamification.Platform.Common
{
    public class CurrencyMultiplierRule
    {
        [JsonProperty(PropertyName = "currencyRefId")]
        public Guid CurrencyRefId { get; set; }

        [JsonProperty(PropertyName = "multiplier")]
        public decimal Multiplier { get; set; }
    }
}

using Newtonsoft.Json;
using System;

namespace Gamification.Platform.Common.Core
{
    public class MachineReadablePurchaseRequest
    {
        [JsonProperty(PropertyName = "machineReadableCode")]
        public DateTimeOffset? MachineReadableCode { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName = "price")]
        public PriceItem Price { get; set; }
    }

    public class PriceItem
    {
        /// <summary>
        /// Actual price from sending system (if available)
        /// </summary>
        [JsonProperty(PropertyName = "pricePerQuantity")]
        public decimal? PricePerQuantity { get; set; }

        /// <summary>
        /// Actual price paid from sending system (if available) assuming discounts or promotions
        /// </summary>
        [JsonProperty(PropertyName = "pricePaidPerQuantity")]
        public decimal? PricePaidPerQuantity { get; set; }
    }
}



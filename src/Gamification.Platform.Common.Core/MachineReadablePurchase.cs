using Newtonsoft.Json;

namespace Gamification.Platform.Common.Core
{
    public sealed class MachineReadablePurchase
    {
        /// <summary>
        /// The raw string value emmitted by a POS peripheral (usb/serial scanner, etc)
        /// </summary>
        [JsonProperty(PropertyName = "machineReadableCode")]
        public string MachineReadableCode { get; set; }

        [JsonProperty(PropertyName = "quantity")]
        public int Quantity { get; set; }

        [JsonProperty(PropertyName = "price")]
        public PriceItem Price { get; set; }
    }

    public sealed class PriceItem
    {
        /// <summary>
        /// Actual price from sending system (if available)
        /// </summary>
        [JsonProperty(PropertyName = "pricePerQuantity")]
        public decimal? PricePerQuantity { get; set; }

        /// <summary>
        /// Actual price paid from sending system (if available) assuming discounts or promotions
        /// </summary>
        [JsonProperty(PropertyName = "pricePerQuantityPaid")]
        public decimal? PricePerQuantityPaid { get; set; }
    }
}



using Gamification.Platform.Common.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common.Core
{
    public class ActionCore
    {
        /// <summary>
        /// An application can send any unique identifier and then associate a Rule with that actionId
        /// </summary>
        [JsonProperty(PropertyName = "actionId")]
        public string ActionId { get; set; } = Guid.NewGuid().ToString("N");

        /// <summary>
        /// "Viewed Ad"
        /// </summary>
        [JsonProperty(PropertyName = "simpleName")]
        public string SimpleName { get; set; }

        /// <summary>
        /// Annonce vue OR Angezeigte Anzeige
        /// </summary>
        [JsonProperty(PropertyName = "nameTranslations")]
        public List<StringTranslation> NameTranslations { get; set; } = new List<StringTranslation>();

        [JsonProperty(PropertyName = "releaseOn")]
        public DateTimeOffset ReleaseOn { get; set; } = DateTimeOffset.MaxValue;

        /// <summary>
        /// Must be released to participate in a Goal or Achievement
        /// </summary>
        [JsonProperty(PropertyName = "releasedOn")]
        public DateTimeOffset? ReleasedOn { get; set; }

        [JsonProperty(PropertyName = "releaseOn")]
        public List<MachineReadablePurchaseRequest> MachineReadablePurchases { get; set; } = new List<MachineReadablePurchaseRequest>();
    }

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



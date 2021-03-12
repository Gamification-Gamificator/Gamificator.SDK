using Gamification.SDK.Core;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ThreeTwoSix.Core;

namespace Gamification.SDK.Core
{
    public abstract class ActionCore
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
        public StringTranslationsCore NameTranslations { get; set; } = new StringTranslationsCore();

        [JsonProperty(PropertyName = "releaseOn")]
        public DateTimeOffset ReleaseOn { get; set; } = DateTimeOffset.MaxValue;

        /// <summary>
        /// Must be released to participate in a Goal or Achievement
        /// </summary>
        [JsonProperty(PropertyName = "releasedOn")]
        public DateTimeOffset? ReleasedOn { get; set; }

        /// <summary>
        /// This allows Gamification of Sku based purchase(s) NOT a replacement for aswarded promotion value
        /// </summary>
        [JsonProperty(PropertyName = "machineReadablePurchases")]
        public List<MachineReadablePurchase> MachineReadablePurchases { get; set; } = new List<MachineReadablePurchase>();
    }
}



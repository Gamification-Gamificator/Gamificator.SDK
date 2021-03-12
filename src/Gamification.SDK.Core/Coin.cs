using Gamification.SDK.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ThreeTwoSix.Core;

namespace Gamification.SDK.Core
{
    /// <summary>
    /// The Coin of the Realm ;)
    /// </summary>
    public abstract class CoinCore
    {
        [JsonProperty(PropertyName = "simpleName")]
        public string SimpleName { get; set; }

        [JsonProperty(PropertyName = "nameTranslations")]
        public StringTranslationsCore NameTranslations { get; set; } = new StringTranslationsCore();

        /// <summary>
        /// Coin image
        /// </summary>
        [JsonProperty(PropertyName = "mediaTranslations")]
        public MediaTranslationsCore MediaTranslations { get; set; } = new MediaTranslationsCore();

        /// <summary>
        /// Default Ephemeral Award experation for THIS Coin
        /// </summary>
        [JsonProperty(PropertyName = "expireIn")]
        public TimeSpan? ExpireIn { get; set; }
    }
}

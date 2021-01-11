using Gamification.Platform.Common.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common.Core
{
    /// <summary>
    /// The Coin of the Realm ;)
    /// </summary>
    public abstract class CoinCore
    {
        [JsonProperty(PropertyName = "simpleName")]
        public string SimpleName { get; set; }

        [JsonProperty(PropertyName = "nameTranslations")]
        public List<StringTranslation> NameTranslations { get; set; } = new List<StringTranslation>();

        /// <summary>
        /// Coin image
        /// </summary>
        [JsonProperty(PropertyName = "mediaTranslations")]
        public List<MediaTranslation> MediaTranslations { get; set; } = new List<MediaTranslation>();

        /// <summary>
        /// Default Ephemeral Award experation for THIS Coin
        /// </summary>
        [JsonProperty(PropertyName = "expireIn")]
        public TimeSpan? ExpireIn { get; set; }
    }
}

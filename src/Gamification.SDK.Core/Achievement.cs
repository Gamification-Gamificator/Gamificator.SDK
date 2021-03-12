using Gamification.SDK.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ThreeTwoSix.Core;

namespace Gamification.SDK.Core
{   
    public abstract class AchievementCore 
    {
        /// <summary>
        /// "Gold Star!"
        /// </summary>
        [JsonProperty(PropertyName = "simpleName")]
        public string SimpleName { get; set; }

        /// <summary>
        /// Étoile d’or ! OR Gold Stern!
        /// </summary>
        [JsonProperty(PropertyName = "nameTranslations")]
        public StringTranslationsCore NameTranslations { get; set; } = new StringTranslationsCore();

        /// <summary>
        /// Trophy image or video etc
        /// </summary>
        [JsonProperty(PropertyName = "mediaTranslations")]
        public MediaTranslationsCore MediaTranslations { get; set; } = new MediaTranslationsCore();

        [JsonProperty(PropertyName = "releaseOn")]
        public DateTimeOffset ReleaseOn { get; set; } = DateTimeOffset.MinValue;

        [JsonProperty(PropertyName = "releasedOn")]
        public DateTimeOffset? ReleasedOn { get; set; }


        [JsonProperty(PropertyName = "expireOn")]
        public DateTimeOffset ExpireOn { get; set; } = DateTimeOffset.MaxValue;

        [JsonProperty(PropertyName = "expiredOn")]
        public DateTimeOffset? ExpiredOn { get; set; }
    }
}

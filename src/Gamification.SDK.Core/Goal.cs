using Gamification.SDK.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using ThreeTwoSix.Core;

namespace Gamification.SDK.Core
{
    public abstract class GoalCore
    {
        [JsonProperty(PropertyName = "simpleName")]
        public string SimpleName { get; set; }

        [JsonProperty(PropertyName = "nameTranslations")]
        public StringTranslationsCore NameTranslations { get; set; } = new StringTranslationsCore();

        /// <summary>
        /// Goal image
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

using Gamification.SDK.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ThreeTwoSix.Core;

namespace Gamification.SDK.Core
{
    // this allows meta data to be aquired outside the scope of an App
    // so a teacher could cause meta data to be aquired and Gamifyit...

    public class MetaDataAquisitionRuleCore
    {
        /// <summary>
        /// Name, Birth Date, etc
        /// </summary>
        [JsonProperty(PropertyName = "simpleName")]
        public string SimpleName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "validationRegex")]
        public string ValidationRegex { get; set; }

        /// <summary>
        /// Forces selection from a list
        /// Be carefull, ValidationRegex validates the final .Value so the OptionValues better validate!
        /// </summary>
        [JsonProperty(PropertyName = "optionValues")]
        public Dictionary<string, string> OptionValues { get; set; }

        [JsonProperty(PropertyName = "validationErrorTranslations")]
        public StringTranslationsCore ValidationErrorTranslations { get; set; } = new StringTranslationsCore();

        /// <summary>
        /// Étoile d’or ! OR Gold Stern!
        /// </summary>
        [JsonProperty(PropertyName = "nameTranslations")]
        public StringTranslationsCore NameTranslations { get; set; } = new StringTranslationsCore();

        /// <summary>
        /// Étoile d’or ! OR Gold Stern!
        /// </summary>
        [JsonProperty(PropertyName = "descriptionTranslations")]
        public StringTranslationsCore DescriptionTranslations { get; set; } = new StringTranslationsCore();

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

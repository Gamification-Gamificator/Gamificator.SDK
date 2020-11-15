using Gamification.Platform.Common.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common.Core
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
        public List<StringTranslation> ValidationErrorTranslations { get; set; } = new List<StringTranslation>();

        /// <summary>
        /// Étoile d’or ! OR Gold Stern!
        /// </summary>
        [JsonProperty(PropertyName = "nameTranslations")]
        public List<StringTranslation> NameTranslations { get; set; } = new List<StringTranslation>();

        /// <summary>
        /// Étoile d’or ! OR Gold Stern!
        /// </summary>
        [JsonProperty(PropertyName = "descriptionTranslations")]
        public List<StringTranslation> DescriptionTranslations { get; set; } = new List<StringTranslation>();

        /// <summary>
        /// Trophy image or video etc
        /// </summary>
        [JsonProperty(PropertyName = "mediaTranslations")]
        public List<MediaTranslation> MediaTranslations { get; set; } = new List<MediaTranslation>();

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

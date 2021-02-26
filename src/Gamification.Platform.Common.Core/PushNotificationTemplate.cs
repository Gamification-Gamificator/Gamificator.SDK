using Newtonsoft.Json;
using System.Collections.Generic;
using ThreeTwoSix.Core;

namespace Gamification.Platform.Common.Core
{
    public class PushNotificationTemplateCore
    {
        [JsonProperty(PropertyName = "simpleName")]
        public string SimpleName { get; set; }

        [JsonProperty(PropertyName = "nameTranslations")]
        public StringTranslationsCore NameTranslations { get; set; } = new StringTranslationsCore();

        [JsonProperty(PropertyName = "iconTranslations")]
        public MediaTranslationsCore IconTranslations { get; set; } = new MediaTranslationsCore();

        [JsonProperty(PropertyName = "headerTranslations")]
        public StringTranslationsCore HeaderTranslations { get; set; } = new StringTranslationsCore();

        [JsonProperty(PropertyName = "bodyTranslations")]
        public StringTranslationsCore BodyTranslations { get; set; } = new StringTranslationsCore();
    }
}

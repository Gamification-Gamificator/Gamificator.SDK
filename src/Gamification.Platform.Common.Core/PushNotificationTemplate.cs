using Newtonsoft.Json;
using System.Collections.Generic;

namespace Gamification.Platform.Common.Core
{
    public class PushNotificationTemplateCore
    {
        [JsonProperty(PropertyName = "simpleName")]
        public string SimpleName { get; set; }

        [JsonProperty(PropertyName = "nameTranslations")]
        public List<StringTranslation> NameTranslations { get; set; } = new List<StringTranslation>();

        [JsonProperty(PropertyName = "headerTranslations")]
        public List<StringTranslation> HeaderTranslations { get; set; } = new List<StringTranslation>();

        [JsonProperty(PropertyName = "bodyTranslations")]
        public List<StringTranslation> BodyTranslations { get; set; } = new List<StringTranslation>();
    }
}

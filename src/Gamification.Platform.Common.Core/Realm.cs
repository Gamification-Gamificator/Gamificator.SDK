using Gamification.Platform.Common.Core;
using Lazlo.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common.Core
{
    public abstract class RealmCore
    {
        /// <summary>
        /// Sharpfoxx.com etc.
        /// </summary>
        [JsonProperty(PropertyName = "simpleName")]
        public string SimpleName { get; set; }

        /// <summary>
        /// Étoile d’or ! OR Gold Stern!
        /// </summary>
        [JsonProperty(PropertyName = "nameTranslations")]
        public List<StringTranslation> NameTranslations { get; set; } = new List<StringTranslation>();

        /// <summary>
        /// Logo
        /// </summary>
        [JsonProperty(PropertyName = "logoTranslations")]
        public List<MediaTranslation> LogoTranslations { get; set; } = new List<MediaTranslation>();

        /// <summary>
        /// When changed causes an administrative creation of an Event Grid subscription with EventType = EntityRefId.ToString()
        /// </summary>
        [JsonProperty(PropertyName = "webhookUri")]
        public Uri WebhookUri { get; set; }

        [JsonProperty(PropertyName = "ownerContact")]
        public ContactCore<EndpointEmail, EndpointVoice, EndpointText> OwnerContact { get; set; }
    }
}

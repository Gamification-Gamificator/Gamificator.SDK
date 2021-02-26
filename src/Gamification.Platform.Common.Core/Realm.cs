using Gamification.Platform.Common.Core;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ThreeTwoSix.Core;

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
        public StringTranslationsCore NameTranslations { get; set; } = new StringTranslationsCore();

        /// <summary>
        /// Logo
        /// </summary>
        [JsonProperty(PropertyName = "logoTranslations")]
        public MediaTranslationsCore LogoTranslations { get; set; } = new MediaTranslationsCore();

        /// <summary>
        /// When changed causes an administrative creation of an Event Grid subscription with EventType = EntityRefId.ToString()
        /// </summary>
        [JsonProperty(PropertyName = "webhookUri")]
        public Uri WebhookUri { get; set; }

        //[JsonProperty(PropertyName = "ownerContact")]
        //public ContactCore<EndpointEmail, EndpointVoice, EndpointText> OwnerContact { get; set; }
    }
}

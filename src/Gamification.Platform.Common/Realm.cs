using Gamification.Platform.Common.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common
{
    /// <summary>
    /// An App, Web Site or Process being Gamified
    /// </summary>
    public class Realm : RealmCore
    {
        /// <summary>
        /// ** New pattern **
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid EntityRefId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// When changed causes an administrative creation of an Event Grid subscription with EventType = EntityRefId.ToString()
        /// </summary>
        [JsonProperty(PropertyName = "webhookUri")]
        public Uri WebhookUri { get; set; }

        /// <summary>
        /// All Webhook Post using CloudEvent schema encrypted in a Lazlo.SecureData 
        /// using an asymetric public key
        /// Digital Signature using a private Lazlo keypair
        /// </summary>
        [JsonProperty(PropertyName = "webhookPublicKey")]
        public string WebhookPublicKey { get; set; }
    }
}

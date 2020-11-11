using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gamification.Platform.Common
{
    public class PlayerWebPushSubscription
    {
        [JsonProperty(PropertyName = "playerRefId")]
        public Guid PlayerRefId { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "p256dh")]
        public string P256dh { get; set; }

        [JsonProperty(PropertyName = "auth")]
        public string Auth { get; set; }
    }
}

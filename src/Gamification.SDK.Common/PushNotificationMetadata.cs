using System;
using Newtonsoft.Json;

namespace Gamification.SDK.Common
{
    public class PushNotificationMetadata
    {
        [JsonProperty(PropertyName = "id")]
        public string Id { get; set; }

        [JsonProperty(PropertyName = "eventTime")]
        public DateTimeOffset EventTime { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "message")]
        public string Message { get; set; }

        [JsonProperty(PropertyName = "url")]
        public string Url { get; set; }

        [JsonProperty(PropertyName = "playerRefId")]
        public Guid PlayerRefId { get; set; }

        [JsonProperty(PropertyName = "expireOn")]
        public DateTimeOffset ExpireOn { get; set; }
    }
}

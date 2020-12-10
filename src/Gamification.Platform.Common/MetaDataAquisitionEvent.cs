using Gamification.Platform.Common.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common
{
    public class MetaDataAquisitionEvent : OccurrenceBase
    {
        [JsonProperty(PropertyName = "metaDataAquisitionRuleRefId")]
        public Guid MetaDataAquisitionRuleRefId { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        /// <summary>
        /// Event was published (webhook) on this DateTime
        /// </summary>
        [JsonProperty(PropertyName = "publishedOn")]
        public DateTimeOffset PublishedOn { get; set; }
    }

    public class MetaDataAquisitionEvents : List<MetaDataAquisitionEvent>
    {
    }
}

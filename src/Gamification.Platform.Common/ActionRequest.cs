using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common
{
    /// <summary>
    /// Realm is derived from apikey of client HttpHeader
    /// Player is derived from .Uuid of SmartRequest<>
    /// </summary>
    public class ActionRequest
    {
        /// <summary>
        /// Created by client system, we don't care what youuse as long as it's unique
        /// within the Realm
        /// </summary>
        [JsonRequired]
        [JsonProperty(PropertyName = "actionId")]
        public string ActionId { get; set; }

        /// <summary>
        /// default = "default"
        /// Describes session hierarchical relationships
        /// Example: 2020:Fall:12
        /// Example: Year:Season:Game#
        /// </summary>
        [JsonRequired]
        [JsonProperty(PropertyName = "sessionHierarchy")]
        public string SessionHierarchy { get; set; } = "default";

        /// <summary>
        /// *Optional*
        /// Processed by an associated MetaDataAquisitionRule or MetricAquisitionRule
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        /// <summary>
        /// An ActionRequest may occur out of sync with the Action
        /// This is WHEN the Action Occurred NOT when it was sent
        /// </summary>
        [JsonRequired]
        [JsonProperty(PropertyName = "occurredOn")]
        public DateTimeOffset OccurredOn { get; set; }
    }

    public class ActionRequests : List<ActionRequest>
    {
    }
}

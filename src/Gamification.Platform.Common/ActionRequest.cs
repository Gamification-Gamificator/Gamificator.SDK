using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common
{
    public class ActionRequest
    {
        [JsonRequired]
        [JsonProperty(PropertyName = "actionId")]
        public string ActionId { get; set; }

        /// <summary>
        /// string descibing Hierarchical relationships
        /// Example: 2020:Fall:12
        /// Example: Year:Season:Game#
        /// </summary>
        [JsonProperty(PropertyName = "sessionHierarchy")]
        public string SessionHierarchy { get; set; } = "default";        

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

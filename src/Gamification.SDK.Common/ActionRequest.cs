using Gamification.SDK.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.SDK.Common
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
        /// Processed by an associated MetaDataAquisitionRule
        /// </summary>
        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }

        /// <summary>
        /// A Purchase associated with this action, the Action likely being "Purchase"
        /// Allows purchase data to be integratedinto Gamification
        /// "Buy 3 Red Bull 12 oz cans within the last week and your a "Power Drinker" and get a Trophy
        /// </summary>
        [JsonProperty(PropertyName = "machineReadablePurchase")]
        public MachineReadablePurchase MachineReadablePurchase { get; set; }
        
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

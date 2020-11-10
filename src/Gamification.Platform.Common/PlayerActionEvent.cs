using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common
{
    public class ActionEventBase
    {
        [JsonRequired]
        [JsonProperty(PropertyName = "actionRefId")]
        public Guid ActionRefId { get; set; }

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

        [JsonProperty(PropertyName = "occurredAt")]
        [JsonConverter(typeof(NetTopologySuiteGeometryConverter))]
        public Point OccurredAt { get; set; }
    }


    /// <summary>
    /// Because Player is contextually in a Player and a Realm we remove those properties from the Player persistance ActionEvent
    /// </summary>
    public class PlayerActionEvent : ActionEventBase
    {
        /// <summary>
        /// An Action can be "used" by a trigger thus eliminating further trigger evaluation consideration 
        /// Nullable as the calculation is Async to persistance
        /// </summary>
        [JsonProperty(PropertyName = "triggerStepRefId")]
        public Guid? TriggerStepRefId { get; set; }
    }

    public class PlayerActionEvents : List<PlayerActionEvent>
    {
    }
}

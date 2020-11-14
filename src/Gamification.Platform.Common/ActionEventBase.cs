using Gamification.Platform.Common.Core;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;

namespace Gamification.Platform.Common
{
    /// <summary>
    /// A true Base, Core is an abstraction for .Common vs .Display
    /// </summary>
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
        [JsonConverter(typeof(NetTopologySuiteGeometryPointConverter))]
        public Point OccurredAt { get; set; }
    }
}

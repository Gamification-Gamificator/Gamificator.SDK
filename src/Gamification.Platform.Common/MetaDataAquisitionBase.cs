using Gamification.Platform.Common.Core;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;

namespace Gamification.Platform.Common
{
    public class MetaDataAquisitionBase
    {
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

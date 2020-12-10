using Gamification.Platform.Common.Core;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;

namespace Gamification.Platform.Common.Core
{
    public abstract class OccurrenceBase
    {
        /// <summary>
        /// An xRequest may occur out of sync with the x
        /// This is WHEN the x Occurred NOT when it was sent
        /// </summary>
        [JsonRequired]
        [JsonProperty(PropertyName = "occurredOn")]
        public DateTimeOffset OccurredOn { get; set; }

        [JsonProperty(PropertyName = "occurredAt")]
        [JsonConverter(typeof(NetTopologySuiteGeometryPointConverter))]
        public Point OccurredAt { get; set; }
    }
}

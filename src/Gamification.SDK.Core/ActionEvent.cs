using Gamification.SDK.Core;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;

namespace Gamification.SDK.Core
{
    /// <summary>
    /// A true Base, Core is an abstraction for .Common vs .Display
    /// </summary>
    public class ActionEventCore : OccurrenceBase
    {
        /// <summary>
        /// string descibing Hierarchical relationships
        /// Example: 2020:Fall:12
        /// Example: Year:Season:Game#
        /// </summary>
        [JsonProperty(PropertyName = "sessionHierarchy")]
        public string SessionHierarchy { get; set; } = "default";
    }
}

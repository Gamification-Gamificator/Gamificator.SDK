using Gamification.Platform.Common.Core;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common.Core
{    
    public class TriggerStepCore
    {
        /// <summary>
        /// Steps are ordered to prioritize Award within GoalTriggers
        /// </summary>
        [JsonProperty(PropertyName = "executionOrder")]
        public int ExecutionOrder { get; set; }

        [JsonProperty(PropertyName = "simpleName")]
        public string SimpleName { get; set; }

        [JsonProperty(PropertyName = "nameTranslations")]
        public List<StringTranslation> NameTranslations { get; set; } = new List<StringTranslation>();

        /// <summary>
        /// Step requires Actions to have occurred inside these Polygons
        /// </summary>
        [JsonProperty(PropertyName = "insideOf")]
        /// <summary>
        [JsonConverter(typeof(NetTopologySuiteGeometryConverter))]
        public MultiPolygon InsideOf { get; set; }

        /// <summary>
        /// Step requires Actions to have occurred outside these Polygons
        /// </summary>
        [JsonProperty(PropertyName = "outsideOf")]
        [JsonConverter(typeof(NetTopologySuiteGeometryConverter))]
        public MultiPolygon OutsideOf { get; set; }

        /// <summary>
        /// True: this TriggerStep calculates since the last ActionCheckpoint
        /// False: this TriggerStep calculates All Actions
        /// </summary>
        [JsonProperty(PropertyName = "areActionsCheckpointed")]
        public bool AreActionsCheckpointed { get; set; }

        /// <summary>
        /// You must perform one or more [count] Actions to achieve this TriggerStep
        /// </summary>
        [JsonProperty(PropertyName = "actions")]
        public Dictionary<Guid, int> Actions { get; set; } = new Dictionary<Guid, int>();
    }
}

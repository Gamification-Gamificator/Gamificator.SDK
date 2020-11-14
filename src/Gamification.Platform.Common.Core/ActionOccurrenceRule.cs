using Gamification.Platform.Common.Core.Enums;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common.Core
{
    public class ActionOccurrenceRuleCore
    {
        /// <summary>
        /// and/or
        /// </summary>
        [JsonProperty(PropertyName = "operationType")]
        public OperationRuleType OperationType { get; set; }

        /// <summary>
        /// This Action
        /// </summary>
        [JsonProperty(PropertyName = "actionRefId")]
        public Guid ActionRefId { get; set; }

        /// <summary>
        /// Did/DidNot
        /// </summary>
        [JsonProperty(PropertyName = "tenseType")]
        public TenseRuleType TenseType { get; set; }

        // occur inside/outside these fenses
        #region Inside/Outside

        /// <summary>
        /// Step requires this Actions to have occurred inside these Polygons
        /// </summary>
        [JsonProperty(PropertyName = "insideOf")]
        /// <summary>
        [JsonConverter(typeof(NetTopologySuiteGeometryConverter))]
        public MultiPolygon InsideOf { get; set; }

        /// <summary>
        /// Step requires this Action to have occurred outside these Polygons
        /// </summary>
        [JsonProperty(PropertyName = "outsideOf")]
        [JsonConverter(typeof(NetTopologySuiteGeometryConverter))]
        public MultiPolygon OutsideOf { get; set; }

        #endregion Inside/Outside

        /// <summary>
        /// occur during these periods
        /// </summary>
        [JsonProperty(PropertyName = "PeriodRecurrence")]
        public PeriodRecurrence PeriodRecurrence { get; set; }

        /// <summary>
        /// More or less than
        /// </summary>
        [JsonProperty(PropertyName = "compareType")]
        public CompareRuleType CompareType { get; set; }

        /// <summary>
        /// This many times
        /// </summary>
        [JsonProperty(PropertyName = "count")]
        public int Count { get; set; }
    }

    public class ActionOccurrenceRuleCores : List<ActionOccurrenceRuleCore>
    {

    }
}

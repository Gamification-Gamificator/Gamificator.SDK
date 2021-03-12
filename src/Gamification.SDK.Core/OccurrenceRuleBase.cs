using Gamification.SDK.Core.Enums;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ThreeTwoSix.Core.JsonConverters;

namespace Gamification.SDK.Core
{
    /// <summary>
    /// "Visits is > 2 in last 3 weeks"
    /// </summary>
    public abstract class OccurrenceRuleBase
    {
        /// <summary>
        /// and/or
        /// </summary>
        [JsonProperty(PropertyName = "operationType")]
        public OperationRuleType OperationType { get; set; }

        // The thing we're tracking Occurrences of ...

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
        [JsonConverter(typeof(NetTopologySuiteGeometryMultiPolygonConverter))]
        public MultiPolygon InsideOf { get; set; }

        /// <summary>
        /// Step requires this Action to have occurred outside these Polygons
        /// </summary>
        [JsonProperty(PropertyName = "outsideOf")]
        [JsonConverter(typeof(NetTopologySuiteGeometryMultiPolygonConverter))]
        public MultiPolygon OutsideOf { get; set; }

        #endregion Inside/Outside

        /// <summary>
        /// occur during this period
        /// </summary>
        [JsonProperty(PropertyName = "periodRecurrence")]
        public PeriodRecurrence PeriodRecurrence { get; set; }

        /// <summary>
        /// occur within this heirarchy
        /// "occured within the 2020 season"
        /// "occured within the 12th game of the 2020 season"
        /// </summary>
        [JsonProperty(PropertyName = "sessionHierarchy")]
        public string SessionHierarchy { get; set; } = "default";

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
}

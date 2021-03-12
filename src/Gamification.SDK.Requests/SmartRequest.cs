using Newtonsoft.Json;
using System;
using ThreeTwoSix.Abstractions.Enumerators;
using ThreeTwoSix.Core;

namespace Gamification.SDK.Requests
{
    [Serializable]
    public class SmartRequestV2<T> : SmartContextV2<T>
    {
        public SmartRequestV2() { }

        /// <summary>
        /// Flags value
        /// </summary>
        [JsonProperty(PropertyName = "simulationTypes")]
        public SimulationTypes SimulationTypes { get; set; } = SimulationTypes.None;
    }
}

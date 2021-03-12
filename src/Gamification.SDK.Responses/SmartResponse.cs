using Newtonsoft.Json;
using System;
using ThreeTwoSix.Abstractions.Enumerators;
using ThreeTwoSix.Core;

namespace Gamification.SDK.Responses
{

    [Serializable]
    public class SmartAcceptResponse : SmartAcceptCoreV2
    {
        public SmartAcceptResponse() { }

        public SmartAcceptResponse(Guid correlationRefId, SimulationTypes simulationTypes = SimulationTypes.None) 
        { 
            this.CorrelationRefId = correlationRefId;
            this.SimulationTypes = simulationTypes;
        }

        public SmartAcceptResponse(Guid correlationRefId, Uri help, SimulationTypes simulationTypes = SimulationTypes.None)
        {
            this.CorrelationRefId = correlationRefId;
            this.SimulationTypes = simulationTypes;
            this.HelpUri = help;
        }

        [JsonProperty(PropertyName = "correlationId")]
        public Guid CorrelationRefId { get; set; }

        /// <summary>
        /// If this response was a result of Simulation else 0/.None
        /// </summary>
        [JsonProperty(PropertyName = "simulationTypes")]
        public SimulationTypes SimulationTypes { get; set; } = SimulationTypes.None;

        /// <summary>
        /// A Uri location with Help for this response
        /// </summary>
        [JsonProperty(PropertyName = "helpUri")]
        public Uri HelpUri { get; set; }
    }


    [Serializable]
    public class SmartResponseV2<T> : SmartCoreV2<T>
    {
        public SmartResponseV2() { }

        public SmartResponseV2(Guid correlationRefId, SimulationTypes simulationTypes = SimulationTypes.None)
        {
            CorrelationRefId = correlationRefId;
            this.SimulationTypes = SimulationTypes;
        }

        public SmartResponseV2(Guid correlationRefId, T data, SimulationTypes simulationTypes = SimulationTypes.None)
        {
            CorrelationRefId = correlationRefId;
            Data = data;
            this.SimulationTypes = SimulationTypes;
        }

        public SmartResponseV2(Guid correlationRefId, T data, Uri helpUri, SimulationTypes simulationTypes = SimulationTypes.None)
        {
            CorrelationRefId = correlationRefId;
            Data = data;
            this.SimulationTypes = SimulationTypes;
        }

        [JsonProperty(PropertyName = "correlationId")]
        public Guid CorrelationRefId { get; set; }

        /// <summary>
        /// Flags value
        /// </summary>
        [JsonProperty(PropertyName = "simulationTypes")]
        public SimulationTypes SimulationTypes { get; set; } = SimulationTypes.None;

        /// <summary>
        /// Equivalent to the Http response header
        /// </summary>
        [JsonProperty(PropertyName = "location")]
        public Uri Location { get; set; }

        /// <summary>
        /// A Uri location with Help for this response
        /// </summary>
        [JsonProperty(PropertyName = "helpUri")]
        public Uri HelpUri { get; set; }
    }
}

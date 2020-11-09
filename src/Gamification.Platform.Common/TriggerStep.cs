using Gamification.Platform.Common.Core;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common
{
    /// <summary>
    /// A single step in a GoalTrigger
    /// Example: The User must View an Ad and Answer a Survey on a Thursday or Friday to satisfy this TriggerStep
    /// TriggerSteps determine if your Actions qualify for the GoalTrigger
    /// RateLimitRules determins if you have maximized the Count for this period of awards
    /// </summary>
    public class TriggerStep : TriggerStepCore
    {
        [JsonProperty(PropertyName = "triggerStepRefId")]
        public Guid TriggerStepRefId { get; set; } = Guid.NewGuid();
    }

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

        [JsonProperty(PropertyName = "periodRecurrance")]
        public PeriodRecurrance PeriodRecurrance { get; set; }

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

    public class TriggerSteps : List<TriggerStep>
    {
        public new void Add(TriggerStep item)
        {
            if (base.Exists(e => e.ExecutionOrder == item.ExecutionOrder))
            {
                throw new ArgumentException($"A {nameof(TriggerStep)} with the same {nameof(TriggerStep.ExecutionOrder)} already exists.");
            }

            if (base.Exists(e => e.SimpleName == item.SimpleName))
            {
                throw new ArgumentException($"A {nameof(TriggerStep)} with the same {nameof(TriggerStep.SimpleName)} already exists.");
            }

            base.Add(item);
        }
    }
}

using Gamification.Platform.Common.Core;
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

        /// <summary>
        /// When Actions were performed
        /// </summary>
        [JsonProperty(PropertyName = "periodRecurrence")]
        public PeriodRecurrence PeriodRecurrence { get; set; } = new PeriodRecurrence();

        /// <summary>
        /// Quantity of actions performed
        /// </summary>
        [JsonProperty(PropertyName = "actionOccurrenceRule")]
        public ActionOccurrenceRules ActionOccurrenceRules { get; set; } = new ActionOccurrenceRules();

        /// <summary>
        /// What Meta data was gathered
        /// ActionOccurrenceRules MUST be 0, you only gather meta data once
        /// </summary>
        [JsonProperty(PropertyName = "metaDataAquisitionRule")]
        public MetaDataAquisitionRule MetaDataAquisitionRule { get; set; } = new MetaDataAquisitionRule();

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "purchaseRule")]
        public PurchaseRule PurchaseRule { get; set; } = new PurchaseRule();
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

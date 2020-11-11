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

        [JsonProperty(PropertyName = "periodRecurrance")]
        public PeriodRecurrance PeriodRecurrance { get; set; }
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

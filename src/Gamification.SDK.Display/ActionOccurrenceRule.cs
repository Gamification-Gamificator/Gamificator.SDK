using Gamification.SDK.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.SDK.Display
{
    public class ActionOccurrenceRuleDisplay : OccurrenceRuleBase
    {
        [JsonProperty(PropertyName = "actionDisplay")]
        public ActionDisplay ActionDisplay { get; set; }
    }


    public class ActionOccurrenceRuleDisplays : List<ActionOccurrenceRuleDisplay>
    {

    }
}

using Gamification.Platform.Common.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common.Display
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

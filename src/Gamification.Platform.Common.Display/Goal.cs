using Gamification.Platform.Common.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gamification.Platform.Common.Display
{
  
    public class GoalDisplay : GoalCore
    {
        [JsonProperty(PropertyName = "awards")]
        public List<AwardRuleDisplay> Awards { get; set; } = new List<AwardRuleDisplay>();
    }

    public class GoalDisplays : List<GoalDisplay>
    {
    }


}

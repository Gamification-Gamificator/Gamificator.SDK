using Gamification.SDK.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.SDK.Display
{   
    public class AchievementDisplay : AchievementCore
    {
        [JsonProperty(PropertyName = "goals")]
        public GoalDisplays Goals { get; set; } = new GoalDisplays();
    }

    public class AchievementDisplays : List<AchievementDisplay>
    {
    }
}

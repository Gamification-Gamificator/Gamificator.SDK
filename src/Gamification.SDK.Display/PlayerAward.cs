using Gamification.SDK.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.SDK.Display
{    
    public class PlayerAwardDisplay : PlayerAwardCore
    {
        [JsonProperty(PropertyName = "triggeringAction")]
        public ActionDisplay TriggeringAction { get; set; }

        [JsonProperty(PropertyName = "triggeringGoal")]
        public GoalDisplay TriggeringGoal { get; set; }

        [JsonProperty(PropertyName = "triggeringAchievement")]
        public AchievementDisplay TriggeringAchievement { get; set; }

        [JsonProperty(PropertyName = "coin")]
        public CoinDisplay Coin { get; set; }
    }

    public class PlayerAwardDisplays : List<PlayerAwardDisplay>
    {
        public new void Add(PlayerAwardDisplay item)
        {
            //TODO Add rules here

            base.Add(item);
        }
    }
}

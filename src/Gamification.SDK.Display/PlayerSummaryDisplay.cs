using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gamification.SDK.Display
{
    public class PlayerSummaryDisplay
    {
        [JsonProperty(PropertyName = "id")]
        public Guid EntityRefId { get; set; }

        [JsonProperty(PropertyName = "goals")]
        public GoalDisplays Goals { get; set; }

        [JsonProperty(PropertyName = "achievements")]
        public AchievementDisplays Achievements { get; set; }

        [JsonProperty(PropertyName = "coinBalances")]
        public CoinBalancesDisplay CoinBalances { get; set; }
    }
}

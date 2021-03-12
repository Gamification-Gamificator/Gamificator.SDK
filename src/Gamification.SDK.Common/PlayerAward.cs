using Gamification.SDK.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.SDK.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class PlayerAward : PlayerAwardCore
    {
        [JsonProperty(PropertyName = "entityRefId")]
        public Guid EntityRefId { get; set; } = Guid.NewGuid();

        [JsonProperty(PropertyName = "actionRefId")]
        public Guid? ActionRefId { get; set; }

        [JsonProperty(PropertyName = "goalRefId")]
        public Guid? GoalRefId { get; set; }

        [JsonProperty(PropertyName = "achievementRefId")]
        public Guid? AchievementRefId { get; set; }

        [JsonProperty(PropertyName = "coinRefId")]
        public Guid CoinRefId { get; set; }
    }

    public class PlayerAwards : List<PlayerAward>
    {
        public new void Add(PlayerAward item)
        {
            //TODO Add rules here

            base.Add(item);
        }
    }
}

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common
{
    /// <summary>
    /// 
    /// </summary>
    public class PlayerAwardCore
    {

        [JsonProperty(PropertyName = "value")]
        public decimal Value { get; set; }

        ///// <summary>
        ///// Debit = 1, Credit = 2
        ///// </summary>
        //[JsonProperty(PropertyName = "accountingTransactionType")]
        //public int AccountingTransactionType { get; set; }

        /// <summary>
        /// If no AwardRefId then why?
        /// </summary>
        [JsonProperty(PropertyName = "description")]
        public string Description { get; set; }

        [JsonProperty(PropertyName = "occurredOn")]
        public DateTimeOffset OccurredOn { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class PlayerAward : PlayerAwardCore
    {
        [JsonProperty(PropertyName = "actionRefId")]
        public Guid? ActionRefId { get; set; }

        [JsonProperty(PropertyName = "goalRefId")]
        public Guid? GoalRefId { get; set; }

        [JsonProperty(PropertyName = "achievementRefId")]
        public Guid? AchievementRefId { get; set; }

        [JsonProperty(PropertyName = "coinRefId")]
        public Guid CoinRefId { get; set; }
    }

    public class PlayerAwardEntity : PlayerAward
    {
        [JsonProperty(PropertyName = "playerRefId")]
        public Guid PlayerRefId { get; set; }
    }

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

    public class PlayerAwards : List<PlayerAward>
    {
        public new void Add(PlayerAward item)
        {
            //TODO Add rules here

            base.Add(item);
        }
    }

    public class PlayerAwardDisplays : List<PlayerAwardDisplay>
    {
        public new void Add(PlayerAwardDisplay item)
        {
            //TODO Add rules here

            base.Add(item);
        }
    }

    public class PlayerAwardCores : List<PlayerAwardCore>
    {
        public new void Add(PlayerAwardCore item)
        {
            //TODO Add rules here

            base.Add(item);
        }
    }

}

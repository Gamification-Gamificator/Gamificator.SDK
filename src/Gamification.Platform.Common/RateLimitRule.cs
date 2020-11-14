using Gamification.Platform.Common.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common
{
    /// <summary>
    /// As multiple Actions per TimeSpan match a Trigger, limit the Events persisted
    /// </summary>
    public class RateLimitRule
    {
        [JsonProperty(PropertyName = "simpleName")]
        public string SimpleName { get; set; }

        [JsonProperty(PropertyName = "nameTranslations")]
        public List<StringTranslation> NameTranslations { get; set; } = new List<StringTranslation>();

        /// <summary>
        /// You can accomplish Count GoalCompletions per Period(s), both Periods Null indicates lifetime Count
        /// </summary>
        [JsonProperty(PropertyName = "count")]
        public int? Count { get; set; }

        /// <summary>
        /// 
        /// PeriodTimeSpan of 8H and PeriodBeginOn 8AM of matching PeriodRecurrence day means within the first 8H after 8AM you can be accomplish Count of Trigger
        /// </summary>
        [JsonProperty(PropertyName = "periodRecurrence")]
        public PeriodRecurrence PeriodRecurrence { get; set; }


        [JsonProperty(PropertyName = "executionOrder")]
        public int ExecutionOrder { get; set; }
    }

    public class RateLimitRules : List<RateLimitRule>
    {
        public new void Add(RateLimitRule item)
        {
            if (base.Exists(e => e.ExecutionOrder == item.ExecutionOrder))
            {
                throw new ArgumentException($"A {nameof(RateLimitRule)} with the same {nameof(RateLimitRule.ExecutionOrder)} already exists.");
            }

            if (base.Exists(e => e.SimpleName == item.SimpleName))
            {
                throw new ArgumentException($"A {nameof(RateLimitRule)} with the same {nameof(RateLimitRule.SimpleName)} already exists.");
            }

            base.Add(item);
        }
    }

    /// <summary>
    /// Matched to VisualBasic DateInterval values rather than importing VB
    /// https://docs.microsoft.com/en-us/dotnet/api/microsoft.visualbasic.dateinterval?view=netcore-3.1
    /// </summary>
    public enum DateInterval
    {
        Year = 0,
        Quarter = 1,
        Day = 4,
        Weekday = 6,
        Hour = 7,
        Minute = 8,
    }
}

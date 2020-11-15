using Newtonsoft.Json;
using System;

namespace Gamification.Platform.Common.Core
{
    /// <summary>
    /// Recurrance MUST be configured in UTC to work properly
    /// </summary>
    public sealed class PeriodRecurrence
    {
        /// <summary>
        /// Only allow Step to be evaluated TRUE on these Dates Periods
        /// </summary>
        [JsonProperty(PropertyName = "periodPattern")]
        public string PeriodPattern { get; set; }

        /// <summary>
        /// This step is only valid for ActionRequests starting in after minute
        /// </summary>
        [JsonProperty(PropertyName = "periodMinuteBeginOn")]
        public int? PeriodMinuteBeginOn { get; set; }

        /// <summary>
        /// This step is only valid for ActionRequests during this Period
        /// </summary>
        [JsonProperty(PropertyName = "periodTimeSpan")]
        public TimeSpan? PeriodTimeSpan { get; set; }
    }
}

using Gamification.Platform.Common.Core;
using Newtonsoft.Json;
using System;

namespace Gamification.Platform.Common.Core
{
    public class GoalEventCore : OccurrenceBase
    {
        /// <summary>
        /// A Goal is accomplished
        /// </summary>
        [JsonRequired]
        [JsonProperty(PropertyName = "accomplishedOn")]
        public DateTimeOffset AccomplishedOn { get; set; }
    }
}

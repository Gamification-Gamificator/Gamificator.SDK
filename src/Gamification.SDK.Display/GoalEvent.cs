using Gamification.SDK.Core;
using Newtonsoft.Json;
using System;

namespace Gamification.SDK.Display
{
    /// <summary>
    /// The persisted Goal transaction
    /// </summary>
    public class GoalEventDisplay : GoalEventCore
    {
        [JsonRequired]
        [JsonProperty(PropertyName = "id")]
        public Guid EntityRefId { get; set; }

        /// <summary>
        /// This is the Action
        /// </summary>
        [JsonRequired]
        [JsonProperty(PropertyName = "action")]
        public ActionDisplay Action { get; set; }

        //[JsonRequired]
        //[JsonProperty(PropertyName = "player")]
        //public PlayerDisplay Player { get; set; }

        [JsonRequired]
        [JsonProperty(PropertyName = "realm")]
        public RealmDisplay Realm { get; set; }

        [JsonRequired]
        [JsonProperty(PropertyName = "goal")]
        public GoalDisplay Goal { get; set; }

        /// <summary>
        /// A Goal is accomplished
        /// </summary>
        [JsonRequired]
        [JsonProperty(PropertyName = "accomplishedOn")]
        public DateTimeOffset AccomplishedOn { get; set; }
    }
}

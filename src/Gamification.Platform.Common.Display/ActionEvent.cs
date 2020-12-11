using Gamification.Platform.Common.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common.Display
{
    /// <summary>
    /// The persisted Action transaction
    /// </summary>
    public class ActionEventDisplay : ActionEventCore
    {
        /// <summary>
        /// This is the instance
        /// </summary>
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

        [JsonProperty(PropertyName = "triggerStepDisplay")]
        public TriggerStepDisplay TriggerStepDisplay { get; set; }
    }


    public class ActionEventsDisplay : List<ActionEventDisplay>
    {
    }
}

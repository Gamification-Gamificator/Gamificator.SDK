﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common
{
    /// <summary>
    /// Because Player is contextually in a Player and a Realm we remove those properties from the Player persistance ActionEvent
    /// </summary>
    public class PlayerActionEvent : ActionEventBase
    {
        /// <summary>
        /// An Action can be "used" by a trigger thus eliminating further trigger evaluation consideration 
        /// Nullable as the calculation is Async to persistance
        /// </summary>
        [JsonProperty(PropertyName = "triggerStepRefId")]
        public Guid? TriggerStepRefId { get; set; }
    }

    public class PlayerActionEvents : List<PlayerActionEvent>
    {
    }
}

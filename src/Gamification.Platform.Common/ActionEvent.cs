using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using Gamification.Platform.Common.Core;

namespace Gamification.Platform.Common
{
    /// <summary>
    /// The Action instance transaction
    /// </summary>
    public class ActionEvent : ActionEventCore
    {
        [JsonRequired]
        [JsonProperty(PropertyName = "id")]
        public Guid EntityRefId { get; set; }

        [JsonRequired]
        [JsonProperty(PropertyName = "actionRefId")]
        public Guid ActionRefId { get; set; }

        [JsonRequired]
        [JsonProperty(PropertyName = "playerRefId")]
        public Guid PlayerRefId { get; set; }

        /// <summary>
        /// All root entities require RealmRefId for multi-tenancy
        /// </summary>
        [JsonRequired]
        [JsonProperty(PropertyName = "realmRefId")]
        public Guid RealmRefId { get; set; }

        /// <summary>
        /// An Action can be "used" by a trigger thus eliminating further trigger evaluation consideration 
        /// Nullable as the calculation is Async to persistance
        /// </summary>
        [JsonProperty(PropertyName = "triggerStepRefId")]
        public Guid? TriggerStepRefId { get; set; }
    }


    public class ActionEvents : List<ActionEvent>
    {
    }
}

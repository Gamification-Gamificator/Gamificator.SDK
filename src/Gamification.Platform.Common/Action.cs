using Gamification.Platform.Common.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common
{
    //public class MetricCore
    //{
    //    /// <summary>
    //    /// An application can send any unique identifier and then associate a Rule with that actionId
    //    /// </summary>
    //    [JsonProperty(PropertyName = "metricId")]
    //    public string MetricId { get; set; } = Guid.NewGuid().ToString("N");

    //    //[JsonProperty(PropertyName = "metricId")]
    //    //public string MetricId { get; set; }

    //}

    public class Action : ActionCore
    {
        /// <summary>
        /// ** New pattern **
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid EntityRefId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// All root entities require RealmRefId for multi-tenancy
        /// </summary>
        [JsonRequired]
        [JsonProperty(PropertyName = "realmRefId")]
        public Guid RealmRefId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "actionCheckpoints")]
        public List<ActionCheckpoint> ActionCheckpoints { get; set; } = new List<ActionCheckpoint>();

        /// <summary>
        /// The Action can itself cause Awards to be granted
        /// </summary>
        [JsonProperty(PropertyName = "awards")]
        public List<AwardRule> Awards { get; set; } = new List<AwardRule>();

        /// <summary>
        /// **Optional**
        /// When an ActionRequest includes a .Value this is the rule that processes the Metadata
        /// </summary>
        [JsonProperty(PropertyName = "metaDataAquisitionRuleRefId")]
        public Guid? MetaDataAquisitionRuleRefId { get; set; }
    }

    public class Actions : List<Action>
    {
    }

    public interface IFiniteStateMachine<T>
    {
        public int State { get; set; }
    }
}



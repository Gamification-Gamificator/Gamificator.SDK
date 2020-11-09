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

    public class ActionCore
    {
        /// <summary>
        /// An application can send any unique identifier and then associate a Rule with that actionId
        /// </summary>
        [JsonProperty(PropertyName = "actionId")]
        public string ActionId { get; set; } = Guid.NewGuid().ToString("N");

        /// <summary>
        /// "Viewed Ad"
        /// </summary>
        [JsonProperty(PropertyName = "simpleName")]
        public string SimpleName { get; set; }

        /// <summary>
        /// Annonce vue OR Angezeigte Anzeige
        /// </summary>
        [JsonProperty(PropertyName = "nameTranslations")]
        public List<StringTranslation> NameTranslations { get; set; } = new List<StringTranslation>();

        /// <summary>
        /// The Action can itself cause Awards to be granted
        /// </summary>
        [JsonProperty(PropertyName = "awards")]
        public List<AwardRule> Awards { get; set; } = new List<AwardRule>();

        [JsonProperty(PropertyName = "releaseOn")]
        public DateTimeOffset ReleaseOn { get; set; } = DateTimeOffset.MaxValue;

        /// <summary>
        /// Must be released to participate in a Goal or Achievement
        /// </summary>
        [JsonProperty(PropertyName = "releasedOn")]
        public DateTimeOffset? ReleasedOn { get; set; }       
    }

    public class Action : ActionCore
    {
        [JsonProperty(PropertyName = "actionRefId")]
        public Guid ActionRefId { get; set; } = Guid.NewGuid();

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
    }

    public class Actions : List<Action>
    {
    }

    public class ActionDisplay : ActionCore
    {
        [JsonProperty(PropertyName = "actionCheckpoints")]
        public List<DateTimeOffset> ActionCheckpoints { get; set; } = new List<DateTimeOffset>();
    }

    public interface IFiniteStateMachine<T>
    {
        public int State { get; set; }
    }
}



using Newtonsoft.Json;
using System;

namespace Gamification.Platform.Common
{
    public class AwardRule
    {
        [JsonProperty(PropertyName = "awardRefId")]
        public Guid AwardRefId { get; set; }

        /// <summary>
        /// Causes an ActionCheckpoint to be persisted
        /// </summary>
        //[JsonProperty(PropertyName = "actionToCheckpoint")]
        //public Guid? ActionToCheckpoint { get; set; }
    }

}

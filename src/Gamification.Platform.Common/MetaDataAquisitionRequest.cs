using Newtonsoft.Json;
using System;

namespace Gamification.Platform.Common
{
    /// <summary>
    /// Submitted by Gamificator Web UI
    /// Based on (abstract) Push to Player with Gamificator MetaDataAquisitionRuleRefId GET 
    /// </summary>
    public class MetaDataAquisitionRequest : MetaDataAquisitionBase
    {
        [JsonProperty(PropertyName = "metaDataAquisitionRuleRefId")]
        public Guid MetaDataAquisitionRuleRefId { get; set; }

        [JsonProperty(PropertyName = "value")]
        public string Value { get; set; }
    }
}

using Newtonsoft.Json;
using System;

namespace Gamification.SDK.Common
{
    public class AwardRule
    {
        [JsonProperty(PropertyName = "awardRefId")]
        public Guid AwardRefId { get; set; }
    }
}

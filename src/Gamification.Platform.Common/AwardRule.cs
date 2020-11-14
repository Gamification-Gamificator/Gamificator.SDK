using Newtonsoft.Json;
using System;

namespace Gamification.Platform.Common
{
    public class AwardRule
    {
        [JsonProperty(PropertyName = "awardRefId")]
        public Guid AwardRefId { get; set; }
    }
}

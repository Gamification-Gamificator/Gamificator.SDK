using Newtonsoft.Json;
using System;

namespace Gamification.SDK.Common
{
    public class Group
    {
        [JsonProperty(PropertyName = "groupRefId")]
        public Guid GroupRefId { get; set; } = Guid.NewGuid();
    }
}

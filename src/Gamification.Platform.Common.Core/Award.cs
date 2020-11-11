using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common.Core
{   
    public class AwardCore
    {
        [JsonProperty(PropertyName = "value")]
        public decimal Value { get; set; }
    }

}

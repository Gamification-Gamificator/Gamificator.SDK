using Gamification.SDK.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.SDK.Display
{
    public class CoinDisplay : CoinCore
    {
        [JsonProperty(PropertyName = "id")]
        public Guid EntityRefId { get; set; }
    }
}

using Gamification.Platform.Common.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common
{
    public class PurchaseRule : PurchaseRuleCore
    {
        [JsonProperty(PropertyName = "id")]
        public Guid EntityRefId { get; set; }
    }
}



using Gamification.SDK.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.SDK.Common
{
    public class PurchaseRule : PurchaseRuleCore
    {
        [JsonProperty(PropertyName = "id")]
        public Guid EntityRefId { get; set; }
    }
}



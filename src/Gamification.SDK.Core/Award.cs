using Gamification.SDK.Core.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.SDK.Core
{   
    public abstract class AwardCore
    {
        [JsonProperty(PropertyName = "value")]
        public decimal Value { get; set; }

        [JsonProperty(PropertyName = "accountingTransactionType")]
        public AccountingTransactionType AccountingTransactionType { get; set; }
    }
}

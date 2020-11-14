using Gamification.Platform.Common.Core.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common.Core
{   
    public class AwardCore
    {
        [JsonProperty(PropertyName = "value")]
        public decimal Value { get; set; }

        [JsonProperty(PropertyName = "accountingTransactionType")]
        public AccountingTransactionType AccountingTransactionType { get; set; }
    }
}

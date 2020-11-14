using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common.Core
{   
    public class AwardCore
    {
        [JsonProperty(PropertyName = "value")]
        public decimal Value { get; set; }

        /// <summary>
        /// Debit = 1, Credit = 2
        /// </summary>
        [JsonProperty(PropertyName = "accountingTransactionType")]
        public int AccountingTransactionType { get; set; }
    }

}

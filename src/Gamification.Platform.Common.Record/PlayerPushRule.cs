using Gamification.Platform.Common.Core;
using Newtonsoft.Json;

namespace Gamification.Platform.Common.Record
{
    public class PlayerPushRuleRecord : PlayerPushRuleCore
    {
        [JsonProperty(PropertyName = "value")]
        public decimal Value { get; set; }
    }

}

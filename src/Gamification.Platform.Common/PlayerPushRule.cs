using Gamification.Platform.Common.Core;
using Newtonsoft.Json;

namespace Gamification.Platform.Common
{
    public class PlayerPushRule : PlayerPushRuleCore
    {
        [JsonProperty(PropertyName = "value")]
        public decimal Value { get; set; }
    }

}

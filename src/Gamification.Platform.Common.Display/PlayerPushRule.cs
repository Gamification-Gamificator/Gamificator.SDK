using Gamification.Platform.Common.Core;
using Newtonsoft.Json;

namespace Gamification.Platform.Common.Display
{
    public class PlayerPushRuleDisplay : PlayerPushRuleCore
    {
        [JsonProperty(PropertyName = "value")]
        public decimal Value { get; set; }
    }

}

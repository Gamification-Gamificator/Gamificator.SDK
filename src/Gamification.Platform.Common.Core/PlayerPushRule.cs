using Newtonsoft.Json;

namespace Gamification.Platform.Common.Core
{
    public class PlayerPushRuleCore
    {
        [JsonProperty(PropertyName = "value")]
        public decimal Value { get; set; }
    }

}

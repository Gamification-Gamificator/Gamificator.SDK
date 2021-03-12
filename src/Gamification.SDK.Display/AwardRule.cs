using Gamification.SDK.Core;
using Newtonsoft.Json;
using System;

namespace Gamification.SDK.Display
{
    public class AwardRuleDisplay : AwardCore
    {
        [JsonProperty(PropertyName = "actionToCheckpoint")]
        public ActionDisplay ActionToCheckpoint { get; set; }
    }
}

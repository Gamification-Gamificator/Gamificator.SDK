using Gamification.Platform.Common.Core;
using Newtonsoft.Json;
using System;

namespace Gamification.Platform.Common.Display
{
    public class AwardRuleDisplay : AwardCore
    {
        [JsonProperty(PropertyName = "actionToCheckpoint")]
        public ActionDisplay ActionToCheckpoint { get; set; }
    }
}

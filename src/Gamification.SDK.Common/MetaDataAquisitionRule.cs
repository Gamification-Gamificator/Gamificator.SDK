using Gamification.SDK.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.SDK.Common
{
    // this allows meta data to be aquired outside the scope of an App
    // so a teacher could cause meta data to be aquired and Gamify it...

    public class MetaDataAquisitionRule : MetaDataAquisitionRuleCore
    {
        [JsonProperty(PropertyName = "id")]
        public Guid EntityRefId { get; set; }
    }
}

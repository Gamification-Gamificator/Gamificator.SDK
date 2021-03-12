﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.SDK.Core
{
    public class ActionOccurrenceRule : OccurrenceRule
    {
        [JsonProperty(PropertyName = "actionRefId")]
        public Guid ActionRefId { get; set; }
    }


    public class ActionOccurrenceRules : List<OccurrenceRule>
    {

    }
}

﻿using Gamification.SDK.Core;
using Newtonsoft.Json;
using System;

namespace Gamification.SDK.Core
{
    public class AchievementEventCore : OccurrenceBase
    {
        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }

        [JsonProperty(PropertyName = "pathPriority")]
        public int PathPriority { get; set; }
    }
}

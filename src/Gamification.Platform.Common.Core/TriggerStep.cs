using Gamification.Platform.Common.Core;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using ThreeTwoSix.Core;

namespace Gamification.Platform.Common.Core
{
    public abstract class TriggerStepCore
    {
        /// <summary>
        /// Steps are ordered to prioritize Award within GoalTriggers
        /// </summary>
        [JsonProperty(PropertyName = "executionOrder")]
        public int ExecutionOrder { get; set; }

        [JsonProperty(PropertyName = "simpleName")]
        public string SimpleName { get; set; }

        [JsonProperty(PropertyName = "nameTranslations")]
        public StringTranslationsCore NameTranslations { get; set; } = new StringTranslationsCore();

    }
}

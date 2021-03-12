using Newtonsoft.Json;
using System;

namespace Gamification.SDK.Common
{
    /// <summary>
    /// A rule that defines when past Actions no longer count towards accumulation triggers
    /// </summary>
    public class ActionCheckpoint
    {
        [JsonProperty(PropertyName = "actionRefId")]
        public Guid ActionRefId { get; set; }

        [JsonProperty(PropertyName = "checkpointedOn")]
        public DateTimeOffset CheckpointedOn { get; private set; } = DateTimeOffset.UtcNow;
    }
}

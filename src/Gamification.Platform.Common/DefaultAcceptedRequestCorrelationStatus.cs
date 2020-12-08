using Newtonsoft.Json;
using System;

namespace Gamification.Platform.Common
{
    public class DefaultAcceptedRequestCorrelationStatus : AcceptedRequestCorrelationStatusCore<AcceptedRequestCorrelationStatusInfoCore>
    {
        /// <summary>
        /// ** New pattern **
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid EntityRefId { get; set; } = Guid.NewGuid();
    }
}

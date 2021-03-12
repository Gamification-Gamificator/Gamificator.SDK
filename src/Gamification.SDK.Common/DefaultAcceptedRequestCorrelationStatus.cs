using Newtonsoft.Json;
using System;
using ThreeTwoSix.Core;

namespace Gamification.SDK.Common
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

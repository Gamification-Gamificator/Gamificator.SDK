using Lazlo.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gamification.Platform.Common
{
    [Serializable]
    public class Contact : ContactCore<EndpointEmail, EndpointVoice, EndpointText>
    {
        [JsonProperty(PropertyName = "id")]
        public Guid EntityRefId { get; set; } = Guid.NewGuid();
    }
}

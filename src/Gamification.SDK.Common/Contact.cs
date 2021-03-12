using Newtonsoft.Json;
using System;
using ThreeTwoSix.Core;

namespace Gamification.SDK.Common
{
    [Serializable]
    public class Contact : ContactCore<AddressCore<MediaTranslationsCore>, EndpointEmailCore, EndpointVoiceCore, EndpointTextCore>
    {
        [JsonProperty(PropertyName = "id")] 
        public Guid EntityRefId { get; set; } = Guid.NewGuid();
    }
}

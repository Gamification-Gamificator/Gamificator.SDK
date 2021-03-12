using Gamification.SDK.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.SDK.Common
{
    /// <summary>
    /// An App, Web Site or Process being Gamified
    /// </summary>
    public class Realm : RealmCore
    {
        /// <summary>
        /// ** New pattern **
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid EntityRefId { get; set; } = Guid.NewGuid();
    }
}

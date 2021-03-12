using Gamification.SDK.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.SDK.Display
{
    /// <summary>
    /// An App, Web Site or Process being Gamified
    /// </summary>
    public class RealmDisplay : RealmCore
    {
        /// <summary>
        /// ** New pattern **
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid EntityRefId { get; set; } = Guid.NewGuid();
    }
}

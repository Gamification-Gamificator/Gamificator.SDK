using Gamification.Platform.Common.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common
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
        public Guid RealmRefId { get; set; } = Guid.NewGuid();
    }
}

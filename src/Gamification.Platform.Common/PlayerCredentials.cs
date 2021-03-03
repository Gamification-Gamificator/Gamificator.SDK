using Gamification.Platform.Common.Core;
using Lazlo.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common
{
    public class PlayerCredentials
    {
        /// <summary>
        /// External player password
        /// </summary>
        [JsonProperty(PropertyName = "password")]
        public string Password { get; set; }

        /// <summary>
        /// Player user name
        /// </summary>
        [JsonProperty(PropertyName = "userName")]
        public string UserName { get; set; }
    }
}

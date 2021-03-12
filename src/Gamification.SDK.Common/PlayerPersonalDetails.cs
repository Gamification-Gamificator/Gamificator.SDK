using Gamification.SDK.Core;

using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.SDK.Common
{
    public class PlayerPersonalDetails : Contact
    {
        /// <summary>
        /// Player gender
        /// </summary>
        [JsonProperty(PropertyName = "gender")]
        public string Gender { get; set; }

        /// <summary>
        /// Player date of birth
        /// </summary>
        [JsonProperty(PropertyName = "dob")]
        public string DOB { get; set; }
    }
}

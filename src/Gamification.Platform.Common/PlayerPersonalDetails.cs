using Gamification.Platform.Common.Core;
using Lazlo.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common
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

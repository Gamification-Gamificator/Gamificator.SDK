using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gamification.Platform.Common.Core
{
    public sealed class StringTranslation
    {
        /// <summary>
        /// en-US
        /// </summary>
        [JsonProperty(PropertyName = "locale")]
        public string Locale { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "localName")]
        public string LocalName { get; set; }
    }

    public sealed class MediaTranslation
    {
        /// <summary>
        /// en-US
        /// </summary>
        [JsonProperty(PropertyName = "locale")]
        public string Locale { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty(PropertyName = "mediaUri")]
        public Uri mediaUri { get; set; }
    }
}

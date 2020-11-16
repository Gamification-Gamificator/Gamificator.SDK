using Lazlo.Common;
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
        public string Locale { get; set; } = "en-US";

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
        public string Locale { get; set; } = "en-US";

        /// <summary>
        /// Light/Dark
        /// </summary>
        [JsonProperty(PropertyName = "theme")]
        public string Theme { get; set; } = "default";

        /// <summary>
        /// Selected may be full color, Unselected may be grey scale
        /// </summary>
        [JsonProperty(PropertyName = "selectedMediaUri")]
        public MediaUri SelectedMediaUri { get; set; }

        [JsonProperty(PropertyName = "unSelectedMediaUri")]
        public MediaUri UnSelectedMediaUri { get; set; }
    }
}

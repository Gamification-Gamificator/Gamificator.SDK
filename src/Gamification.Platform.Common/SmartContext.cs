using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lazlo.Common.Core
{
    public class SmartContextBase<T>
    {
        [JsonProperty(PropertyName = "data")]
        public T Data { get; set; }

        [JsonProperty(PropertyName = "properties")]
        public Dictionary<string, object> Properties { get; set; }

        [JsonProperty(PropertyName = "createdOn")]
        public DateTimeOffset CreatedOn { get; set; }
    }

    public class SmartContext<T> : SmartContextBase<T>
    {
        /// <summary>
        /// An Entity Uuid
        /// gmail username OR Lazlo UserRefId
        /// </summary>
        [JsonProperty(PropertyName = "uuid")]
        public string Uuid { get; set; }

        [JsonProperty(PropertyName = "lat")]
        public double Latitude { get; set; }
        
        [JsonProperty(PropertyName = "long")]
        public double Longitude { get; set; }
    }
}

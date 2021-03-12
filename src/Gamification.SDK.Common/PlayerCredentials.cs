using Newtonsoft.Json;

namespace Gamification.SDK.Common
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

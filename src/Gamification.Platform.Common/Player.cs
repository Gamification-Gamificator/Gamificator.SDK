using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common
{
    public class Player
    {
        public Player()
        {
        }

        public Player(Guid playerRefId)
        {
            PlayerRefId = playerRefId;
        }

        /// <summary>
        /// ** New pattern **
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid PlayerRefId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// All root entities require RealmRefId for multi-tenancy
        /// </summary>
        //[JsonRequired]
        [JsonProperty(PropertyName = "realmRefId")]
        public Guid RealmRefId { get; set; }

        [JsonProperty(PropertyName = "playerAwards")]
        public PlayerAwards PlayerAwards { get; set; } = new PlayerAwards();

        [JsonProperty(PropertyName = "playerActions")]
        public PlayerActionEvents PlayerActions { get; set; } = new PlayerActionEvents();

        [JsonProperty(PropertyName = "tags")]
        public List<string> Tags { get; set; } =  new List<string>();

        [JsonProperty(PropertyName = "playerWebPushSubscription")]
        public PlayerWebPushSubscription PlayerWebPushSubscription { get; set; }
    }
}

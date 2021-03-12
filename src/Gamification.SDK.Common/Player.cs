using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.SDK.Common
{
    public class Player
    {
        public Player()
        {
        }

        public Player(Guid playerRefId)
        {
            EntityRefId = playerRefId;
        }

        /// <summary>
        /// ** New pattern **
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid EntityRefId { get; set; } = Guid.NewGuid();

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

        /// <summary>
        /// Data collected about the Player
        /// </summary>
        [JsonProperty(PropertyName = "metaDataAquisitionEvents")]
        public MetaDataAquisitionEvents MetaDataAquisitionEvents { get; set; } = new MetaDataAquisitionEvents();       
    }
}

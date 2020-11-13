using Gamification.Platform.Common.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common
{    
    public class Coin : CoinCore
    {
        public Coin(){ }

        public Coin(Guid coinRefId)
        { RefId = coinRefId; }

        /// <summary>
        /// ** New pattern **
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid RefId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// All root entities require RealmRefId for multi-tenancy
        /// </summary>
        [JsonRequired]
        [JsonProperty(PropertyName = "realmRefId")]
        public Guid RealmRefId { get; set; }
    }


    public class Coins : List<Coin>
    {
        public new void Add(Coin item)
        {
            if (base.Exists(e => e.RefId.Equals(item.RefId)))
            {
                throw new ArgumentException($"A {nameof(Coin)} with the same {nameof(Coin.RefId)} already exists.");
            }

            if (base.Exists(e => e.SimpleName == item.SimpleName))
            {
                throw new ArgumentException($"A {nameof(Coin)} with the same {nameof(Coin.SimpleName)} already exists.");
            }

            base.Add(item);
        }
    }
}

using Gamification.SDK.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.SDK.Common
{    
    public class Coin : CoinCore
    {
        public Coin(){ }

        public Coin(Guid coinRefId)
        { EntityRefId = coinRefId; }

        /// <summary>
        /// ** New pattern **
        /// </summary>
        [JsonProperty(PropertyName = "id")]
        public Guid EntityRefId { get; set; } = Guid.NewGuid();

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
            if (base.Exists(e => e.EntityRefId.Equals(item.EntityRefId)))
            {
                throw new ArgumentException($"A {nameof(Coin)} with the same {nameof(Coin.EntityRefId)} already exists.");
            }

            if (base.Exists(e => e.SimpleName == item.SimpleName))
            {
                throw new ArgumentException($"A {nameof(Coin)} with the same {nameof(Coin.SimpleName)} already exists.");
            }

            base.Add(item);
        }
    }
}

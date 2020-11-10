using Gamification.Platform.Common.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common
{
    /// <summary>
    /// The Coin of the Realm ;)
    /// </summary>
    public class CoinCore
    {
        [JsonProperty(PropertyName = "simpleName")]
        public string SimpleName { get; set; }

        [JsonProperty(PropertyName = "nameTranslations")]
        public List<StringTranslation> NameTranslations { get; set; } = new List<StringTranslation>();
    }

    public class Coin : CoinCore
    {
        public Coin(){ }

        public Coin(Guid coinRefId)
        { CoinRefId = coinRefId; }

        [JsonProperty(PropertyName = "CoinRefId")]
        public Guid CoinRefId { get { return Id; } set { Id = value; } }

        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; } = Guid.NewGuid();
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
            if (base.Exists(e => e.CoinRefId.Equals(item.CoinRefId)))
            {
                throw new ArgumentException($"A {nameof(Coin)} with the same {nameof(Coin.CoinRefId)} already exists.");
            }

            if (base.Exists(e => e.SimpleName == item.SimpleName))
            {
                throw new ArgumentException($"A {nameof(Coin)} with the same {nameof(Coin.SimpleName)} already exists.");
            }

            base.Add(item);
        }
    }

    public class CoinDisplay : CoinCore
    {
    }

    public class CoinBalanceDisplay
    {
        [JsonProperty(PropertyName = "coin")]
        public CoinDisplay Coin { get; set; }

        [JsonProperty(PropertyName = "balance")]
        public decimal Balance { get; set; }

        [JsonProperty(PropertyName = "asOf")]
        public DateTimeOffset AsOf { get; set; } = DateTimeOffset.UtcNow;
    }
}

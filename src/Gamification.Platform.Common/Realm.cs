using Gamification.Platform.Common.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common
{
    /// <summary>
    /// An App, Web Site or Process being Gamified
    /// </summary>
    public class Realm : RealmCore
    {
        [JsonProperty(PropertyName = "realmRefId")]
        public Guid RealmRefId { get; private set; } = Guid.NewGuid();
    }

    public class RealmCore
    {
        /// <summary>
        /// "Gold Star!"
        /// </summary>
        [JsonProperty(PropertyName = "simpleName")]
        public string SimpleName { get; set; }

        /// <summary>
        /// Étoile d’or ! OR Gold Stern!
        /// </summary>
        [JsonProperty(PropertyName = "nameTranslations")]
        public List<StringTranslation> NameTranslations { get; set; } = new List<StringTranslation>();

        /// <summary>
        /// Trophy image or video etc
        /// </summary>
        [JsonProperty(PropertyName = "mediaTranslations")]
        public List<MediaTranslation> MediaTranslations { get; set; } = new List<MediaTranslation>();

        /// <summary>
        /// Api calls are authenticated using digital signature matching
        /// </summary>
        [JsonProperty(PropertyName = "publicKeys")]
        public Dictionary<string, DateTime> PublicKeys { get; set; }
    }

}

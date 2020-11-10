using Gamification.Platform.Common.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common
{
    /// <summary>
    /// Result of a Goal, the award
    /// </summary>
    public class Achievement : AchievementCore
    {
        [JsonProperty(PropertyName = "achievementRefId")]
        public Guid AchievementRefId { get { return Id; } set { Id = value; } }

        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        //TODO goals can be ordered, timespan of achievement etc etc
        [JsonProperty(PropertyName = "goals")]
        public List<Guid> Goals { get; set; } = new List<Guid>();

        /// <summary>
        /// Provides a grouping context of the PathPriority
        /// Example: Path = Miles
        /// If yu have achieved Silver AND Gold AND Platinum Achievements, your awards ONLY multiply at the Platinum PathPriority
        /// </summary>
        [JsonProperty(PropertyName = "path")]
        public string Path { get; set; }

        /// <summary>
        /// An Achievement can only Multiply Awards based on ONE Achievement
        /// </summary>
        [JsonProperty(PropertyName = "pathPriority")]
        public int PathPriority { get; set; }

        /// <summary>
        /// When achieved, all future Awards of Currency are multiplied
        /// </summary>
        [JsonProperty(PropertyName = "currencyMultiplierRule")]
        public CurrencyMultiplierRule CurrencyMultiplierRule { get; set; }        
    }

    public class AchievementCore
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
    }

    public class AchievementDisplay : AchievementCore
    {
        [JsonProperty(PropertyName = "goals")]
        public Goals Goals { get; set; } = new Goals();
    }
}

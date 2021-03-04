using Gamification.Platform.Common.Core;
using Lazlo.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Gamification.Platform.Common
{
    public class PlayerProfile
    {
        [JsonProperty(PropertyName = "id")]
        public Guid EntityRefId { get; set; } = Guid.NewGuid();

        /// <summary>
        /// External player Id
        /// </summary>
        [JsonProperty(PropertyName = "playerId")]
        public string PlayerId { get; set; }

        /// <summary>
        /// Realm refId
        /// </summary>
        [JsonProperty(PropertyName = "realmRefId")]
        public Guid RealmRefId { get; set; }

        /// <summary>
        /// Gamification player refId
        /// </summary>
        [JsonProperty(PropertyName = "gamificationPlayerRefId")]
        public Guid GamificationPlayerRefId { get; set; }

        /// <summary>
        /// External player credentials
        /// </summary>
        [JsonProperty(PropertyName = "credentials")]
        public PlayerCredentials Credentials { get; set; }

        /// <summary>
        /// player external details
        /// </summary>
        [JsonProperty(PropertyName = "personalDetails")]
        public PlayerPersonalDetails PersonalDetails { get; set; }

        /// <summary>
        /// Betting skill
        /// </summary>
        [JsonProperty(PropertyName = "bettingSkill")]
        public BettingSkill BettingSkill { get; set; }

        /// <summary>
        /// Favorite sports
        /// </summary>
        [JsonProperty(PropertyName = "sports")]
        public Sports Sports { get; set; } = new Sports();

        /// <summary>
        /// Sportbook members
        /// </summary>
        [JsonProperty(PropertyName = "sportbooksMembers")]
        public SportbooksMembers SportbooksMembers { get; set; } = new SportbooksMembers();
    }

    public class Sport
    {
        /// <summary>
        /// Sport name
        /// </summary>
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        /// <summary>
        /// Favorite teams
        /// </summary>
        [JsonProperty(PropertyName = "teams")]
        public Teams Teams { get; set; } = new Teams();
    }

    public class Sports : List<Sport>
    {
    }

    public class Team
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

    public class Teams : List<Team>
    {
    }

    public class BettingSkill
    {
        [JsonProperty(PropertyName = "skillLevel")]
        public string SkillLevel { get; set; }
    }

    public class SportbooksMember
    {
        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }
    }

    public class SportbooksMembers : List<SportbooksMember>
    {
    }
}

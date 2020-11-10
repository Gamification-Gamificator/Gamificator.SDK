using Gamification.Platform.Common.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gamification.Platform.Common
{
    public class GoalCore
    {
        [JsonProperty(PropertyName = "simpleName")]
        public string SimpleName { get; set; }

        [JsonProperty(PropertyName = "nameTranslations")]
        public List<StringTranslation> NameTranslations { get; set; } = new List<StringTranslation>();

        [JsonProperty(PropertyName = "releaseOn")]
        public DateTimeOffset ReleaseOn { get; set; } = DateTimeOffset.MinValue;

        [JsonProperty(PropertyName = "releasedOn")]
        public DateTimeOffset? ReleasedOn { get; set; }


        [JsonProperty(PropertyName = "expireOn")]
        public DateTimeOffset ExpireOn { get; set; } = DateTimeOffset.MaxValue;

        [JsonProperty(PropertyName = "expiredOn")]
        public DateTimeOffset? ExpiredOn { get; set; }
    }

    public class Goal : GoalCore
    {
        [JsonProperty(PropertyName = "goalRefId")]
        public Guid GoalRefId { get { return Id; } set { Id = value; } }

        [JsonProperty(PropertyName = "id")]
        public Guid Id { get; set; } = Guid.NewGuid();

        /// <summary>
        /// All root entities require RealmRefId for multi-tenancy
        /// </summary>
        [JsonRequired]
        [JsonProperty(PropertyName = "realmRefId")]
        public Guid RealmRefId { get; set; }

        /// <summary>
        /// The Goal can itself cause Awards to be granted
        /// </summary>
        [JsonProperty(PropertyName = "awards")]
        public List<AwardRule> Awards { get; set; } = new List<AwardRule>();
    }

    public class Goals : List<Goal>
    {
        public new void Add(Goal item)
        {
            if (base.Exists(e => e.GoalRefId.Equals(item.GoalRefId)))
            {
                throw new ArgumentException($"A {nameof(Goal)} with the same {nameof(Goal.GoalRefId)} already exists.");
            }

            if (base.Exists(e => e.SimpleName == item.SimpleName))
            {
                throw new ArgumentException($"A {nameof(Goal)} with the same {nameof(Goal.SimpleName)} already exists.");
            }

            base.Add(item);
        }
    }

    public class GoalDisplay : GoalCore
    {
        [JsonProperty(PropertyName = "awards")]
        public List<AwardRuleDisplay> Awards { get; set; } = new List<AwardRuleDisplay>();
    }




}

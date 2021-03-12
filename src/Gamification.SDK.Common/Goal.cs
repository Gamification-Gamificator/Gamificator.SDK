using Gamification.SDK.Core;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gamification.SDK.Common
{
    public class Goal : GoalCore
    {
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
            if (base.Exists(e => e.EntityRefId.Equals(item.EntityRefId)))
            {
                throw new ArgumentException($"A {nameof(Goal)} with the same {nameof(Goal.EntityRefId)} already exists.");
            }

            if (base.Exists(e => e.SimpleName == item.SimpleName))
            {
                throw new ArgumentException($"A {nameof(Goal)} with the same {nameof(Goal.SimpleName)} already exists.");
            }

            base.Add(item);
        }
    }
}

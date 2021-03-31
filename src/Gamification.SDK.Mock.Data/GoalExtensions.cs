using Gamification.SDK.Display;
using NLipsum.Core;
using System;
using System.Collections.Generic;
using System.Text;
using ThreeTwoSix.Common;
using ThreeTwoSix.Core;
using ThreeTwoSix.Extensions.Mock.Data;
using ThreeTwoSix.SDK.Extensions;

namespace Gamification.SDK.Mock.Data
{
    public static class GoalDisplayExtensions
    {
        public static GoalDisplay ToMock(this GoalDisplay cb, Uri uri)
        {
            string rawText = Lipsums.LoremIpsum;
            LipsumGenerator lipsum = new LipsumGenerator(rawText, false);

            return new GoalDisplay()
            {
                Awards = new List<AwardRuleDisplay>()
                {
                    new AwardRuleDisplay()
                    {
                        Value  = 400,                        
                    }
                },

                SimpleName = $"{lipsum.GenerateWords(1)[0]}",
                NameTranslations = new StringTranslationsCore().Map(new StringTranslations().ToMock()),
                MediaTranslations = new MediaTranslationsCore().Map(new MediaTranslations().ToMock(uri))
            };
        }

        public static GoalDisplays ToMock(this GoalDisplays goalDisplays, Uri uri, int count = 1)
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            string rawText = Lipsums.LoremIpsum;
            LipsumGenerator lipsum = new LipsumGenerator(rawText, false);

            for (int i = 0; i < count; i++)
            {
                var last = $"{lipsum.GenerateWords(1)[0]}";
                var first = $"{lipsum.GenerateWords(1)[0]}";
                var profile = $"{first}.{last}.{Guid.NewGuid().ToString().Substring(4)}".ToLower();

                goalDisplays.Add(
                    new GoalDisplay().ToMock(uri)
                    );
            }

            return goalDisplays;
        }
    }
}

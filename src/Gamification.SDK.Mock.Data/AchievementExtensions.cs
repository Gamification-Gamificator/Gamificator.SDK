using Gamification.SDK.Common;
using Gamification.SDK.Display;
using NLipsum.Core;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using ThreeTwoSix.Common;
using ThreeTwoSix.Core;
using ThreeTwoSix.Extensions.Mock.Data;
using ThreeTwoSix.SDK.Extensions;

namespace Gamification.SDK.Mock.Data
{
    public static class AchievementExtensions
    {
        public static Achievement ToMock(this Achievement ad, Uri uri)
        {
            string rawText = Lipsums.LoremIpsum;
            LipsumGenerator lipsum = new LipsumGenerator(rawText, false);
            var goals = new Goals().ToMock(uri, 2);
           
            return new Achievement()
            {
                SimpleName = $"{lipsum.GenerateWords(1)[0]}",
                NameTranslations = new StringTranslationsCore().Map(new StringTranslations().ToMock()),
                MediaTranslations = new MediaTranslationsCore().Map(new MediaTranslations().ToMock(uri)),
                Goals = goals.Select(a => a.EntityRefId).ToList()
            };
        }

        public static AchievementDisplay ToMock(this AchievementDisplay ad, Uri uri)
        {
            string rawText = Lipsums.LoremIpsum;
            LipsumGenerator lipsum = new LipsumGenerator(rawText, false);

            return new AchievementDisplay()
            {
                SimpleName = $"{lipsum.GenerateWords(1)[0]}",
                NameTranslations = new StringTranslationsCore().Map(new StringTranslations().ToMock()),
                MediaTranslations = new MediaTranslationsCore().Map(new MediaTranslations().ToMock(uri)),
                Goals = new GoalDisplays().ToMock(uri)                
            };
        }

        public static AchievementDisplays ToMock(this AchievementDisplays achievementDisplays, Uri uri, int count = 1)
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            string rawText = Lipsums.LoremIpsum;
            LipsumGenerator lipsum = new LipsumGenerator(rawText, false);

            for (int i = 0; i < count; i++)
            {
                var last = $"{lipsum.GenerateWords(1)[0]}";
                var first = $"{lipsum.GenerateWords(1)[0]}";
                var profile = $"{first}.{last}.{Guid.NewGuid().ToString().Substring(4)}".ToLower();

                achievementDisplays.Add(
                    new AchievementDisplay().ToMock(uri)
                    );
            }

            return achievementDisplays;
        }
    }
}

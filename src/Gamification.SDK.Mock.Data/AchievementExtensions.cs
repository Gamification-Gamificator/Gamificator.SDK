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
    public static class AchievementDisplayExtensions
    {
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
    }
}

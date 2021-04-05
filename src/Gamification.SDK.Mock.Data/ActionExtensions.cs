using Gamification.SDK.Common;
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
    public static class ActionExtensions
    {
        public static Gamification.SDK.Common.Action ToMock(this Gamification.SDK.Common.Action ad, Uri uri)
        {
            string rawText = Lipsums.LoremIpsum;
            LipsumGenerator lipsum = new LipsumGenerator(rawText, false);

            return new Gamification.SDK.Common.Action()
            {
                SimpleName = $"{lipsum.GenerateWords(1)[0]}",
                NameTranslations = new StringTranslationsCore().Map(new StringTranslations().ToMock()),
                ActionId = Guid.NewGuid().ToString()
            };
        }

        public static ActionDisplay ToMock(this ActionDisplay ad, Uri uri)
        {
            string rawText = Lipsums.LoremIpsum;
            LipsumGenerator lipsum = new LipsumGenerator(rawText, false);

            return new ActionDisplay()
            {
                SimpleName = $"{lipsum.GenerateWords(1)[0]}",
                NameTranslations = new StringTranslationsCore().Map(new StringTranslations().ToMock()),
                ActionId = Guid.NewGuid().ToString()
            };
        }
    }
}

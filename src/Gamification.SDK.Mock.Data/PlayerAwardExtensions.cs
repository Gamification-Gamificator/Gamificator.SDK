using Gamification.SDK.Display;
using NLipsum.Core;
using Gamification.SDK.Common;
using System;
using System.Collections.Generic;
using System.Text;
using ThreeTwoSix.Common;
using ThreeTwoSix.Core;
using ThreeTwoSix.Extensions.Mock.Data;
using ThreeTwoSix.SDK.Extensions;

namespace Gamification.SDK.Mock.Data
{
    public static class PlayerAwardExtensions
    {
        public static PlayerAward ToMock(this PlayerAward pad, Uri uri)
        {
            string rawText = Lipsums.LoremIpsum;
            LipsumGenerator lipsum = new LipsumGenerator(rawText, false);

            return new PlayerAward()
            {
                Description = $"{lipsum.GenerateWords(1)[0]}",
                Value = 400,
                ActionRefId = Guid.NewGuid(),
                AchievementRefId = Guid.NewGuid(),
                CoinRefId = Guid.NewGuid(),
                GoalRefId = Guid.NewGuid(),
                OccurredOn = DateTimeOffset.UtcNow
            };
        }

        public static PlayerAwardDisplay ToMock(this PlayerAwardDisplay pad, Uri uri)
        {
            string rawText = Lipsums.LoremIpsum;
            LipsumGenerator lipsum = new LipsumGenerator(rawText, false);

            return new PlayerAwardDisplay()
            {
                Coin = new CoinDisplay().ToMock(uri),
                TriggeringGoal = new GoalDisplay().ToMock(uri),
                TriggeringAchievement = new AchievementDisplay().ToMock(uri),
                TriggeringAction = new ActionDisplay().ToMock(uri),
                Description = $"{lipsum.GenerateWords(1)[0]}",
                Value = 400
            };
        }

        public static PlayerAwardDisplays ToMock(this PlayerAwardDisplays pads, Uri uri, int count = 1)
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            string rawText = Lipsums.LoremIpsum;
            LipsumGenerator lipsum = new LipsumGenerator(rawText, false);

            for (int i = 0; i < count; i++)
            {
                var last = $"{lipsum.GenerateWords(1)[0]}";
                var first = $"{lipsum.GenerateWords(1)[0]}";
                var profile = $"{first}.{last}.{Guid.NewGuid().ToString().Substring(4)}".ToLower();

                pads.Add(
                    new PlayerAwardDisplay()
                    {
                        Coin = new CoinDisplay().ToMock(uri),
                        TriggeringGoal = new GoalDisplay().ToMock(uri),
                        TriggeringAchievement = new AchievementDisplay().ToMock(uri),
                        TriggeringAction = new ActionDisplay().ToMock(uri),
                        Description = $"{lipsum.GenerateWords(1)[0]}",
                        Value = 400
                    });
            }

            return pads;
        }
    }
}

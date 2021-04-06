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
    public static class PlayerSummaryExtension
    {
        public static PlayerSummaryDisplay ToMock(this PlayerSummaryDisplay pad, Uri uri)
        {
            string rawText = Lipsums.LoremIpsum;
            LipsumGenerator lipsum = new LipsumGenerator(rawText, false);

            return new PlayerSummaryDisplay()
            {
                Goals = new GoalDisplays().ToMock(uri, 2),
                CoinBalances = new CoinBalancesDisplay().ToMock(uri, 2),
                Achievements = new AchievementDisplays().ToMock(uri, 2),
            };
        }
    }
}

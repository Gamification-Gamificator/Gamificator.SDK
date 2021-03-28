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
    public static class CoinBalanceExtensions
    {
        public static IEnumerable<CoinBalanceDisplay> ToMock(this CoinBalancesDisplay coinBalanceDisplay, Uri uri, int count = 1)
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            string rawText = Lipsums.LoremIpsum;
            LipsumGenerator lipsum = new LipsumGenerator(rawText, false);
            var cCount = rnd.Next(6);

            for (int i = 0; i < count; i++)
            {
                var last = $"{lipsum.GenerateWords(1)[0]}";
                var first = $"{lipsum.GenerateWords(1)[0]}";
                var profile = $"{first}.{last}.{Guid.NewGuid().ToString().Substring(4)}".ToLower();

                coinBalanceDisplay.Add(
                    new CoinBalanceDisplay().ToMock(uri)
                    );
            }

            return coinBalanceDisplay;
        }

        public static CoinBalanceDisplay ToMock(this CoinBalanceDisplay cb, Uri uri)
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            string rawText = Lipsums.LoremIpsum;
            LipsumGenerator lipsum = new LipsumGenerator(rawText, false);

            var last = $"{lipsum.GenerateWords(1)[0]}";
            var first = $"{lipsum.GenerateWords(1)[0]}";
            var profile = $"{first}.{last}.{Guid.NewGuid().ToString("N").Substring(4)}".ToLower();

            return new CoinBalanceDisplay()
            {
                Balance = rnd.Next(1, 100),
                AsOf = DateTimeOffset.UtcNow,
                Coin = new CoinDisplay().ToMock(uri)
            };
        }

        public static CoinDisplay ToMock(this CoinDisplay cb, Uri uri)
        {
            var rnd = new Random(Guid.NewGuid().GetHashCode());
            string rawText = Lipsums.LoremIpsum;
            LipsumGenerator lipsum = new LipsumGenerator(rawText, false);

            var last = $"{lipsum.GenerateWords(1)[0]}";
            var first = $"{lipsum.GenerateWords(1)[0]}";
            var profile = $"{first}.{last}.{Guid.NewGuid().ToString("N").Substring(4)}".ToLower();

            return new CoinDisplay()
            {
                EntityRefId = Guid.NewGuid(),
                SimpleName = $"{lipsum.GenerateWords(1)[0]}",
                NameTranslations = new StringTranslationsCore().Map(new StringTranslations().ToMock()),
                MediaTranslations = new MediaTranslationsCore().Map(new MediaTranslations().ToMock(uri))
            };
        }
    }
}

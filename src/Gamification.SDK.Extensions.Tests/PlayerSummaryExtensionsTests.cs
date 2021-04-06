using Gamification.SDK.Display;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gamification.SDK.Mock.Data
{
    [TestClass]
    public class PlayerSummaryExtensionsTests
    {
        [TestMethod]
        public void TestPlayerSummaryMocking()
        {
            var uri = new Uri("https://rprcorporate.blob.core.windows.net/media/sampletrophy.png?sp=rl&st=2021-03-28T19:06:34Z&se=2025-03-29T19:06:00Z&sv=2020-02-10&sr=b&sig=M3oKCysFeKGWw7jDnn1kCFNTFHdqxoOtKVzVFIYXXZs%3D");

            var pad = new PlayerSummaryDisplay().ToMock(uri);
            Assert.IsTrue(pad.Goals.Count > 0);
            Assert.IsTrue(pad.CoinBalances.Count > 0);
            Assert.IsTrue(pad.Achievements.Count > 0);
        }
    }
}

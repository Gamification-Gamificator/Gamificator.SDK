using Gamification.SDK.Display;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using Gamification.SDK.Mock.Data;
using Gamification.SDK.Common.Extensions;

namespace Gamification.SDK.Common.Extensions.Tests
{
    [TestClass]
    public class PlayerAwardExtensionTests
    {
        [TestMethod]
        public void PlayerAwardMappingSucceeds()
        {
            var uri = new Uri("https://rprcorporate.blob.core.windows.net/media/sampletrophy.png?sp=rl&st=2021-03-28T19:06:34Z&se=2025-03-29T19:06:00Z&sv=2020-02-10&sr=b&sig=M3oKCysFeKGWw7jDnn1kCFNTFHdqxoOtKVzVFIYXXZs%3D");
            var a = new PlayerAward().ToMock(uri);
            var ad = new PlayerAwardDisplay().Map(a);

            Assert.IsTrue(a.Value == ad.Value);
        }
    }
}

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
    public class ActionExtensions
    {
        [TestMethod]
        public void ActionMappingSucceeds()
        {
            var uri = new Uri("https://rprcorporate.blob.core.windows.net/media/sampletrophy.png?sp=rl&st=2021-03-28T19:06:34Z&se=2025-03-29T19:06:00Z&sv=2020-02-10&sr=b&sig=M3oKCysFeKGWw7jDnn1kCFNTFHdqxoOtKVzVFIYXXZs%3D");
            var a = new Action().ToMock(uri);
            var ad = new ActionDisplay().Map(a);

            Assert.IsTrue(a.SimpleName == ad.SimpleName);
            Assert.IsTrue(a.ActionId== ad.ActionId);
        }
    }
}

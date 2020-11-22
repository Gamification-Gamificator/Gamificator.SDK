using Gamification.Platform.SDK.CSharp;
using Microsoft.Extensions.Options;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Gamification.Platform.SDK.Test
{
    [TestClass]
    public class ClientTest
    {
        HttpClient httpClient = new HttpClient();

        [TestMethod]
        public async Task ActionTest()
        {
            httpClient.BaseAddress = new Uri("https://sb1-functions.gamificator.io");

            GamificationClient client = new GamificationClient(httpClient, new GamificationClientOptions() { ApiKey = Guid.NewGuid().ToString("N") });
            var success = await client.ActionCompletedV1Async(
                Guid.NewGuid(),
                Guid.NewGuid().ToString("N"),
                new Common.ActionRequest()
                {
                    ActionId = Guid.NewGuid().ToString("N"),
                    SessionHierarchy = "2020:11:22",
                    OccurredOn = DateTimeOffset.UtcNow.AddMinutes(-60)
                },
                33.753746,
                -84.386330
                );
        }
    }
}

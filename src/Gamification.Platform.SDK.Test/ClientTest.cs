using Gamification.Platform.SDK.CSharp;
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

            GamificationClient client = new GamificationClient(httpClient, "https://localhost:44366");
           var all = await client.RetrieveAllActionsAsync(Guid.NewGuid());
        }
    }
}

using Gamification.Platform.Common.Requests;
using Gamification.SDK.CSharp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;

namespace Gamification.SDK.Test
{
    [TestClass]
    public class GamificationClientTests
    {
        private IGamificationClient gamificationFunctionClient;

        private ServiceCollection services = new ServiceCollection();

        public GamificationClientTests()
        {

            services.AddHttpClient<GamificationClient>(
                "functions",
                c => c.BaseAddress = new Uri("http://localhost:7073")
                );

            services.AddOptions();

            services.Configure<GamificationClientOptions>(options =>
            {
                options.ApiKey = Guid.NewGuid().ToString("N");
            });

            services.AddSingleton<IGamificationClient, GamificationClient>();
        }

        [TestMethod]
        public async Task ActionTest()
        {
            try
            {
                var serviceProvider = services.BuildServiceProvider();

                gamificationFunctionClient = serviceProvider.GetService<GamificationClient>();

                var ar = new Platform.Common.ActionRequest()
                {
                    ActionId = Guid.NewGuid().ToString("N"),
                    SessionHierarchy = "2020:11:22",
                    OccurredOn = DateTimeOffset.UtcNow.AddMinutes(-60)
                };

                var json = JsonConvert.SerializeObject(ar);

                var success = await gamificationFunctionClient.ActionCompletedV1Async(
                    Guid.NewGuid(),
                    Guid.NewGuid().ToString("N"),
                    ar,
                    33.753746,
                    -84.386330
                    );

                Assert.IsTrue(success);
            }
            catch (Exception ex)
            {

                throw;
            }
        }

    }
}

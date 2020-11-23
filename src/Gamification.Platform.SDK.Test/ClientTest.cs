using Gamification.Platform.SDK.CSharp;
using Gamification.SDK.CSharp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Gamification.Platform.SDK.Test
{
    [TestClass]
    public class GamificationClientTests
    {
        private IGamificationPlatformClient gamificationClient;
        private IGamificationClient gamificationFunctionClient;

        private ServiceCollection services = new ServiceCollection();

        public GamificationClientTests()
        {

            services.AddHttpClient<CSharp.GamificationPlatformClient>(
                "api", 
                c => c.BaseAddress = new Uri("https://sb1-api.gamificator.io")
                );

            services.AddHttpClient<GamificationClient>(
                "functions",
                c => c.BaseAddress = new Uri("https://sb1-functions.gamificator.io")
                );

            services.AddOptions();

            services.Configure<GamificationClientOptions>(options =>
            {
                options.ApiKey = Guid.NewGuid().ToString("N");
            });

            services.AddSingleton<IGamificationPlatformClient, GamificationPlatformClient>();

            services.AddSingleton<IGamificationClient, GamificationClient>();
        }

        [TestMethod]
        public async Task ActionTest()
        {
            try
            {
                var serviceProvider = services.BuildServiceProvider();

                gamificationFunctionClient = serviceProvider.GetService<GamificationClient>();

                var success = await gamificationFunctionClient.ActionCompletedV1Async(
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
            catch (Exception ex)
            {

                throw;
            }
        }
    }

    //[TestClass]
    //public class GamificationClientTests
    //{
    //    private readonly IGamificationClient gamificationClient;

    //    public GamificationClientTests()
    //    {
    //        var services = new ServiceCollection();
    //        services.AddTransient<IGamificationClient, GamificationClient>();

    //        var serviceProvider = services.BuildServiceProvider();

    //        gamificationClient = serviceProvider.GetService<IGamificationClient>();
    //    }
    //}
}

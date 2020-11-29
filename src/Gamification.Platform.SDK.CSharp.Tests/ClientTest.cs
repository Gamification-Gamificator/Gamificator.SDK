using Gamification.Platform.SDK.CSharp;
using Gamification.SDK.CSharp;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace Gamification.Platform.SDK.Test
{
    [TestClass]
    public class GamificationPlatformClientTests
    {
        private IGamificationPlatformClient gamificationPlatformClient;

        private ServiceCollection services = new ServiceCollection();

        public GamificationPlatformClientTests()
        {

            services.AddHttpClient<GamificationPlatformClient>(
                "functions",
                c => c.BaseAddress = new Uri("https://sb1-api.gamificator.io")
                );

            services.AddOptions();

            services.Configure<GamificationClientOptions>(options =>
            {
                options.ApiKey = Guid.NewGuid().ToString("N");
            });

            services.AddSingleton<IGamificationPlatformClient, GamificationPlatformClient>();
        }

        [TestMethod]
        public async Task ActionTest()
        {
            try
            {
                var serviceProvider = services.BuildServiceProvider();

                gamificationPlatformClient = serviceProvider.GetService<GamificationPlatformClient>();

                var result = await gamificationPlatformClient.RetrieveAllRealmsAsync(Guid.NewGuid());

                
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

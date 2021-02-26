using Gamification.Platform.Common.Requests;
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
                c => c.BaseAddress = new Uri("https://localhost:44366")
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

                RealmRegisterRequest realmRegisterRequest = new RealmRegisterRequest()
                {
                    SimpleName = "Test Realm",
                    WebhookUri = new Uri("https://noplace.com"),
                    OwnerContact = new Lazlo.Common.ContactCore<Lazlo.Common.EndpointEmail, Lazlo.Common.EndpointVoice, Lazlo.Common.EndpointText>()
                    {
                        NameFirst = "Test",
                        NameLast = "Realm",
                        EndpointsEmail = new System.Collections.Generic.List<Lazlo.Common.EndpointEmail>()
                        {
                            new Lazlo.Common.EndpointEmail()
                            {
                                Address = "reggie@lazlo.com"
                            }
                        }
                    }
                };

                var result = await gamificationPlatformClient.RegisterRealmAsync(Guid.NewGuid(), realmRegisterRequest);
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}

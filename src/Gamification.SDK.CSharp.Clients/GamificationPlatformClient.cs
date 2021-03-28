using Gamification.SDK.CSharp;
using Gamification.SDK.CSharp.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Net.Http;
using Gamification.SDK.CSharp.Clients;

namespace Gamification.SDK.CSharp.Clients
{

    /// <summary>
    /// The HttpClient.BaseAddress should NOT be part of the GamificationClientOptions
    /// A second instance could be created with a different base address etc
    /// Only those Options associated with ALL instances should be configured/injected in all client instances
    /// </summary>
    public partial class GamificationPlatformClient : GamificationClientBase
    {
        public GamificationPlatformClient(HttpClient httpClient, IOptions<GamificationClientOptions> options)
        {
            _httpClient = httpClient;

            if (!httpClient.DefaultRequestHeaders.Contains("gamificator-apikey"))
            {
                _httpClient.DefaultRequestHeaders.Add("gamificator-apikey", options.Value.ApiKey);
            }
        }
    }
}


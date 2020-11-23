using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Net.Http;

namespace Gamification.Platform.SDK.CSharp
{

    /// <summary>
    /// The HttpClient.BaseAddress should NOT be part of the GamificationClientOptions
    /// A second instance could be created with a different base address etc
    /// Only those Options associated with ALL instances should be configured/injected in all client instances
    /// </summary>
    public partial class GamificationClient : GamificationClientBase, IGamificationClient
    {
        public GamificationClient(HttpClient httpClient, IOptions<GamificationClientOptions> options)
        {
            _httpClient = httpClient;

            if(!httpClient.DefaultRequestHeaders.Contains("gamificator-apikey"))
            {
                _httpClient.DefaultRequestHeaders.Add("gamificator-apikey", options.Value.ApiKey);
            }
        }
    }
}


using Gamification.SDK.Display;
using Gamification.SDK.Common;
using Gamification.SDK.AutoMapping.Profiles;
using AutoMapper;

namespace Gamification.SDK.Common.Extensions
{
    public static class CoinExtensions
    {
        public static CoinDisplay Map(this CoinDisplay to, Coin from)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<CoinProfile>();
            });

            IMapper mapper = new Mapper(config);
            mapper.Map(from, to);

            return to;
        }
    }
}

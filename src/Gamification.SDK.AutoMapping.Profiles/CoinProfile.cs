using AutoMapper;
using Gamification.SDK.Display;
using Gamification.SDK.Common;

namespace Gamification.SDK.AutoMapping.Profiles
{
    public class CoinProfile : Profile
    {
        public CoinProfile()
        {
            CreateMap<
                Coin,
                CoinDisplay
                >();
        }
    }
}

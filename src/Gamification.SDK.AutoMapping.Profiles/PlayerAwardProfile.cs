using AutoMapper;
using Gamification.SDK.Display;
using Gamification.SDK.Common;

namespace Gamification.SDK.AutoMapping.Profiles
{
    public class PlayerAwardProfile : Profile
    {
        public PlayerAwardProfile()
        {
            CreateMap<
                PlayerAward,
                PlayerAwardDisplay
                >();
        }
    }
}

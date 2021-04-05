using AutoMapper;
using Gamification.SDK.Display;
using Gamification.SDK.Common;

namespace Gamification.SDK.AutoMapping.Profiles
{
    public class GoalProfile : Profile
    {
        public GoalProfile()
        {
            CreateMap<
                Goal,
                GoalDisplay
                >();
        }
    }
}

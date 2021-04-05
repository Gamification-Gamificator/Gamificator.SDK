using AutoMapper;
using Gamification.SDK.Display;
using Gamification.SDK.Common;

namespace Gamification.SDK.AutoMapping.Profiles
{
    public class ActionProfile : Profile
    {
        public ActionProfile()
        {
            CreateMap<
                Action,
                ActionDisplay
                >();
        }
    }
}

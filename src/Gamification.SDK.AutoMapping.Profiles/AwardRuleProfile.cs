using AutoMapper;
using Gamification.SDK.Display;
using Gamification.SDK.Common;

namespace Gamification.SDK.AutoMapping.Profiles
{
    public class AwardRuleProfile : Profile
    {
        public AwardRuleProfile()
        {
            CreateMap<
                AwardRule,
                AwardRuleDisplay
                >();
        }
    }
}

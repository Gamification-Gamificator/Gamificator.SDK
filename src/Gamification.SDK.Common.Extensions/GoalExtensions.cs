using Gamification.SDK.Display;
using Gamification.SDK.Common;
using AutoMapper;
using Gamification.SDK.AutoMapping.Profiles;

namespace Gamification.SDK.Common.Extensions
{
    public static class GoalExtensions
    {
        public static GoalDisplay Map(this GoalDisplay to, Goal from)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<GoalProfile>();
                cfg.AddProfile<AwardRuleProfile>();
            });

            IMapper mapper = new Mapper(config);
            mapper.Map(from, to);

            return to;
        }
    }
}

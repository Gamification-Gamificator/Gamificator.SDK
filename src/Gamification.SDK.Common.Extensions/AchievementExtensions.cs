using Gamification.SDK.Display;
using Gamification.SDK.Common;
using AutoMapper;
using Gamification.SDK.AutoMapping.Profiles;

namespace Gamification.SDK.Common.Extensions
{
    public static class AchievementExtensions
    {
        public static AchievementDisplay Map(this AchievementDisplay to, Achievement from)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<AchievementProfile>();
            });

            IMapper mapper = new Mapper(config);
            mapper.Map(from, to);

            return to;
        }
    }
}

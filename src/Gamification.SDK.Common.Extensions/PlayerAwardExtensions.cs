using Gamification.SDK.Display;
using Gamification.SDK.Common;
using Gamification.SDK.AutoMapping.Profiles;
using AutoMapper;

namespace Gamification.SDK.Common.Extensions
{
    public static class PlayerAwardExtensions
    {
        public static PlayerAwardDisplay Map(this PlayerAwardDisplay to, PlayerAward from)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<PlayerAwardProfile>();
            });

            IMapper mapper = new Mapper(config);
            mapper.Map(from, to);

            return to;
        }
    }
}

using Gamification.SDK.Display;
using Gamification.SDK.Common;
using AutoMapper;
using Gamification.SDK.AutoMapping.Profiles;

namespace Gamification.SDK.Common.Extensions
{
    public static class ActionExtensions
    {
        public static ActionDisplay Map(this ActionDisplay to, Action from)
        {
            var config = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile<ActionProfile>();
            });

            IMapper mapper = new Mapper(config);
            mapper.Map(from, to);

            return to;
        }
    }
}

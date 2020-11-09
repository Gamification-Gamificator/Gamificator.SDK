using System.Linq;

namespace Gamification.Platform.Common.Extensions
{
    public static class ActionExtensions
    {
        public static PlayerActionEvents Map(this PlayerActionEvents toItems, ActionRequests fromItems, Actions actions)
        {
            toItems.Clear();

            foreach (var fromItem in fromItems)
            {
                toItems.Add(new PlayerActionEvent().Map(fromItem, actions));
            }

            return toItems;
        }

        public static PlayerActionEvent Map(this PlayerActionEvent toItem, ActionRequest fromItem, Actions actions)
        {
            toItem.ActionRefId = actions.FirstOrDefault(e => e.ActionId == fromItem.ActionId).ActionRefId;
            toItem.OccurredOn = fromItem.OccurredOn;

            return toItem;
        }
    }
}

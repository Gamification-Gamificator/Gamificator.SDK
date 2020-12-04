using Gamification.Platform.Common;
using Gamification.Platform.Common.Core;
using Gamification.Platform.Common.Extensions;
using Ical.Net;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using Lazlo.Common;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gamification.Platform.Common.Extensions
{
    public static class GoalExtensions
    {
        /// <summary>
        /// Trigger login goal event
        /// </summary>
        /// <param name="goal">goal object</param>
        /// <param name="goalTrigger">goal trigger</param>
        /// <param name="actionRequests">Action Requests from the client</param>
        /// <param name="player">player object</param>
        /// <returns>Awards</returns>
        public static List<AwardRule> TriggerLoginGoalEvents(
            this Goal goal,
            GoalTrigger goalTrigger,
            ActionRequests actionRequests,
            Player player
            )
        {
            var participatingActionEvents = new PlayerActionEvents();

            foreach (var step in goalTrigger.Steps.OrderBy(e => e.ExecutionOrder))
            {
                var start = goalTrigger.ReleaseOn.UtcDateTime.Date.AddMinutes(step.PeriodRecurrence.PeriodMinuteBeginOn.Value);
                var duration = step.PeriodRecurrence.PeriodTimeSpan.GetValueOrDefault();

                // An event taking place between PeriodBeginOn + PeriodTimeSpan
                var vEvent = new CalendarEvent
                {
                    Start = new CalDateTime(start),
                    Duration = duration
                };

                vEvent.RecurrenceRules =
                    new List<RecurrencePattern> {
                    new RecurrencePattern(step.PeriodRecurrence.PeriodPattern)
                };

                var searchStart = DateTime.UtcNow.AddYears(-1).Date;
                var searchEnd = DateTime.UtcNow.Date;

                var calendar = new Calendar();
                calendar.Events.Add(vEvent);

                var occurrences = calendar.GetOccurrences(searchStart, searchEnd);

                // Get the qualifying action requests
                ActionRequests qualifyingActionRequests = new ActionRequests();

                foreach (var actionRequest in actionRequests)
                {
                    //foreach (var rule in step.ActionOccurrenceRules)
                    //{
                    if (actionRequest.OccurredOn != null &&
                        actionRequest.OccurredOn.TimeOfDay > start.TimeOfDay
                            && actionRequest.OccurredOn.TimeOfDay < start.Add(duration).TimeOfDay)
                    {
                        qualifyingActionRequests.Add(actionRequest);
                    }
                    //}
                }

                if (qualifyingActionRequests.Count == goalTrigger.RateLimitRules[0].Count)
                {
                    // Save the goal event for the player if it does not exist
                    GoalEvent goalEvent = new GoalEvent()
                    {
                        AccomplishedOn = DateTimeOffset.UtcNow,
                        GoalRefId = goal.EntityRefId,
                        RealmRefId = goal.RealmRefId,
                        PlayerRefId = player.EntityRefId
                    };

                    return goal.Awards;
                }
            }

            return null;
        }

        /// <summary>
        /// Trigger first time login goal event
        /// </summary>
        /// <param name="goal">goal object</param>
        /// <param name="goalTrigger">goal trigger</param>
        /// <param name="actionRequests">Action Requests from the client</param>
        /// <param name="player">player object</param>
        /// <returns>GoalEvent</returns>
        public static GoalEvent TriggerFirstTimeLoginGoalEvent(
            this Goal goal, GoalTrigger goalTrigger, ActionRequests actionRequests, Player player
            )
        {
            try
            {                
                //Only one goal trigger steps is required for first time login goal
                var step = goalTrigger.Steps[0];
                GoalEvent goalEvent = null;

                // Pick the only actions related to login.
                // The login action will be created by the client and will be persisted in the DB
                var loginActionRefId = ((ActionOccurrenceRule)step.ActionOccurrenceRules[0]).ActionRefId.ToString("N");

                foreach (var actionRequest in actionRequests)
                {
                    if (actionRequest.ActionId == loginActionRefId) //If the actionId matches and the goal event not triggered for the player then trigger it
                    {
                        // Check if the goal event is already persisted, then ignore, otherwise return the goal event
                        goalEvent = new GoalEvent()
                        {
                            AccomplishedOn = DateTimeOffset.UtcNow,
                            GoalRefId = goal.EntityRefId,
                            RealmRefId = goal.RealmRefId,
                            PlayerRefId = player.EntityRefId,
                            OccurredOn = DateTimeOffset.UtcNow
                        };

                        // How to set the triggersteprefid to the playeraction?
                        //action.TriggerStepRefId = triggerStep.TriggerStepRefId;
                        break;
                    }
                }

                return goalEvent;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

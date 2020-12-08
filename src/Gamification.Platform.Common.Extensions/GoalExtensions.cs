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
        /// Trigger first time login achievement goal event
        /// </summary>
        /// <param name="goal">goal object</param>
        /// <param name="goalTrigger">goal trigger</param>
        /// <param name="player">player object</param>
        /// <param name="coinRefId">coinRefId</param>
        /// <param name="achievementRefId">ahievementRefId</param>
        /// <param name="loginGoalEvents">Goal Events</param>
        /// <returns>AchievementEvent</returns>
        public static AchievementEvent TriggerFirstTimeLoginAchievementGoalEvent(
            this Goal goal, GoalTrigger goalTrigger, Player player, Guid coinRefId, Guid achievementRefId, List<GoalEvent> loginGoalEvents
            )
        {
            try
            {                
                //Only one goal trigger step is required for first time login goal
                var step = goalTrigger.Steps[0];
                GoalEvent goalEvent = null;
                AchievementEvent achievementEvent = null;
                
                if (loginGoalEvents == null)
                {
                    loginGoalEvents = new List<GoalEvent>();
                }

                // Pick the only actions related to login.
                // The login action will be created by the client and will be persisted in the DB
                var loginActionRefId = ((ActionOccurrenceRule)step.ActionOccurrenceRules[0]).ActionRefId;
                int count = 0;

                var rateLimitingCount = goalTrigger.RateLimitRules[0].Count;

                foreach (var playerActionEvent in player.PlayerActions)
                {
                    //var playerAwards = player.PlayerAwards.Where(a => a.ActionRefId == loginActionRefId).ToList();
                    if (playerActionEvent.ActionRefId == loginActionRefId) //If the actionId matches the actionId of the login
                    {
                        var firstLoginAchievement = player.PlayerAwards.Where(a => a.AchievementRefId == achievementRefId).FirstOrDefault();
                        var dateTime = player.PlayerAwards.Where(a => a.OccurredOn.Date == playerActionEvent.OccurredOn.Date).FirstOrDefault();

                        // Add the player award once per day. We dont want to add duplicate logons per day
                        if (dateTime == null || dateTime?.OccurredOn.Year == DateTime.MinValue.Year)
                        {
                            // If first login achievement is not awarded then add it to the player awards
                            if (firstLoginAchievement == null)
                            {
                                player.PlayerAwards.Add(new PlayerAward()
                                {
                                    ActionRefId = loginActionRefId,
                                    GoalRefId = goal.EntityRefId,
                                    OccurredOn = playerActionEvent.OccurredOn,
                                    // OccurredOn = DateTimeOffset.UtcNow, // Should this be current datetime or the date time of when the action occurred
                                    AccountingTransactionType = Common.Core.Enums.AccountingTransactionType.Credit,
                                    Description = goalTrigger.SimpleName,
                                    CoinRefId = coinRefId,
                                    AchievementRefId = achievementRefId
                                });

                                // create achievement event for the first time login
                                achievementEvent = new AchievementEvent()
                                {
                                    AchievementRefId = achievementRefId,
                                    OccurredOn = playerActionEvent.OccurredOn,
                                    PlayerRefId = player.EntityRefId,
                                    RealmRefId = goal.RealmRefId,
                                };
                            }
                            else
                            {
                                player.PlayerAwards.Add(new PlayerAward()
                                {
                                    ActionRefId = loginActionRefId,
                                    GoalRefId = goal.EntityRefId,
                                    OccurredOn = playerActionEvent.OccurredOn,
                                    // OccurredOn = DateTimeOffset.UtcNow, // Should this be current datetime or the date time of when the action occurred
                                    AccountingTransactionType = Common.Core.Enums.AccountingTransactionType.Credit,
                                    Description = goalTrigger.SimpleName,
                                    CoinRefId = coinRefId
                                });
                            }

                            // Generate GoalEvent for each login (once per day)
                            goalEvent = new GoalEvent()
                            {
                                AccomplishedOn = DateTimeOffset.UtcNow,
                                GoalRefId = goal.EntityRefId,
                                RealmRefId = goal.RealmRefId,
                                PlayerRefId = player.EntityRefId,
                                OccurredOn = DateTimeOffset.UtcNow,
                            };

                            loginGoalEvents.Add(goalEvent);
                        }
                        // Check if the ratelimit has reached. The goal event will be generated as per the ratelimit
                        //if (count < rateLimitingCount)
                        //{

                            //if (playerAwards.Count() == 0) // Do not allow creating player award more than once for the first time login
                            //{
                            //    goalEvent = new GoalEvent()
                            //    {
                            //        AccomplishedOn = DateTimeOffset.UtcNow,
                            //        GoalRefId = goal.EntityRefId,
                            //        RealmRefId = goal.RealmRefId,
                            //        PlayerRefId = player.EntityRefId,
                            //        OccurredOn = DateTimeOffset.UtcNow
                            //    };

                            //    player.PlayerAwards.Add(new PlayerAward()
                            //    {
                            //        ActionRefId = loginActionRefId,
                            //        GoalRefId = goal.EntityRefId,
                            //        OccurredOn = DateTimeOffset.UtcNow,
                            //        AccountingTransactionType = Common.Core.Enums.AccountingTransactionType.Credit,
                            //        Description = goalTrigger.SimpleName,
                            //        CoinRefId = coinRefId,
                            //        AchievementRefId = achievementRefId
                            //    });

                            //    count += 1;
                            //}
                        //}

                        playerActionEvent.TriggerStepRefId = step.TriggerStepRefId; // however, we burn the triggerStepRefId to the player action event
                    }
                }

                return achievementEvent;
            }
            catch (Exception)
            {
                throw;
            }
        }

        /// <summary>
        /// Trigger consecutive login achievements
        /// </summary>
        /// <param name="goal">goal object</param>
        /// <param name="goalTrigger">goal trigger</param>
        /// <param name="player">player object</param>
        /// <param name="coinRefId">coinRefId</param>
        /// <param name="achievementRefId">ahievementRefId</param>
        /// <param name="days">Consecutive days</param>
        /// <returns>AchievementEvent</returns>
        public static AchievementEvent TriggerConsecutiveLoginsAchievementGoalEvent(
            this Goal goal, GoalTrigger goalTrigger, Player player, Guid coinRefId, Guid achievementRefId, int days
            )
        {
            try
            {
                GoalEvent goalEvent = null;
                AchievementEvent achievementEvent = null;

                var rateLimitingCount = goalTrigger.RateLimitRules[0].Count;
                var qualifyingAwards = new PlayerAwards();
                Guid loginActionRefId;
                foreach (var step in goalTrigger.Steps.OrderBy(e => e.ExecutionOrder))
                {
                    //DateTime start = goalTrigger.ReleaseOn.UtcDateTime.Date.AddMinutes(step.PeriodRecurrence.PeriodMinuteBeginOn.Value); //This should be current date - 7 | 14 | 28. GoalTrigger ReleaseOn date could be old so cant use it??
                    DateTime start = DateTimeOffset.UtcNow.AddDays(-days).Date.AddMinutes(step.PeriodRecurrence.PeriodMinuteBeginOn.Value);
                    TimeSpan duration = step.PeriodRecurrence.PeriodTimeSpan.GetValueOrDefault();
                    loginActionRefId = ((ActionOccurrenceRule)step.ActionOccurrenceRules[0]).ActionRefId;

                    var playerAwards = player.PlayerAwards.Where(a => a.ActionRefId == loginActionRefId).ToList();
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

                    var searchStart = DateTimeOffset.MinValue.DateTime;
                    var searchEnd = DateTime.UtcNow;

                    var calendar = new Calendar();
                    calendar.Events.Add(vEvent);

                    calendar.GetOccurrences(searchStart, searchEnd);

                    foreach (var award in player.PlayerAwards)
                    {
                        // fall in recurrance date(s) 
                        if (vEvent.OccursOn(new CalDateTime(award.OccurredOn.Date)) && award.ActionRefId == loginActionRefId) // Pick all the login actions that falls in the date range
                        {
                            qualifyingAwards.Add(award);
                        }
                    }
                }

                // Check the consecutive days
                var distinctList = qualifyingAwards.Select(x => x.OccurredOn).Distinct().ToList().OrderByDescending(d => d.Date).Take(days).ToList();
                distinctList.Sort();
                bool isSequential = distinctList.Zip(distinctList.Skip(1), (a, b) => b.Date == a.Date.AddDays(1)).All(x => x);

                if (isSequential && distinctList.Count() == days)
                {
                    goalEvent = new GoalEvent()
                    {
                        AccomplishedOn = DateTimeOffset.UtcNow,
                        GoalRefId = goal.EntityRefId,
                        RealmRefId = goal.RealmRefId,
                        PlayerRefId = player.EntityRefId,
                        OccurredOn = DateTimeOffset.UtcNow
                    };

                    achievementEvent = new AchievementEvent()
                    {
                        AchievementRefId = achievementRefId,
                        OccurredOn = DateTimeOffset.UtcNow,
                        PlayerRefId = player.EntityRefId,
                        RealmRefId = goal.RealmRefId,
                    };

                    player.PlayerAwards.Add(new PlayerAward()
                    {
                        ActionRefId = loginActionRefId,
                        GoalRefId = goal.EntityRefId,
                        OccurredOn = DateTimeOffset.UtcNow, // Should this be current datetime or the date time of when the action occurred??
                        AccountingTransactionType = Common.Core.Enums.AccountingTransactionType.Credit,
                        Description = goalTrigger.SimpleName,
                        CoinRefId = coinRefId,
                        AchievementRefId = achievementRefId
                    });
                }

                return achievementEvent;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}

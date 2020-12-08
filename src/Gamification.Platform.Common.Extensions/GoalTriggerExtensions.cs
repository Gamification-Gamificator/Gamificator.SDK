using Gamification.Platform.Common.Core;
using Ical.Net;
using Ical.Net.CalendarComponents;
using Ical.Net.DataTypes;
using NetTopologySuite.Geometries;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using Point = NetTopologySuite.Geometries.Point;

namespace Gamification.Platform.Common.Extensions
{
    public static class GoalTriggerExtensions
    {
        public static bool GoalTriggerTagsAreValid(
            this GoalTrigger goalTrigger,
            Player player
            )
        {
            return goalTrigger.Tags.Any(e => player.Tags.Any(f => e == f));
        }

        public static List<ActionRequest> QualifyingActionRequestsByRecurrence(this GoalTrigger goalTrigger, ActionRequests actionRequests)
        {
            var qualifyingActionsRequests = new ActionRequests();

            foreach (var rateLimitRule in goalTrigger.RateLimitRules)
            {
                // An event taking place between PeriodBeginOn + PeriodTimeSpan
                var vEvent = new CalendarEvent
                {
                    Start = new CalDateTime(goalTrigger.ReleaseOn.UtcDateTime.Date.AddMinutes(rateLimitRule.PeriodRecurrence.PeriodMinuteBeginOn.Value)),
                    Duration = rateLimitRule.PeriodRecurrence.PeriodTimeSpan.GetValueOrDefault()
                };

                vEvent.RecurrenceRules = JsonConvert.DeserializeObject<List<RecurrencePattern>>(
                    rateLimitRule.PeriodRecurrence.PeriodPattern
                    );

                var searchStart = DateTimeOffset.MinValue.DateTime;
                var searchEnd = DateTime.UtcNow;

                var calendar = new Calendar();
                calendar.Events.Add(vEvent);

                var occurrences = calendar.GetOccurrences(searchStart, searchEnd);

                // do any of the ActionsRequests fall within this RateLimitRule of this GoalTrigger 
                foreach (var actionRequest in actionRequests)
                {
                    if(vEvent.OccursOn(new CalDateTime(actionRequest.OccurredOn.Date)))
                    {
                        // now check period hours
                        qualifyingActionsRequests.Add(actionRequest);
                    }
                }
            }
            
            return qualifyingActionsRequests;
        }

        /// <summary>
        /// Method to return those ActionRequests that qualify to be applid to a Goal based on Recurrance
        /// </summary>
        /// <param name="goalTrigger"></param>
        /// <param name="actionRequests"></param>
        /// <param name="actions"></param>
        /// <returns></returns>
        public static ActionRequests RecurranceQualifyingActionRequestsByGoalTriggerSteps(
            this GoalTrigger goalTrigger, 
            ActionRequests actionRequests
            )
        {
            var qualifyingActions = new ActionRequests();

            foreach (var step in goalTrigger.Steps)
            {
                var start = goalTrigger.ReleaseOn.UtcDateTime.Date.AddMinutes(
                            step.PeriodRecurrence.PeriodMinuteBeginOn.Value);
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

                // do any of the ActionsRequests fall within this Step of this GoalTrigger 
                foreach (var action in actionRequests)
                {
                    // fall in recurrance date(s) 
                    if (vEvent.OccursOn(new CalDateTime(action.OccurredOn.Date)))
                    {
                        if(
                            action.OccurredOn.TimeOfDay > start.TimeOfDay
                            && action.OccurredOn.TimeOfDay < start.Add(duration).TimeOfDay
                            )
                        {
                            // the Action occurred within a valid date and time of recurrance
                            qualifyingActions.Add(action);
                        }
                    }
                }
            }

            return qualifyingActions;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="goalTrigger"></param>
        /// <param name="playerActionEvents">The events to be considered by this Step</param>
        /// <returns></returns>
        public static PlayerActionEvents ValidateSteps(
            this GoalTrigger goalTrigger,
            PlayerActionEvents playerActionEvents
            )
        {
            var participatingActionEvents = new PlayerActionEvents();

            // process in order
            // each step, marks goalrefid in actions that are returned thus burning for next step
            foreach (var step in goalTrigger.Steps.OrderBy(e=>e.ExecutionOrder))
            {
                try
                {
                    participatingActionEvents.AddRange(
                        step.ValidateStep(playerActionEvents, participatingActionEvents,
                            goalTrigger.ReleaseOn.UtcDateTime.Date.AddMinutes(
                            step.PeriodRecurrence.PeriodMinuteBeginOn.Value),
                            step.PeriodRecurrence.PeriodTimeSpan.GetValueOrDefault())
                        );

                    // if valid then which participatingActionEvents participated?

                    // if set to burn then add GoalTriggerRefId
                    participatingActionEvents.ForEach(e => e.TriggerStepRefId = goalTrigger.EntityRefId);

                    // if Step is valid then continue
                    continue;
                }
                catch (ArgumentException aex)
                {
                    return new PlayerActionEvents();
                }
                catch (Exception ex)
                {
                    throw;
                }
            }

            // when all steps are valid the Goal is accomplished
            return participatingActionEvents;
        }

        public static PlayerActionEvents ValidateStep(
            this TriggerStep triggerStep,
            PlayerActionEvents currentPlayerActions,
            PlayerActionEvents participatingPlayerActions,
            DateTime start,
            TimeSpan duration
            )
        {

            var stepPlayerActions = new PlayerActionEvents();

#pragma warning disable CS0219 // Variable is assigned but its value is never used
            bool contains;
#pragma warning restore CS0219 // Variable is assigned but its value is never used

            foreach (var action in currentPlayerActions)
            {
                foreach (var rule in triggerStep.ActionOccurrenceRules)
                {
                    if (
                        action.OccurredAt != null &&
                        rule.InsideOf.Contains(new Point(
                            new Coordinate(
                                action.OccurredAt.Coordinate.CoordinateValue.X,
                                action.OccurredAt.Coordinate.CoordinateValue.Y
                                )
                            )))
                    {
                        contains = true;

                        if (!stepPlayerActions.Exists(e => e.ActionRefId.Equals(action.ActionRefId))) stepPlayerActions.Add(action);
                    }
                }
            }

            // logic to validate PeriodRecurrence (i.e. other than Geofence)
            foreach (var action in currentPlayerActions)
            {
                if (triggerStep.PeriodRecurrence != null)
                {
                    if (action.OccurredOn != null &&
                        action.OccurredOn.TimeOfDay > start.TimeOfDay
                            && action.OccurredOn.TimeOfDay < start.Add(duration).TimeOfDay)
                    {
                        contains = true;

                        if (!stepPlayerActions.Exists(e => e.ActionRefId.Equals(action.ActionRefId))) stepPlayerActions.Add(action);
                    }
                }
            }

            // add stepPlayerActions to participatingPlayerActions
            foreach (var action in stepPlayerActions)
            {
                action.TriggerStepRefId = triggerStep.TriggerStepRefId;

                if (!participatingPlayerActions.Exists(e => e.ActionRefId.Equals(action.ActionRefId))) participatingPlayerActions.Add(action);
            }

            return participatingPlayerActions;
        }

        public static GoalTriggers LoadTestData(
            this GoalTriggers goalTriggers, 
            Guid realmRefId, 
            Goal goal,
            Actions actions,
            NetTopologySuite.Geometries.MultiPolygon insideOf,
            NetTopologySuite.Geometries.MultiPolygon outsideOf,
            List<string> tags)
        {
            var rnd = new Random();

            for (int i = 0; i < rnd.Next(1, 10); i++)
            {
                var simpleName = $"Goal Trigger [{i}]";

                var goalTrigger = new GoalTrigger()
                {
                    RealmRefId = realmRefId,
                    GoalRefId = goal.EntityRefId,
                    SimpleName = simpleName,
                    Priority = i,
                    ReleaseOn = DateTimeOffset.UtcNow.AddDays(-365),
                    ExpireOn = DateTimeOffset.MaxValue,
                    Tags = tags,
                    RollingPeriodActionFilter = TimeSpan.FromDays(-30),
                };

                goalTrigger.RateLimitRules.Add(
                    new RateLimitRule()
                    {
                        Count = 1
                    }
                );

                goalTrigger.NameTranslations.Add(
                    new StringTranslation() { Locale = "en-Us", LocalName = simpleName }
                    );

                goalTrigger.Steps.Add(
                    new TriggerStep()
                    {
                        ExecutionOrder = i,
                        PeriodRecurrence = new PeriodRecurrence()
                        {
                            PeriodMinuteBeginOn = Convert.ToInt32(TimeSpan.FromMinutes(0).TotalMinutes),
                            PeriodTimeSpan = TimeSpan.FromSeconds((24 * 60 * 60) - 1),
                            PeriodPattern =
                                    new RecurrencePattern(FrequencyType.Daily, interval: 1)
                                    {
                                        Until = DateTime.MaxValue
                                    }.ToString()
                        },
                        ActionOccurrenceRules = new ActionOccurrenceRules()
                        {
                            new ActionOccurrenceRule()
                            {
                                ActionRefId = actions[0].EntityRefId,
                                OperationType = Core.Enums.OperationRuleType.And,
                                TenseType = Core.Enums.TenseRuleType.Did,
                                CompareType = Core.Enums.CompareRuleType.GreaterOrEqual,
                                Count = 1,
                                PeriodRecurrence = new PeriodRecurrence()
                                {
                                    PeriodMinuteBeginOn = Convert.ToInt32(TimeSpan.FromMinutes(0).TotalMinutes),
                                    PeriodTimeSpan = TimeSpan.FromSeconds((24 * 60 * 60) - 1),
                                    PeriodPattern =
                                            new RecurrencePattern(FrequencyType.Daily, interval: 1)
                                            {
                                                Until = DateTime.MaxValue
                                            }.ToString()
                                },
                                InsideOf = insideOf,
                                OutsideOf = outsideOf
                            }
                        }
                    }
                ); ;

                goalTriggers.Add(goalTrigger);
            }

            return goalTriggers;
        }

        public static void LoadSingleTestGoalTriggerStepsData(
            this GoalTrigger goalTrigger,
            Guid actionRedId,
            int executionOrder,
            NetTopologySuite.Geometries.MultiPolygon insideOf,
            NetTopologySuite.Geometries.MultiPolygon outsideOf)
        {
            goalTrigger.Steps.Add(
                new TriggerStep()
                {
                    ExecutionOrder = executionOrder,
                    PeriodRecurrence = new PeriodRecurrence()
                    {
                        PeriodMinuteBeginOn = Convert.ToInt32(TimeSpan.FromMinutes(0).TotalMinutes),
                        PeriodTimeSpan = TimeSpan.FromSeconds((24 * 60 * 60) - 1),
                        PeriodPattern =
                                new RecurrencePattern(FrequencyType.Daily, interval: 1)
                                {
                                    Until = DateTime.MaxValue
                                }.ToString()
                    },
                    ActionOccurrenceRules = new ActionOccurrenceRules()
                    {
                        new ActionOccurrenceRule()
                        {
                            ActionRefId = actionRedId,
                            OperationType = Core.Enums.OperationRuleType.And,
                            TenseType = Core.Enums.TenseRuleType.Did,
                            CompareType = Core.Enums.CompareRuleType.GreaterOrEqual,
                            Count = 1,
                            PeriodRecurrence = new PeriodRecurrence()
                            {
                                PeriodMinuteBeginOn = Convert.ToInt32(TimeSpan.FromMinutes(0).TotalMinutes),
                                PeriodTimeSpan = TimeSpan.FromSeconds((24 * 60 * 60) - 1),
                                PeriodPattern =
                                        new RecurrencePattern(FrequencyType.Daily, interval: 1)
                                        {
                                            Until = DateTime.MaxValue
                                        }.ToString()
                            },
                            InsideOf = insideOf,
                            OutsideOf = outsideOf
                        }
                    }
                }
            ); 
        }

        /// <summary>
        /// Create GoalTriggers
        /// </summary>
        /// <param name="goalTriggers"></param>
        /// <param name="realmRefId"></param>
        /// <param name="goalRefId"></param>
        /// <param name="actionRedId"></param>
        /// <param name="executionOrder"></param>
        /// <param name="insideOf"></param>
        /// <param name="outsideOf"></param>
        public static void LoadGoalTriggersDataForLogin(
            this GoalTriggers goalTriggers,
            Guid realmRefId,
            Guid goalRefId,
            Guid actionRedId,
            int executionOrder,
            NetTopologySuite.Geometries.MultiPolygon insideOf,
            NetTopologySuite.Geometries.MultiPolygon outsideOf)
        {
            var goalTrigger = new GoalTrigger()
            {
                RealmRefId = realmRefId,
                GoalRefId = goalRefId,
                SimpleName = "Login",
                Priority = 1,
                ReleaseOn = DateTimeOffset.UtcNow.AddDays(-7),
                ExpireOn = DateTimeOffset.MaxValue,
                RollingPeriodActionFilter = TimeSpan.FromDays(-30),
            };

            goalTrigger.RateLimitRules.Add(
                new RateLimitRule()
                {
                    Count = 1
                }
            );

            goalTrigger.Steps.Add(
                new TriggerStep()
                {
                    ExecutionOrder = executionOrder,
                    PeriodRecurrence = new PeriodRecurrence()
                    {
                        PeriodMinuteBeginOn = Convert.ToInt32(TimeSpan.FromMinutes(0).TotalMinutes),
                        PeriodTimeSpan = TimeSpan.FromSeconds((24 * 60 * 60) - 1),                        
                        PeriodPattern =
                                new RecurrencePattern(FrequencyType.Daily, interval: 1)
                                {
                                    Until = DateTime.MaxValue,
                                }.ToString()
                    },
                    ActionOccurrenceRules = new ActionOccurrenceRules()
                    {
                        new ActionOccurrenceRule()
                        {
                            ActionRefId = actionRedId,
                            OperationType = Core.Enums.OperationRuleType.And,
                            TenseType = Core.Enums.TenseRuleType.Did,
                            CompareType = Core.Enums.CompareRuleType.GreaterOrEqual,
                            Count = 1,
                            PeriodRecurrence = new PeriodRecurrence()
                            {
                                PeriodMinuteBeginOn = Convert.ToInt32(TimeSpan.FromMinutes(0).TotalMinutes),
                                PeriodTimeSpan = TimeSpan.FromSeconds((24 * 60 * 60) - 1),
                                PeriodPattern =
                                        new RecurrencePattern(FrequencyType.Daily, interval: 1)
                                        {
                                            Until = DateTime.MaxValue
                                        }.ToString()
                            },
                            InsideOf = insideOf,
                            OutsideOf = outsideOf
                        }
                    }
                }
            );

            goalTriggers.Add(goalTrigger);
        }

        public static Goal LoadTestData(
            this Goal goal,
            Guid realmRefId,
            Awards awards
            )
        {
            var rnd = new Random();

            var simpleName = $"Goal [{Guid.NewGuid()}]";

            goal.EntityRefId = Guid.NewGuid();
            goal.ExpireOn = DateTimeOffset.UtcNow.AddDays(rnd.Next(10, 100));
            goal.RealmRefId = realmRefId;
            goal.SimpleName = simpleName;
            goal.Awards = awards.Select(e=> new AwardRule() { AwardRefId = e.EntityRefId }).ToList();

            return goal;
        }

        public static Coins LoadTestData(
            this Coins coins,
            Guid realmRefId
            )
        {
            var rnd = new Random();

            coins.Add(
                new Coin()
                {
                    SimpleName = $"Bucks [{Guid.NewGuid()}]"
                }
                );
            coins.Add(
                new Coin()
                {
                    SimpleName = $"XP [{Guid.NewGuid()}]"
                }
                );
            coins.Add(
                new Coin()
                {
                    SimpleName = $"First Login [{Guid.NewGuid()}]"
                }
                );
            coins.Add(
                new Coin()
                {
                    SimpleName = $"7 Consecutive Login Streak [{Guid.NewGuid()}]"
                }
                );
            coins.Add(
                new Coin()
                {
                    SimpleName = $"14 Consecutive Login Streak [{Guid.NewGuid()}]"
                }
                );
            coins.Add(
                new Coin()
                {
                    SimpleName = $"28 Consecutive Login Streak [{Guid.NewGuid()}]"
                }
                );
            return coins;
        }

        public static Awards LoadTestData(
            this Awards awards,
            Coins coins
            )
        {
            var rnd = new Random();

            foreach (var coin in coins)
            {
                awards.Add(
                    new Award()
                    {
                        CoinRefId = coin.EntityRefId,
                        Value = rnd.Next(2, 10),
                    });
            }

            return awards;
        }
    }
}

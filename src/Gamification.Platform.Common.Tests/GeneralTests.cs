using Gamification.Platform.Common.Extensions;
using Lazlo.Common.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;

namespace Gamification.Platform.Common.Tests
{
    [TestClass]
    public class GeneralTests
    {
        #region Lists

        [TestMethod]
        public void GoalTriggerExceptionsSucceed()
        {
            // Arrange
            var gTriggers = new GoalTriggers();

            var goalRefId = Guid.NewGuid();

            gTriggers.Add(
                new GoalTrigger()
                {
                    GoalRefId = goalRefId,
                    Priority = 1,
                    SimpleName = "Fuu"
                }
            );

            // Act 

            // Assert

            // duplicate SimpleName
            Assert.ThrowsException<ArgumentException>(() =>
            {
                gTriggers.Add(
                    new GoalTrigger()
                    {
                        GoalRefId = goalRefId,
                        Priority = 2,
                        SimpleName = "Fuu"
                    }
                );
            }
            );

            // duplicate Priority
            Assert.ThrowsException<ArgumentException>(() =>
            {
                gTriggers.Add(
                    new GoalTrigger()
                    {
                        GoalRefId = goalRefId,
                        Priority = 1,
                        SimpleName = "Fuu2"
                    }
                );
            }
            );
        }

        [TestMethod]
        public void TriggerStepsExceptionsSucceed()
        {
            // Arrange
            var entities = new TriggerSteps();

            var goalRefId = Guid.NewGuid();

            entities.Add(
                new TriggerStep()
                {
                    ExecutionOrder = 1,
                    SimpleName = "Fuu"
                }
            );

            // Act 

            // Assert

            // duplicate SimpleName
            Assert.ThrowsException<ArgumentException>(() =>
            {
                entities.Add(
                new TriggerStep()
                {
                    ExecutionOrder = 2,
                    SimpleName = "Fuu"
                }
                );
            }
            );

            // duplicate ExecutionOrder
            Assert.ThrowsException<ArgumentException>(() =>
            {
                entities.Add(
                new TriggerStep()
                {
                    ExecutionOrder = 1,
                    SimpleName = "Fuu2"
                }
                );
            }
            );
        }

        #endregion Lists

        #region Tags

        [TestMethod]
        public void GoalTriggerTagMatchingPlayerTagValidates()
        {
            var realmRefId = Guid.NewGuid();

            var player = new Player()
            {
                RealmRefId = realmRefId,
            };

            player.Tags.Add("Fuu");

            var goalTrigger = new GoalTrigger()
            {
                GoalRefId = Guid.NewGuid(),
                SimpleName = "Fuu",
                Priority = 0,
                ReleaseOn = DateTimeOffset.UtcNow.AddDays(-365),
                ExpireOn = DateTimeOffset.MaxValue,
            };

            goalTrigger.Tags.Add("Fuu");

            Assert.IsTrue(goalTrigger.GoalTriggerTagsAreValid(player));
        }

        [TestMethod]
        public void GoalTriggerTagMatchingPlayerTagFails()
        {
            var realmRefId = Guid.NewGuid();

            var player = new Player()
            {
                RealmRefId = realmRefId,
            };

            player.Tags.Add("Fuu");

            var goalTrigger = new GoalTrigger()
            {
                GoalRefId = Guid.NewGuid(),
                SimpleName = "Fuu",
                Priority = 0,
                ReleaseOn = DateTimeOffset.UtcNow.AddDays(-365),
                ExpireOn = DateTimeOffset.MaxValue,
            };

            goalTrigger.Tags.Add("Fuu2");

            Assert.IsFalse(goalTrigger.GoalTriggerTagsAreValid(player));
        }

        #endregion Tags
    }
}

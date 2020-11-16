using Gamification.Platform.Common.Extensions;
using Lazlo.Common;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gamification.Platform.Common.Tests
{
    [TestClass]
    public class GoalTriggerExtensionTests
    {
        [TestMethod]
        [DeploymentItem(@"GeorgiaGeoJsonData.json")]
        public void SingleActionAwardInsideOfGeoFenceRuleSucceeds()
        {
            var actionId = Guid.NewGuid().ToString("N");

            var realmRefId = Guid.NewGuid();

            var player = new Player()
            {
                RealmRefId = realmRefId,
            };

            player.Tags.Add("Fuu");

            var actions = new Actions()
            {
                new Common.Action()
                    {
                        RealmRefId = realmRefId,
                        ReleasedOn = DateTimeOffset.UtcNow.AddSeconds(-60),
                        ActionId = actionId,
                    }
            };

            var sr = new List<SmartContext<ActionRequest>>()
            {
                new SmartContext<ActionRequest>() { Latitude = 33.753746, Longitude = -84.386330, Data = new ActionRequest(){ ActionId = actionId, OccurredOn = DateTimeOffset.UtcNow.AddDays(-10) } },
                new SmartContext<ActionRequest>() { Latitude = 33.753746, Longitude = -84.386330, Data = new ActionRequest(){ ActionId = actionId, OccurredOn = DateTimeOffset.UtcNow.AddHours(-36) } },
                new SmartContext<ActionRequest>() { Latitude = 33.753746, Longitude = -84.386330, Data = new ActionRequest(){ ActionId = actionId, OccurredOn = DateTimeOffset.UtcNow.AddHours(-24) } },
                new SmartContext<ActionRequest>() { Latitude = 33.753746, Longitude = -84.386330, Data = new ActionRequest(){ ActionId = actionId, OccurredOn = DateTimeOffset.UtcNow.AddHours(-8) } },
                new SmartContext<ActionRequest>() { Latitude = 33.753746, Longitude = -84.386330, Data = new ActionRequest(){ ActionId = actionId, OccurredOn = DateTimeOffset.UtcNow.AddMinutes(-1) } }
            };

            NetTopologySuite.Geometries.MultiPolygon insideOf = null;

            var jsonSerializer = NetTopologySuite.IO.GeoJsonSerializer.Create();

            using (StreamReader file = File.OpenText(@"GeorgiaGeoJsonData.json"))
            using (JsonTextReader reader = new JsonTextReader(file))
            {
                insideOf = jsonSerializer.Deserialize<NetTopologySuite.Geometries.MultiPolygon>(reader);
            }

            var coins = new Coins().LoadTestData(realmRefId);

            var awards = new Awards().LoadTestData(coins);

            var goal = new Goal().LoadTestData(realmRefId, awards);

            var goalTriggers = new GoalTriggers().LoadTestData(realmRefId, goal, actions, insideOf, null, null); ;

            foreach (var goalTrigger in goalTriggers)
            {
                var events = new PlayerActionEvents();
                events.AddRange(
                    sr.Select(e =>
                        new PlayerActionEvent()
                        {
                            OccurredAt = new NetTopologySuite.Geometries.Point(e.Longitude, e.Latitude)
                        }.Map(e.Data, actions)
                    )
                );

                var qualifyingActionRequests = goalTrigger.ValidateSteps(events);

                Assert.IsTrue(qualifyingActionRequests.Count > 0);
            }


            // the action is "read an ad"
            // step 1 read an ad on tuesday
            // step 2 read an ad on thursday



            // convert requests to Events


        }
    }
}

using Gamification.SDK.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gamification.SDK.Requests
{
    public sealed class RealmRegisterRequest :RealmCore
    {
    }

    public sealed class RealmCreateRequest : RealmCore
    {
    }

    public sealed class RealmUpdateRequest : RealmCore
    {
    }


    public sealed class AwardCreateRequest: AwardCore
    {
    }

    public sealed class AwardUpdateRequest : AwardCore
    {
    }

    public sealed class AchievementCreateRequest : AchievementCore
    {
    }

    public sealed class AchievementUpdateRequest : AchievementCore
    {
    }


    public sealed class GoalCreateRequest: GoalCore
    {
    }

    public sealed class GoalTriggerCreateRequest: GoalTriggerCore
    {
    }

    public sealed class GoalTriggerUpdateRequest : GoalTriggerCore
    {
    }


    public sealed class GoalUpdateRequest : GoalCore
    {
    }

    public sealed class CoinCreateRequest : CoinCore
    {
    }

    public sealed class CoinUpdateRequest : CoinCore
    {
    }

   

    public sealed class ActionCreateRequest : ActionCore
    {
    }

    public sealed class ActionUpdateRequest : ActionCore
    {
    }

    public sealed class PlayerProfileRequest
    {
        public string Email { get; set; }
    }
}

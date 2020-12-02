using Gamification.Platform.Common.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace Gamification.Platform.Common.Requests
{
    public sealed class RealmRegisterRequest :RealmCore
    {
    }

    public sealed class RealmCreateRequest : RealmCore
    {
    }

    public sealed class RealmUpdateRequest : Realm
    {
    }


    public sealed class AwardCreateRequest: AwardCore
    {
    }

    public sealed class AwardUpdateRequest : Award
    {
    }

    public sealed class GoalCreateRequest: GoalCore
    {
    }

    public sealed class GoalTriggerCreateRequest: GoalTriggerCore
    {
    }

    public sealed class GoalTriggerUpdateRequest : GoalTrigger
    {
    }


    public sealed class GoalUpdateRequest : Goal
    {
    }

    public sealed class CoinCreateRequest : CoinCore
    {
    }

    public sealed class CoinUpdateRequest : Coin
    {
    }

   

    public sealed class ActionCreateRequest : ActionCore
    {
    }

    public sealed class ActionUpdateRequest : Gamification.Platform.Common.Action
    {
    }
}

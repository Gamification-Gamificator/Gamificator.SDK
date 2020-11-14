using System;
using System.Collections.Generic;
using System.Text;

namespace Gamification.Platform.Common.Core.Enums
{
    public enum OperationRuleType
    {
        None = 0,
        And = 1,
        Or = 2,
    }

    public enum TenseRuleType
    {
        None = 0,
        Did = 1,
        DidNot = 2,
    }

    public enum CompareRuleType
    {
        None = 0,
        Greater = 1,
        GreaterOrEqual = 2,
        Less = 3,
        LessOrEqual = 4,
    }

    public enum AccountingTransactionType
    {
        Debit = 1,
        Credit = 2,
    }
}

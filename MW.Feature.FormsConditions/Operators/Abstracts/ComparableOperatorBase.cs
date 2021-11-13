using System;

namespace MW.Feature.FormConditions.Operators.Abstracts
{
    public abstract class ComparableOperatorBase : OperatorBase
    {
        protected override bool IsMatch(object fieldValue, object operatorValue)
        {
            if (!(fieldValue is IComparable comparable) || !(operatorValue is IComparable))
            {
                return false;
            }

            return IsCompareResultMatch(comparable.CompareTo(operatorValue));
        }

        protected abstract bool IsCompareResultMatch(int compareResult);
    }
}
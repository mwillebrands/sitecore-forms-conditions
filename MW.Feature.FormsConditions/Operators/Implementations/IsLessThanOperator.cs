using System;
using MW.Feature.FormConditions.Operators.Abstracts;
using MW.Feature.FormConditions.Operators.Interfaces;

namespace MW.Feature.FormConditions.Operators.Implementations
{
    public class IsLessThanOperator : ComparableOperatorBase, IOperator
    {
        public Guid Id => Constants.Items.Operator.IsLessThanOperator;

        protected override bool IsCompareResultMatch(int compareResult)
        {
            return compareResult < 0;
        }
    }
}
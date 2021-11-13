using System;
using MW.Feature.FormConditions.Operators.Abstracts;
using MW.Feature.FormConditions.Operators.Interfaces;

namespace MW.Feature.FormConditions.Operators.Implementations
{
    public class IsLessThanOrEqualToOperator : ComparableOperatorBase, IOperator
    {
        public Guid Id => Constants.Items.Operator.IsLessThanOrEqualTo;

        protected override bool IsCompareResultMatch(int compareResult)
        {
            return compareResult <= 0;
        }
    }
}
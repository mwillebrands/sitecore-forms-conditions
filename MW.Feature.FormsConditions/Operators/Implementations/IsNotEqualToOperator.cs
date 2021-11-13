using System;
using MW.Feature.FormConditions.Operators.Abstracts;
using MW.Feature.FormConditions.Operators.Interfaces;

namespace MW.Feature.FormConditions.Operators.Implementations
{
    public class IsNotEqualToOperator : EqualsOperatorBase, IOperator
    {
        public Guid Id => Constants.Items.Operator.IsNotEqualTo;

        protected override bool IsEqual(object fieldValue, object operatorValue)
        {
            return !Equals(fieldValue, operatorValue);
        }
    }
}
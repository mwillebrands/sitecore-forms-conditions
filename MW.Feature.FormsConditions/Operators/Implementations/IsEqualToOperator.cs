using System;
using MW.Feature.FormConditions.Operators.Abstracts;
using MW.Feature.FormConditions.Operators.Interfaces;

namespace MW.Feature.FormConditions.Operators.Implementations
{
    public class IsEqualToOperator : EqualsOperatorBase, IOperator
    {
        protected override bool ShouldMatchAllValues => true;

        public Guid Id => Constants.Items.Operator.IsEqualTo;

        protected override bool IsEqual(object fieldValue, object operatorValue)
        {
            return Equals(fieldValue, operatorValue);
        }
    }
}
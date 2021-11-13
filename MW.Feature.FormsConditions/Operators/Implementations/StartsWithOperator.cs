using System;
using MW.Feature.FormConditions.Operators.Abstracts;
using MW.Feature.FormConditions.Operators.Interfaces;

namespace MW.Feature.FormConditions.Operators.Implementations
{
    public class StartsWithOperator : StringOperatorBase, IOperator
    {
        public virtual Guid Id => Constants.Items.Operator.StartsWith;

        protected override bool IsMatch(string fieldValue, string operatorValue)
        {
            return fieldValue.StartsWith(operatorValue);
        }
    }
}
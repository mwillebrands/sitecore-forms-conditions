using System;
using MW.Feature.FormConditions.Operators.Abstracts;
using MW.Feature.FormConditions.Operators.Interfaces;

namespace MW.Feature.FormConditions.Operators.Implementations
{
    public class ContainsOperator : StringOperatorBase, IOperator
    {
        public Guid Id => Constants.Items.Operator.Contains;

        protected override bool IsMatch(string fieldValue, string operatorValue)
        {
            return fieldValue.Contains(operatorValue);
        }
    }
}
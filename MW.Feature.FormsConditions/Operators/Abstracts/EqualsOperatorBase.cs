using System;

namespace MW.Feature.FormConditions.Operators.Abstracts
{
    public abstract class EqualsOperatorBase : OperatorBase
    {
        protected override bool IsMatch(object fieldValue, object operatorValue)
        {
            var leftIsNullOrEmpty = fieldValue == null || (fieldValue is string fieldStringValue) && string.IsNullOrEmpty(fieldStringValue);
            var rightIsNullOrEmpty = operatorValue == null || (operatorValue is string operatorStringValue && string.IsNullOrEmpty(operatorStringValue));

            if (leftIsNullOrEmpty && rightIsNullOrEmpty)
            {
                return true;
            }

            if (fieldValue == null && operatorValue != null)
            {
                return false;
            }

            try
            {
                operatorValue = Convert.ChangeType(operatorValue, fieldValue.GetType());
            }
            catch (Exception) { }
            return IsEqual(fieldValue, operatorValue);
        }

        protected abstract bool IsEqual(object fieldValue, object operatorValue);
    }
}

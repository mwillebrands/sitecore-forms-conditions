using System;

namespace MW.Feature.FormConditions.Operators.Abstracts
{
    public abstract class EqualsOperatorBase : OperatorBase
    {
        protected override bool IsMatch(object fieldValue, object operatorValue)
        {
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

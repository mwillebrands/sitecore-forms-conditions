using System.Collections.Generic;
using System.Linq;

namespace MW.Feature.FormConditions.Operators.Abstracts
{
    public abstract class OperatorBase
    {
        protected virtual bool ShouldMatchAllValues => false;

        public bool IsMatch(List<object> fieldValues, object operatorValue)
        {
            if (ShouldMatchAllValues)
            {
                return fieldValues.All(x => IsMatch(x, operatorValue));
            }

            return fieldValues.Any(x => IsMatch(x, operatorValue));
        }

        protected abstract bool IsMatch(object fieldValue, object operatorValue);
    }
}
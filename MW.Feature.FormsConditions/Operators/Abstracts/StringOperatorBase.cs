namespace MW.Feature.FormConditions.Operators.Abstracts
{
    public abstract class StringOperatorBase : OperatorBase
    {
        protected override bool IsMatch(object fieldValue, object operatorValue)
        {
            return IsMatch(fieldValue?.ToString().ToLowerInvariant() ?? string.Empty, operatorValue?.ToString().ToLowerInvariant() ?? string.Empty);
        }

        protected abstract bool IsMatch(string fieldValue, string operatorValue);
    }
}
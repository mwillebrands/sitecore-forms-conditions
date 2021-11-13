using System;
using System.Collections.Generic;

namespace MW.Feature.FormConditions.Operators.Interfaces
{
    public interface IOperator
    {
        Guid Id { get; }
        bool IsMatch(List<object> fieldValues, object operatorValue);
    }
}
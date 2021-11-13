using System;

namespace MW.Feature.FormConditions.Operators.Interfaces
{
    public interface IOperatorFactory
    {
        IOperator GetOperator(Guid operatorId);
    }
}
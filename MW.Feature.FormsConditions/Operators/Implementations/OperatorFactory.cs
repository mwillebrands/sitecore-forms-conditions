using System;
using MW.Feature.FormConditions.Operators.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MW.Feature.FormConditions.Operators.Implementations
{
    public class OperatorFactory : IOperatorFactory
    {
        private readonly IServiceProvider _serviceProvider;

        public OperatorFactory(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IOperator GetOperator(Guid operatorId)
        {
            foreach (var @operator in _serviceProvider.GetServices<IOperator>())
            {
                if (@operator.Id.Equals(operatorId))
                {
                    return @operator;
                }
            }

            throw new NotImplementedException($"Could not find a registered operator for ID {operatorId}");
        }
    }
}
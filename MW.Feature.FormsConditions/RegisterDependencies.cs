using MW.Feature.FormConditions.ActionTypes;
using MW.Feature.FormConditions.Evaluators;
using MW.Feature.FormConditions.MatchTypes;
using MW.Feature.FormConditions.Operators.Implementations;
using MW.Feature.FormConditions.Operators.Interfaces;
using MW.Feature.FormConditions.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using MW.Feature.FormConditions.Abstractions;

namespace MW.Feature.FormConditions
{
    public class RegisterDependencies : IServicesConfigurator
    {
        public void Configure(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IOperator, ContainsOperator>();
            serviceCollection.AddSingleton<IOperator, DoesNotContainOperator>();
            serviceCollection.AddSingleton<IOperator, DoesNotEndWithOperator>();
            serviceCollection.AddSingleton<IOperator, DoesNotStartWithOperator>();
            serviceCollection.AddSingleton<IOperator, EndsWithOperator>();
            serviceCollection.AddSingleton<IOperator, IsEqualToOperator>();
            serviceCollection.AddSingleton<IOperator, IsGreaterThanOperator>();
            serviceCollection.AddSingleton<IOperator, IsGreaterThanOrEqualToOperator>();
            serviceCollection.AddSingleton<IOperator, IsLessThanOperator>();
            serviceCollection.AddSingleton<IOperator, IsLessThanOrEqualToOperator>();
            serviceCollection.AddSingleton<IOperator, IsNotEqualToOperator>();
            serviceCollection.AddSingleton<IOperator, StartsWithOperator>();
            serviceCollection.AddSingleton<IMatchTypeResolver, MatchTypeResolver>();
            serviceCollection.AddSingleton<IActionTypeResolver, ActionTypeResolver>();
            serviceCollection.AddSingleton<IOperatorFactory, OperatorFactory>();
            serviceCollection.AddSingleton<IFieldConditionConditionsEvaluator, FieldConditionConditionsEvaluator>();
            serviceCollection.AddSingleton<IFieldConditionsEvaluator, FieldConditionsEvaluator>();
            serviceCollection.AddSingleton<IFieldRepository, FieldRepository>();
            serviceCollection.AddSingleton<ISettingsService, SitecoreSettingsService>();
        }
    }
}
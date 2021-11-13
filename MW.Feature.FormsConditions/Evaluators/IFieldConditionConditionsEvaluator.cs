using System.Collections.Generic;
using Sitecore.ExperienceForms.Models;
using Sitecore.ExperienceForms.Mvc.Models.Conditions;

namespace MW.Feature.FormConditions.Evaluators
{
    public interface IFieldConditionConditionsEvaluator
    {
        bool IsMatch(FieldCondition fieldCondition, IList<IViewModel> fields);
    }
}
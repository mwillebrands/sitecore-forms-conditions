using System;
using System.Collections.Generic;
using Sitecore.ExperienceForms.Models;

namespace MW.Feature.FormConditions.Evaluators
{
    public interface IFieldConditionsEvaluator
    {
        Dictionary<Guid, List<Guid>> Evaluate(Guid formId, IList<IViewModel> fields);
    }
}
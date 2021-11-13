using System;
using System.Collections.Generic;
using System.Linq;
using MW.Feature.FormConditions.Repositories;
using Sitecore.ExperienceForms.Models;
using Sitecore.ExperienceForms.Mvc.Models.Conditions;
using Sitecore.ExperienceForms.Mvc.Models.Fields;

namespace MW.Feature.FormConditions.Evaluators
{
    public class FieldConditionsEvaluator : IFieldConditionsEvaluator
    {
        private readonly IFieldConditionConditionsEvaluator _fieldConditionConditionsEvaluator;
        private readonly IFieldRepository _fieldRepository;

        public FieldConditionsEvaluator(IFieldConditionConditionsEvaluator fieldConditionConditionsEvaluator, IFieldRepository fieldRepository)
        {
            _fieldConditionConditionsEvaluator = fieldConditionConditionsEvaluator;
            _fieldRepository = fieldRepository;
        }

        /// <summary>
        /// Returns a dictionary containing the Fields with their actions
        /// </summary>
        /// <param name="fields"></param>
        /// <returns></returns>
        public Dictionary<Guid, List<Guid>> Evaluate(Guid formId, IList<IViewModel> fields)
        {
            var fieldActions = new Dictionary<Guid, List<Guid>>();
            foreach (var field in fields.OfType<FieldViewModel>())
            {
                foreach (var fieldAction in EvaluateFieldConditions(formId, fields, field))
                {
                    if (!fieldActions.ContainsKey(fieldAction.Key))
                    {
                        fieldActions[fieldAction.Key] = new List<Guid>();
                    }
                    fieldActions[fieldAction.Key].Add(fieldAction.Value);
                }
            }

            return fieldActions;
        }

        private IEnumerable<KeyValuePair<Guid, Guid>> EvaluateFieldConditions(Guid formId, IList<IViewModel> fields, FieldViewModel field)
        {
            foreach (var condition in field.ConditionSettings?.FieldConditions ?? new List<FieldCondition>())
            {
                if (!_fieldConditionConditionsEvaluator.IsMatch(condition, fields))
                {
                    continue;
                }

                foreach (var action in condition.Actions)
                {
                    if (!Guid.TryParse(action.ActionTypeId, out var actionTypeId))
                    {
                        continue;
                    }

                    var affectedFieldIds = _fieldRepository.GetFieldsByFieldKey(formId, action.FieldId);
                    foreach (var affectedFieldId in affectedFieldIds)
                    {
                        yield return new KeyValuePair<Guid, Guid>(affectedFieldId, actionTypeId);
                    }
                }
            }
        }
    }
}
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using MW.Feature.FormConditions.MatchTypes;
using MW.Feature.FormConditions.Operators.Interfaces;
using Sitecore.ExperienceForms.Models;
using Sitecore.ExperienceForms.Mvc.Models.Conditions;
using Sitecore.ExperienceForms.Mvc.Models.Fields;

namespace MW.Feature.FormConditions.Evaluators
{
    public class FieldConditionConditionsEvaluator : IFieldConditionConditionsEvaluator
    {
        private readonly IMatchTypeResolver _matchTypeResolver;
        private readonly IOperatorFactory _operatorFactory;

        public FieldConditionConditionsEvaluator(IMatchTypeResolver matchTypeResolver, IOperatorFactory operatorFactory)
        {
            _matchTypeResolver = matchTypeResolver;
            _operatorFactory = operatorFactory;
        }

        public bool IsMatch(FieldCondition fieldCondition, IList<IViewModel> fields)
        {
            if (!Guid.TryParse(fieldCondition.MatchTypeId, out var matchTypeId))
            {
                return false;
            }

            if (!fieldCondition.Conditions.Any())
            {
                return false;
            }

            var matchType = _matchTypeResolver.Resolve(matchTypeId);
            return matchType == MatchType.All
                ? fieldCondition.Conditions.All(x => IsConditionMatch(x, fields))
                : fieldCondition.Conditions.Any(x => IsConditionMatch(x, fields));
        }

        private bool IsConditionMatch(Condition condition, IList<IViewModel> fields)
        {
            if (!Guid.TryParse(condition.OperatorId, out var operatorId))
            {
                return false;
            }


            var field = fields.FirstOrDefault(x => (x as FieldViewModel)?.ConditionSettings.FieldKey == condition.FieldId);
            if (field == null)
            {
                return false;
            }

            var fieldValues = GetFieldValues(field);
            return _operatorFactory.GetOperator(operatorId).IsMatch(fieldValues, condition.Value);
        }

        private List<object> GetFieldValues(IViewModel field)
        {
            var fieldValue = (field as IValueField)?.GetType().GetProperty("Value")?.GetValue(field);
            if (fieldValue is IEnumerable enumerable)
            {
                List<object> fieldValues = new List<object>();
                foreach (var val in enumerable)
                {
                    fieldValues.Add(val);
                }

                return fieldValues;
            }

            return new List<object>() { fieldValue };
        }
    }
}
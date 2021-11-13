using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using MW.Feature.FormConditions.ActionTypes;
using MW.Feature.FormConditions.Evaluators;
using Sitecore.ExperienceForms.Models;
using Sitecore.ExperienceForms.Mvc;

namespace MW.Feature.FormConditions.ModelBinders
{
    public class FormDataModelBinder : Sitecore.ExperienceForms.Mvc.Controllers.ModelBinders.FormDataModelBinder
    {
        private readonly IFieldConditionsEvaluator _fieldConditionsEvaluator;
        private readonly IActionTypeResolver _actionTypeResolver;

        public FormDataModelBinder(IFormRenderingContext formRenderingContext,
            ModelBinderDictionary modelBinders,
            IFieldConditionsEvaluator fieldConditionsEvaluator,
            IActionTypeResolver actionTypeResolver)
            : base(formRenderingContext, modelBinders)
        {
            _fieldConditionsEvaluator = fieldConditionsEvaluator;
            _actionTypeResolver = actionTypeResolver;
        }

        protected override IList<IViewModel> BindFields(ControllerContext controllerContext, ModelBindingContext bindingContext, Guid formId)
        {
            var fields = base.BindFields(controllerContext, bindingContext, formId);
            var fieldConditionResults = _fieldConditionsEvaluator.Evaluate(formId, fields);

            EmptyFieldsWhenRequired(fields, fieldConditionResults);
            DisableRequiredValidationIfRequired(fields, fieldConditionResults);

            return fields;
        }

        private void EmptyFieldsWhenRequired(IList<IViewModel> fields, Dictionary<Guid,List<Guid>> fieldConditionResults)
        {
            //Remove fields from the post that are either hidden or disabled
            var hiddenOrDisabledFields = fields.Where(x =>
                DoesFieldHaveStatus(fieldConditionResults, x, ActionType.Hide) ||
                DoesFieldHaveStatus(fieldConditionResults, x, ActionType.Disable)
            ).ToList();

            foreach (var field in hiddenOrDisabledFields.OfType<IValueField>())
            {
                var valueProperty = field.GetType().GetProperty("Value");
                if (valueProperty != null)
                {
                    valueProperty.SetValue(field, null);
                }
            }
        }

        private void DisableRequiredValidationIfRequired(IList<IViewModel> fields, Dictionary<Guid, List<Guid>> fieldConditionResults)
        {
            //Disable required validation for fields that are hidden
            foreach (var field in fields.OfType<IValueField>())
            {
                if (DoesFieldHaveStatus(fieldConditionResults, (IViewModel)field, ActionType.Hide))
                {
                    field.Required = false;
                }
            }
        }

        private bool DoesFieldHaveStatus(Dictionary<Guid, List<Guid>> fieldConditionResults, IViewModel field, ActionType status)
        {
            if (!Guid.TryParse(field.ItemId, out var itemId))
            {
                return false;
            }

            if (!fieldConditionResults.ContainsKey(itemId))
            {
                return false;
            }

            foreach (var action in fieldConditionResults[itemId])
            {
                if (_actionTypeResolver.Resolve(action) == status)
                {
                    return true;
                }
            }

            return false;
        }
    }
}

using MW.Feature.FormConditions.Abstractions;
using MW.Feature.FormConditions.ActionTypes;
using MW.Feature.FormConditions.Evaluators;
using MW.Feature.FormConditions.ModelBinders;
using Sitecore.ExperienceForms.Models;
using Sitecore.ExperienceForms.Mvc;
using Sitecore.ExperienceForms.Mvc.Models.Fields;
using Sitecore.Pipelines;

namespace MW.Feature.FormConditions.Pipelines.Initialize
{
    public class SetCustomModelBinders
    {
        private readonly IFormRenderingContext _formRenderingContext;
        private readonly IFieldConditionsEvaluator _fieldConditionsEvaluator;
        private readonly IActionTypeResolver _actionTypeResolver;
        private readonly ISettingsService _settingsService;

        public SetCustomModelBinders(IFormRenderingContext formRenderingContext,
            IFieldConditionsEvaluator fieldConditionsEvaluator,
            IActionTypeResolver actionTypeResolver,
            ISettingsService settingsService)
        {
            _formRenderingContext = formRenderingContext;
            _fieldConditionsEvaluator = fieldConditionsEvaluator;
            _actionTypeResolver = actionTypeResolver;
            _settingsService = settingsService;
        }

        public void Process(PipelineArgs args)
        {
            System.Web.Mvc.ModelBinders.Binders[typeof(FieldViewModel)] = new SecureFieldModelBinder(_settingsService);
            System.Web.Mvc.ModelBinders.Binders[typeof(FormDataModel)] = new FormDataModelBinder(_formRenderingContext,
                new SecureFieldModelBinderDictionary(),
                _fieldConditionsEvaluator,
                _actionTypeResolver);
        }
    }
}

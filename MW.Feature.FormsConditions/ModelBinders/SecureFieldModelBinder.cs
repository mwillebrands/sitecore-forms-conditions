using System.Collections.Generic;
using System.ComponentModel;
using System.Web.Mvc;
using Sitecore.ExperienceForms.Mvc.Controllers.ModelBinders;
using System.Linq;
using MW.Feature.FormConditions.Abstractions;

namespace MW.Feature.FormConditions.ModelBinders
{
    public class SecureFieldModelBinder : FieldModelBinder
    {
        private readonly List<string> _allowedFields;
        private readonly bool _enabled;

        public SecureFieldModelBinder(ISettingsService settingsService)
        {
            _allowedFields = settingsService.GetSetting("MW.Feature.FormConditions.AllowedFields")
                .Split(',')
                .Select(x => x.Trim())
                .ToList();

            if (bool.TryParse(settingsService.GetSetting("MW.Feature.FormConditions.EnableFieldWhitelisting"), out var enabled))
            {
                _enabled = enabled;
            }
        }

        protected override void BindProperty(ControllerContext controllerContext, ModelBindingContext bindingContext,
            PropertyDescriptor propertyDescriptor)
        {
            if (!_enabled || _allowedFields.Contains(propertyDescriptor.Name))
                base.BindProperty(controllerContext, bindingContext, propertyDescriptor);
        }
    }
}

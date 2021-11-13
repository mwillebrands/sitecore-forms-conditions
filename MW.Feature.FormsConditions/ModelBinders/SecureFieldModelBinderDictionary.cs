using System;
using System.Linq;
using System.Web.Mvc;
using Sitecore.ExperienceForms.Models;
using Sitecore.ExperienceForms.Mvc.Models.Fields;

namespace MW.Feature.FormConditions.ModelBinders
{
    public class SecureFieldModelBinderDictionary : ModelBinderDictionary
    {
        public override IModelBinder GetBinder(Type modelType, bool fallbackToDefault)
        {
            var modelBinder = System.Web.Mvc.ModelBinders.Binders.GetBinder(modelType, fallbackToDefault);
            return modelBinder is DefaultModelBinder && modelType.GetInterfaces().Contains(typeof(IViewModel)) ?
                System.Web.Mvc.ModelBinders.Binders[typeof(FieldViewModel)] : base.GetBinder(modelType, fallbackToDefault);
        }
    }
}

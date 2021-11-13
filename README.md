# Sitecore Forms Conditions
This library will make it possible to evaluate the conditions that can be placed on a Sitecore Form field server side. Normally this is only done client side, which makes it impossible to do proper server side validation for required fields. Furthermore, fields that are made hidden with conditions will still be posted to the server, which makes it difficult to interpret the data that is posted.

If you want to evaluate the conditions server side, all you need to do is to get an instance of the ***IFieldConditionsEvaluator*** and call the method ***Evaluate*** passing the ID of the form, and a list of the posted fields. 
This will evaluate all the conditions on the fields, and return a dictionary containg the fields for which a condition matches, and their respective actions.

### Functionality
- Set the IsRequired property to false on fields that are hidden or disabled due to conditions.
- Set the Value to null on fields that are hidden or disabled due to conditions.
- Fix the bypassing of validation and overposting fields, [blog post here](https://www.maartenwillebrands.nl/2021/07/28/sitecore-forms-bypassing-validation-and-overposting-viewmodels/).
- Expose an interface which can be used to determine what the **active** actions on a field are after evaluating the conditions.

### Limitations to posted fields
Due the the fix for bypassing validation and overposting fields, there is a limited subset to the fields that can be posted from a Sitecore Form.
The fields that are allowed are:
- Files
- ItemId
- Value
- ConfirmEmail
- ConfirmPassword

If you have any fields that you want to be able to post, edit the _MW.Feature.FormConditions.ModelBinding.config_ file, and add your own fields to the _MW.Feature.FormConditions.AllowedFields_ setting.

### Disabling functionality
If you just want to make use of the IFieldConditionsEvaluator and do not require any of the other functionality, just remove the config file named _MW.Feature.FormConditions.ModelBinding.config_.
If you want to disable the limitations for the posted fields, open the config file named _MW.Feature.FormConditions.ModelBinding.config_ and set the setting _named _MW.Feature.FormConditions.ModelBinding.config_._ to _false_.

### Examples
**Checking the status of a field within a SubmitAction**
```c#
using MW.Feature.FormConditions.ActionTypes;
using MW.Feature.FormConditions.Evaluators;
using Microsoft.Extensions.DependencyInjection;
using Sitecore.DependencyInjection;
using Sitecore.ExperienceForms.Models;
using Sitecore.ExperienceForms.Processing;
using Sitecore.ExperienceForms.Processing.Actions;
using System;

namespace MW.Feature.FormConditions
{
    public class SampleSubmitAction : SubmitActionBase<string>
    {
        private readonly IFieldConditionsEvaluator _fieldConditionsEvaluator;
        private readonly IActionTypeResolver _actionTypeResolver;

        public SampleSubmitAction(ISubmitActionData submitActionData) : base(submitActionData)
        {
            _fieldConditionsEvaluator = ServiceLocator.ServiceProvider.GetService<IFieldConditionsEvaluator>();
            _actionTypeResolver = ServiceLocator.ServiceProvider.GetService<IActionTypeResolver>();
        }

        protected override bool Execute(string data, FormSubmitContext formSubmitContext)
        {
            //The fieldConditionResults contain a KeyValuePair of Guid,List<Guid> which contains the FieldID with the guid of the actions that are active for the field.
            var fieldConditionResults = _fieldConditionsEvaluator.Evaluate(formSubmitContext.FormId, formSubmitContext.Fields);

            //This should be the ID of the field for which you want to get the active condition actions
            var fieldId = Guid.Parse("ee7fcebe-4490-11ec-81d3-0242ac130003");
            if(fieldConditionResults.ContainsKey(fieldId))
            {
                foreach(var action in fieldConditionResults[fieldId])
                {
                    //To get a easy representation of the action guid, we can use the ActionTypeResolver
                    if(_actionTypeResolver.Resolve(action) == ActionType.Hide)
                    {
                        //Do something because the field was hidden
                    }
                }
            }

            return true;
        }
    }
}
```

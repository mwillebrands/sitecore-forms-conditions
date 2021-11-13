using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Data.Managers;
using Sitecore.ExperienceForms.Mvc.Pipelines;
using System;
using System.Collections.Generic;
using System.Linq;

namespace MW.Feature.FormConditions.Repositories
{
    public class FieldRepository : IFieldRepository
    {
        private readonly IFormBuilderContext _formBuilderContext;

        public FieldRepository(IFormBuilderContext formBuilderContext)
        {
            _formBuilderContext = formBuilderContext;
        }

        public IEnumerable<Guid> GetFieldsByFieldKey(Guid formId, string fieldKey)
        {
            var formItem = _formBuilderContext.Database.GetItem(new ID(formId));
            var targetField = formItem.Axes.GetDescendants()
                .Where(x => x[Constants.Templates.ConditionSettings.Fields.FieldKey] == fieldKey)
                .FirstOrDefault();

            if (targetField == null)
            {
                yield break;
            }

            if (IsDerived(targetField, Constants.Templates.Field.TemplateId))
            {
                yield return targetField.ID.Guid;
            }

            foreach (var item in targetField.Axes.GetDescendants().Where(x => IsDerived(x, Constants.Templates.Field.TemplateId)))
            {
                yield return item.ID.Guid;
            }
        }

        private bool IsDerived(Item item, ID templateId)
        {
            if (item == null)
                return false;

            return !templateId.IsNull && IsDerived(item, item.Database.Templates[templateId]);
        }

        private bool IsDerived(Item item, Item templateItem)
        {
            if (item == null)
                return false;

            if (templateItem == null)
                return false;

            var itemTemplate = TemplateManager.GetTemplate(item);
            return itemTemplate != null && (itemTemplate.ID == templateItem.ID || itemTemplate.DescendsFrom(templateItem.ID));
        }
    }
}

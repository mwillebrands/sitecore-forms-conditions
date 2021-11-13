using System;
using System.Collections.Generic;

namespace MW.Feature.FormConditions.Repositories
{
    public interface IFieldRepository
    {
        IEnumerable<Guid> GetFieldsByFieldKey(Guid formId, string fieldKey);
    }
}
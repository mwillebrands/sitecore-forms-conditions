using System;

namespace MW.Feature.FormConditions.ActionTypes
{
    public interface IActionTypeResolver
    {
        ActionType Resolve(Guid actionTypeId);
    }
}
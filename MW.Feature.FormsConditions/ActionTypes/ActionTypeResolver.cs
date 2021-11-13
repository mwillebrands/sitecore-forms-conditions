using System;
using MW.Feature.FormConditions.Constants;

namespace MW.Feature.FormConditions.ActionTypes
{
    public class ActionTypeResolver : IActionTypeResolver
    {
        public ActionType Resolve(Guid actionTypeId)
        {
            if (actionTypeId == Items.ActionType.Show) return ActionType.Show;
            if (actionTypeId == Items.ActionType.Hide) return ActionType.Hide;
            if (actionTypeId == Items.ActionType.Enable) return ActionType.Enable;
            if (actionTypeId == Items.ActionType.Disable) return ActionType.Disable;
            if (actionTypeId == Items.ActionType.GoToPage) return ActionType.GoToPage;
            throw new NotImplementedException($"There's no action type configured for ID {actionTypeId}");
        }
    }
}
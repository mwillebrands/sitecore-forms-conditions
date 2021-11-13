using System;
using MW.Feature.FormConditions.Constants;

namespace MW.Feature.FormConditions.MatchTypes
{
    public class MatchTypeResolver : IMatchTypeResolver
    {
        public MatchType Resolve(Guid matchTypeId)
        {
            if (matchTypeId == Items.MatchType.All) return MatchType.All;
            if (matchTypeId == Items.MatchType.Any) return MatchType.Any;
            throw new NotImplementedException($"There's no match type configured for ID {matchTypeId}");
        }
    }
}
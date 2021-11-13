using System;

namespace MW.Feature.FormConditions.MatchTypes
{
    public interface IMatchTypeResolver
    {
        MatchType Resolve(Guid matchTypeId);
    }
}
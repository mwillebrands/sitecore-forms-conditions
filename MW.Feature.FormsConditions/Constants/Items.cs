using System;

namespace MW.Feature.FormConditions.Constants
{
    public struct Items
    {
        public struct ActionType
        {
            public static readonly Guid Show = new Guid("{AAE07A52-46A4-49EF-98B0-C2595BAC2382}");
            public static readonly Guid Hide = new Guid("{7F58C8DD-D7C0-4FB7-BB44-8EC6B5E1C3D9}");
            public static readonly Guid Enable = new Guid("{5744A87E-E32C-42CC-862F-96842A0202BB}");
            public static readonly Guid Disable = new Guid("{C698C993-549E-486A-A09C-BB8D830DA958}");
            public static readonly Guid GoToPage = new Guid("{4E448D57-BA06-42DC-9519-6BCD102CB332}");
        }

        public struct MatchType
        {
            public static readonly Guid All = new Guid("{4E50C172-7EA6-4989-82C3-75F24F80EF72}");
            public static readonly Guid Any = new Guid("{365C94DA-C1CD-4783-A91D-0D17A16C7117}");
        }

        public struct Operator
        {
            public static readonly Guid Contains = new Guid("{BF8935A6-1976-43A0-ABA5-D0BC128A76EA}");
            public static readonly Guid DoesNotContain = new Guid("{45AAB0FB-775B-40F5-B3B8-7CAE3ABBF643}");
            public static readonly Guid DoesNotEndWith = new Guid("{F3AC7A1A-3458-4385-BB65-860315313DB3}");
            public static readonly Guid DoesNotStartWith = new Guid("{6B92597D-F2E0-47D3-A40D-59AFB37EEDE5}");
            public static readonly Guid EndsWith = new Guid("{D375ED5B-E156-4A2B-9F91-DFD5B03F0D78}");
            public static readonly Guid IsEqualTo = new Guid("{1D38B217-A2EE-4E7B-B6ED-13E751462FEB}");
            public static readonly Guid IsGreaterThan = new Guid("{61FF63A0-375C-47BD-9986-1F81BD12BBBB}");
            public static readonly Guid IsGreaterThanOrEqualTo = new Guid("{062C6ED9-EA6E-4A88-AE54-C88E2147971D}");
            public static readonly Guid IsLessThanOperator = new Guid("{8FE41E53-AD87-4D24-B50F-EA0F6BDF739F}");
            public static readonly Guid IsLessThanOrEqualTo = new Guid("{88AC1C6B-BAFE-40A7-BB75-E304C8EC29DD}");
            public static readonly Guid IsNotEqualTo = new Guid("{49F47E77-E8C5-46F9-BF39-78D6B0D40B48}");
            public static readonly Guid StartsWith = new Guid("{FD10F291-3C2E-4AE7-8A67-2F8271CB3DF2}");
        }
    }
}
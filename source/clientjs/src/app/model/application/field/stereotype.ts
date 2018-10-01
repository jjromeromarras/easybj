export enum Stereotype {
        None = 0,
        Nullable = 512,

        String = 1,
        ListString = 257,

        Integer = 2,
        ListInteger = 258,
        NullableInteger = 514,

        Decimal = 4,
        ListDecimal = 260,
        NullableDecimal = 516,

        Date = 8,
        ListDate = 264,
        NullableDate = 520,
        Time = 16,
        ListTime = 272,
        NullableTime = 528,
        DateTime = 24,
        ListDateTime = 280,
        NullableDateTime = 536,

        Guid = 32,
        ListGuid = 288,
        NullableGuid = 544,

        Boolean = 64,
        ListBoolean = 320,
        NullableBoolean = 576,

        Record = 128,
        List = 256,
        ObjectDictionary = 1024,
    }
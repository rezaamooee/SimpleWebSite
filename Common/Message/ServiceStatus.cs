namespace Common.Messages
{
    public enum ServiceStatus
    {
        OK = 0,
        HasError = 1,
        HasDbError = 2,

        ModelIsValid = 100,
        HasModelValidationError = 101,
        HasModelUnhandeledError = 102,




        DbAddWithError = 200,
        HasDbReadError = 201,
        HasDbNotRequiredRow = 202,
        DbDuplicatedRow = 203,
        DbHasSameRow = 204,
        RecordNotFound = 205,
        DBSuccessfullAddRecord = 206,

        HasLogicalError = 400,
        HasTryCatchError = 401,
        BadParameter = 402,


        SuccessfulAuthentication = 500,
        FailedAuthentication = 501,


        Authorized = 600,
        UnAuthorized = 601,


        IpBaned = 1000,
        UserBaned = 1001

    }
}

namespace Domain.Utilities.Enums
{
    public enum State
    {
        NotDeleted,
        Deleted
    }
    public enum StatusEnum
    {
        FailedToSave,
        SavedSuccessfully,
        Exception,
        Success,
        Failed,
        FailedToFindTheObject,
        AlreadyExisting
    }
    public enum UserGender
    {
        Male,
        Female
    }
    public enum RiskFilter
    {
        All,
        IdentifyRisk,
        InherentRisk,
        RegulatoryControl,
        RemainRisk,
        ProcessingPlan
    }
    public enum RiskStatus
    {
        Both = 1,
        Internal = 2,
        External = 3
    }

    public enum RiskUserType
    {
        Ambassador = 1,
        Owner = 2,
        Responsible = 3
    }
    public enum RequestStatus
    {
        Pending,
        Approved,
        Rejected,
        RequireEdit,
        Redirected,
        Cancel,
        ExceptionApprove
    }

    public enum RiskRequest
    {
        IdentifyRisk,
        InherentRisk,
        RegulatoryControl,
        RemainRisk,
        ProcessingPlan
    }

    public enum ServiceType
    {
        All = 1,
        RequestService = 2,
        ReportService = 3,
        Committee = 4,
        Pmo_Chnages = 5,
        Pmo_CloseProject = 6,
        Pmo_FeasabilityStudyRequest = 7,
        Pmo_HoldRequest = 8,
        Pmo_CancelRequest = 9,
        Pmo_BidRequest = 10,
        AvaliableCoureses = 11,
        UnavaliableCoureses = 12,
        IdentifyRisk = 13,
        InherentRisk = 14,
        RegulatoryControl = 15,
        RemainRisk = 16,
        ProcessingPlan = 17
    }
}
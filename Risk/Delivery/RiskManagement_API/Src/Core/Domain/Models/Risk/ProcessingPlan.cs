using _4EPlatform.Domain.CustomValidationInjection;
using _4EPlatform.Domain.Models.RiskDynamicWorkFlowCycle;
using Domain.Utilities.Enums;

namespace _4EPlatform.Domain.Models
{
    public class ProcessingPlan : AuditEntity<Guid>
    {
        //خطة المعالجة
        public Guid IdentifyRiskId { get; set; }
        public virtual IdentifyRisk IdentifyRisk { get; set; }
        public Guid TypeTreatmentPlanId { get; set; }
        public virtual TypeTreatmentPlan TypeTreatmentPlan { get; set; }
        public Guid UserId { get; set; }
        public DateTime DateEndPlan { get; set; }

        [PreventInjection]
        public string? Description { get; set; }
        public Guid? ImplementationStatusId { get; set; }
        public virtual ImplementationStatus? ImplementationStatus { get; set; }
        [PreventInjection]
        public string? Notes { get; set; }

        public Guid? RequestInstanceId { get; set; }
        public RequestStatus? RequestStatus { get; set; }
        public Guid? ReportId { get; set; }
        public virtual RiskApproveCycle? RiskApproveCycle { get; set; }
        public Guid? RiskApproveCycleId { get; set; }

    }
}

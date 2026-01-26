using _4EPlatform.Domain.CustomValidationInjection;
using _4EPlatform.Domain.Models.Risk;
using _4EPlatform.Domain.Models.RiskDynamicWorkFlowCycle;
using _4EPlatform.Domain.Models.RiskTemp;
using Domain.Utilities.Enums;

namespace _4EPlatform.Domain.Models
{
    public class IdentifyRisk : AuditEntity<Guid>
    {
        //تحديد الخطر
        [PreventInjection]
        public string Title { get; set; }
        [PreventInjection]
        public string Description { get; set; }
        [PreventInjection]
        public string Reason { get; set; }//الاسباب
        [PreventInjection]
        public string Effects { get; set; }
        public bool? IsCompleted { get; set; } = false;
        public DateTime IdentifyRiskDate { get; set; }
        public RiskStatus RiskStatus { get; set; }
        public Guid SubCateoryId { get; set; }
        public virtual SubCateory SubCateory { get; set; }
        public Guid OrgId { get; set; }
        public Guid AmbassadorUserId { get; set; }
        public Guid OwnerUserId { get; set; }
        public Guid ResponsibleUserId { get; set; }
        public int LkRiskTypeId { get; set; }
        public virtual LkRiskType LkRiskType { get; set; }
        //public bool IsArchive { get; set; } = false;
        public Guid? RequestInstanceId { get; set; }
        public RequestStatus? RequestStatus { get; set; }
        public Guid? ReportId { get; set; }
        public virtual RiskApproveCycle? RiskApproveCycle { get; set; }
        public Guid? RiskApproveCycleId { get; set; }
        public virtual ICollection<InherentRisk> InherentRisks { get; set; } = new HashSet<InherentRisk>();
        public virtual ICollection<RegulatoryControl> RegulatoryControls { get; set; } = new HashSet<RegulatoryControl>();
        public virtual ICollection<RemainRisk> RemainRisks { get; set; } = new HashSet<RemainRisk>();
        public virtual ICollection<ProcessingPlan> ProcessingPlans { get; set; } = new HashSet<ProcessingPlan>();
        public virtual ICollection<RiskHistory> RiskHistories { get; set; } = new HashSet<RiskHistory>();
        public virtual ICollection<RiskCustomApprovalCycle> RiskCustomApprovalCycles { get; set; } = new HashSet<RiskCustomApprovalCycle>();
        public virtual ICollection<InherentRiskTemp> InherentRiskTemps { get; set; } = new HashSet<InherentRiskTemp>();
        public virtual ICollection<IdentifyRiskTemp> IdentifyRiskTemps { get; set; } = new HashSet<IdentifyRiskTemp>();
        public virtual ICollection<ProcessingPlanTemp> ProcessingPlanTemps { get; set; } = new HashSet<ProcessingPlanTemp>();
        public virtual ICollection<RegulatoryControlTemp> RegulatoryControlTemps { get; set; } = new HashSet<RegulatoryControlTemp>();
        public virtual ICollection<RemainRiskTemp> RemainRiskTemps { get; set; } = new HashSet<RemainRiskTemp>();


    }
}

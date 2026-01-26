using _4EPlatform.Domain.CustomValidationInjection;
using _4EPlatform.Domain.Models.Risk;
using _4EPlatform.Domain.Models.RiskDynamicWorkFlowCycle;
using Domain.Utilities.Enums;

namespace _4EPlatform.Domain.Models.RiskTemp
{
    public class IdentifyRiskTemp : AuditEntity<Guid>
    {
        public virtual IdentifyRisk IdentifyRisk { get; set; }
        public Guid IdentifyRiskId { get; set; }
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

        public Guid? RequestInstanceId { get; set; }
        public Guid? ReportId { get; set; }
        public Guid? RiskApproveCycleId { get; set; }

        //public bool IsArchive { get; set; } = false;
    }
}

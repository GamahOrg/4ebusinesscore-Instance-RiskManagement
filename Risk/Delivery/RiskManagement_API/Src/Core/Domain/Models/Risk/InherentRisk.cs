using _4EPlatform.Domain.Models.RiskDynamicWorkFlowCycle;
using Domain.Utilities.Enums;

namespace _4EPlatform.Domain.Models
{
    public class InherentRisk : AuditEntity<Guid>
    {
        //تقييم الخطر المتاصل
        public Guid IdentifyRiskId { get; set; }
        public virtual IdentifyRisk IdentifyRisk { get; set; }
        public Guid ImpactId { get; set; } //تقييم الاحتمالية
        public virtual Impact Impact { get; set; }
        public Guid ProbabilityOfOccurrenceId { get; set; } //تقييم الاثر
        public virtual ProbabilityOfOccurrence ProbabilityOfOccurrence { get; set; }
        public Guid RiskCriteriaId { get; set; } //درجة الخطر المتاصل
        public virtual RiskCriteria RiskCriteria { get; set; }
        public int InherentRiskResult { get; set; }
        public RequestStatus? RequestStatus { get; set; }
        public virtual RiskApproveCycle? RiskApproveCycle { get; set; }
        public Guid? RequestInstanceId { get; set; }
        public Guid? ReportId { get; set; }
        public Guid? RiskApproveCycleId { get; set; }

    }
}

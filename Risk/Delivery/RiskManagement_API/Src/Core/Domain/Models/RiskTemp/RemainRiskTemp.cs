using _4EPlatform.Domain.Models.RiskDynamicWorkFlowCycle;

namespace _4EPlatform.Domain.Models.RiskTemp
{
    public class RemainRiskTemp : AuditEntity<Guid>
    {
        //تقييم الخطر المتبقى
        public Guid IdentifyRiskId { get; set; }
        public virtual IdentifyRisk IdentifyRisk { get; set; }
        public Guid ImpactId { get; set; } //تقييم الاحتمالية
        public virtual Impact Impact { get; set; }
        public Guid ProbabilityOfOccurrenceId { get; set; } //تقييم الاثر
        public virtual ProbabilityOfOccurrence ProbabilityOfOccurrence { get; set; }
        public Guid RiskCriteriaId { get; set; } //درجة الخطر المتبقى
        public virtual RiskCriteria RiskCriteria { get; set; }
        public int RemainRiskResult { get; set; }
        public Guid? RequestInstanceId { get; set; }
        public Guid? ReportId { get; set; }
        public Guid? RiskApproveCycleId { get; set; }


    }
}

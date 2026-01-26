using _4EPlatform.Domain.CustomValidationInjection;
using _4EPlatform.Domain.Models.RiskDynamicWorkFlowCycle;

namespace _4EPlatform.Domain.Models.RiskTemp
{
    public class RegulatoryControlTemp : AuditEntity<Guid>
    {
        //الضوابط الرقابية وتقييم فاعليتها
        public Guid IdentifyRiskId { get; set; }
        public virtual IdentifyRisk IdentifyRisk { get; set; }
        public Guid ControlId { get; set; } //طبيعة الضابط
        public virtual Control Control { get; set; }
        public Guid ProbabilityOfEffectivenesId { get; set; } //تقييم فعالية الضابط الرقابى الاحتمالية
        public virtual ProbabilityOfEffectivenes ProbabilityOfEffectivenes { get; set; }
        public Guid EffectOfTheEventId { get; set; } //تقييم فعالية الضابط الرقابى الاثر
        public virtual EffectOfTheEvent EffectOfTheEvent { get; set; }
        [PreventInjection]
        public string AppliedRegulatoryControls { get; set; }
        public Guid? RequestInstanceId { get; set; }
        public Guid? ReportId { get; set; }
        public Guid? RiskApproveCycleId { get; set; }


    }
}

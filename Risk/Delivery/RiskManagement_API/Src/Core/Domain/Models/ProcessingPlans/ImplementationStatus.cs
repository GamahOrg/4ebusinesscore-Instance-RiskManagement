using _4EPlatform.Domain.CustomValidationInjection;
using _4EPlatform.Domain.Models.RiskTemp;

namespace _4EPlatform.Domain.Models
{
    public class ImplementationStatus : AuditEntity<Guid>
    {
        //حالة التنفيذ
        [PreventInjectionScriptAttribute]
        [PreventInjectionHTMLAttribute]
        [PreventInjectionCSVAttribute]
        public string NameAr { get; set; }
        [PreventInjectionScriptAttribute]
        [PreventInjectionHTMLAttribute]
        [PreventInjectionCSVAttribute]
        public string NameEn { get; set; }
        public virtual ICollection<ProcessingPlan> ProcessingPlans { get; set; } = new HashSet<ProcessingPlan>();
        public virtual ICollection<ProcessingPlanTemp> ProcessingPlanTemps { get; set; } = new HashSet<ProcessingPlanTemp>();
    }
}

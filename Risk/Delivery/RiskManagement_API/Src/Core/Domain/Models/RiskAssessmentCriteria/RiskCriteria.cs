using _4EPlatform.Domain.CustomValidationInjection;
using _4EPlatform.Domain.Models.RiskTemp;

namespace _4EPlatform.Domain.Models
{
    public class RiskCriteria : AuditEntity<Guid>
    {

        //معايير الخطر
        [PreventInjectionScriptAttribute]
        [PreventInjectionHTMLAttribute]
        [PreventInjectionCSVAttribute]
        public string NameAr { get; set; }
        [PreventInjectionScriptAttribute]
        [PreventInjectionHTMLAttribute]
        [PreventInjectionCSVAttribute]
        public string NameEn { get; set; }
        public int FromNumber { get; set; }
        public int ToNumber { get; set; }
        [PreventInjectionScriptAttribute]
        [PreventInjectionHTMLAttribute]
        [PreventInjectionCSVAttribute]
        public string CriteriaColor { get; set; }
        public virtual ICollection<InherentRisk> InherentRisks { get; set; } = new HashSet<InherentRisk>();
        public virtual ICollection<RemainRisk> RemainRisks { get; set; } = new HashSet<RemainRisk>();
        public virtual ICollection<InherentRiskTemp> InherentRiskTemps { get; set; } = new HashSet<InherentRiskTemp>();
        public virtual ICollection<RemainRiskTemp> RemainRiskTemps { get; set; } = new HashSet<RemainRiskTemp>();
    }
}

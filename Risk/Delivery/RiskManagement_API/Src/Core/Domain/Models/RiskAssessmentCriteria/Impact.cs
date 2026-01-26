using _4EPlatform.Domain.CustomValidationInjection;
using _4EPlatform.Domain.Models.RiskTemp;

namespace _4EPlatform.Domain.Models
{
    public class Impact : AuditEntity<Guid>
    {
        //الاثر
        [PreventInjectionScriptAttribute]
        [PreventInjectionHTMLAttribute]
        [PreventInjectionCSVAttribute]
        public string NameAr { get; set; }
        [PreventInjectionScriptAttribute]
        [PreventInjectionHTMLAttribute]
        [PreventInjectionCSVAttribute]
        public string NameEn { get; set; }
        public int ImpactNumber { get; set; }
        [PreventInjectionScriptAttribute]
        [PreventInjectionHTMLAttribute]
        [PreventInjectionCSVAttribute]
        public string ImpactColor { get; set; }
        public virtual ICollection<InherentRisk> InherentRisks { get; set; } = new HashSet<InherentRisk>();
        public virtual ICollection<RemainRisk> RemainRisks { get; set; } = new HashSet<RemainRisk>();
        public virtual ICollection<InherentRiskTemp> InherentRiskTemps { get; set; } = new HashSet<InherentRiskTemp>();
        public virtual ICollection<RemainRiskTemp> RemainRiskTemps { get; set; } = new HashSet<RemainRiskTemp>();

    }
}

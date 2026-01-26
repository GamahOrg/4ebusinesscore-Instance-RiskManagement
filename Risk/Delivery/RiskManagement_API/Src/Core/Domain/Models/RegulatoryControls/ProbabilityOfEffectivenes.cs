using _4EPlatform.Domain.CustomValidationInjection;
using _4EPlatform.Domain.Models.RiskTemp;

namespace _4EPlatform.Domain.Models
{
    public class ProbabilityOfEffectivenes : AuditEntity<Guid>
    {
        //احتمالية الفعالية
        [PreventInjection]
        public string NameAr { get; set; }
        [PreventInjection]
        public string NameEn { get; set; }
        public int ImpactNumber { get; set; }
        [PreventInjection]
        public string EffectColor { get; set; }
        public virtual ICollection<RegulatoryControl> RegulatoryControls { get; set; } = new HashSet<RegulatoryControl>();
        public virtual ICollection<RegulatoryControlTemp> RegulatoryControlTemps { get; set; } = new HashSet<RegulatoryControlTemp>();
    }
}

using _4EPlatform.Domain.CustomValidationInjection;
using _4EPlatform.Domain.Models.RiskTemp;

namespace _4EPlatform.Domain.Models
{
    public class Control : AuditEntity<Guid>
    {
        //الضوابط 
        [PreventInjection]
        public string NameAr { get; set; }
        [PreventInjection]
        public string NameEn { get; set; }
        [PreventInjection]
        public string AppliedControlsAr { get; set; }
        [PreventInjection]
        public string AppliedControlsEr { get; set; }

        public virtual ICollection<RegulatoryControl> RegulatoryControls { get; set; } = new HashSet<RegulatoryControl>();
        public virtual ICollection<RegulatoryControlTemp> RegulatoryControlTemps { get; set; } = new HashSet<RegulatoryControlTemp>();
    }
}

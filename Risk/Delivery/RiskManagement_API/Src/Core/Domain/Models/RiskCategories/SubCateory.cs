using _4EPlatform.Domain.CustomValidationInjection;
using _4EPlatform.Domain.Models.RiskTemp;

namespace _4EPlatform.Domain.Models
{
    public class SubCateory : AuditEntity<Guid>
    {
        [PreventInjection]

        public string NameAr { get; set; }
        [PreventInjection]

        public string NameEn { get; set; }
        public Guid CateoryId { get; set; }
        public virtual Cateory Cateory { get; set; }
        public virtual ICollection<IdentifyRisk> IdentifyRisks { get; set; } = new HashSet<IdentifyRisk>();
        public virtual ICollection<IdentifyRiskTemp> IdentifyRiskTemps { get; set; } = new HashSet<IdentifyRiskTemp>();
    }
}

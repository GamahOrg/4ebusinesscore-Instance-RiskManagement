using _4EPlatform.Domain.Models.RiskTemp;

namespace _4EPlatform.Domain.Models
{
    public class LkRiskType : AuditEntity<int>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public virtual ICollection<IdentifyRisk> IdentifyRisks { get; set; } = new HashSet<IdentifyRisk>();
        public virtual ICollection<IdentifyRiskTemp> IdentifyRiskTemps { get; set; } = new HashSet<IdentifyRiskTemp>();
    }
}

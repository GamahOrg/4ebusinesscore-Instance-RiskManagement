using _4EPlatform.Domain.Models.AmbassadorsAndRiskOwners;
using Domain.Utilities.Enums;

namespace _4EPlatform.Domain.Models
{
    public class RiskUser : AuditEntity<Guid>
    {
        public Guid UserId { get; set; }
        public RiskUserType RiskUserType { get; set; }
        public virtual ICollection<UserRiskOrg> UserRiskOrgs { get; set; } = new HashSet<UserRiskOrg>();

    }
}

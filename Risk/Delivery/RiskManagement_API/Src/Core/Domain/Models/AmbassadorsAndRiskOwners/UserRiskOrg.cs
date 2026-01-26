using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4EPlatform.Domain.Models.AmbassadorsAndRiskOwners
{
    public class UserRiskOrg : AuditEntity<Guid>
    {
        public Guid OrgId { get; set; }
        public Guid RiskUserId { get; set; }
        public virtual RiskUser RiskUser { get; set; }
    }
}

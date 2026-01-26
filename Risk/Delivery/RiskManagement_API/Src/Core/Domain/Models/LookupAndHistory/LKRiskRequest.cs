using _4EPlatform.Domain.Models.Risk;
using _4EPlatform.Domain.Models.RiskDynamicWorkFlowCycle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4EPlatform.Domain.Models.LookupAndHistory
{
    public class LKRiskRequest: AuditEntity<int>
    {
        public string NameAr { get; set; }
        public string NameEn { get; set; }
        public bool FromSeed { get; set; } = false;
        public virtual ICollection<RiskApproveCycle> RiskApproveCycles { get; set; } = new HashSet<RiskApproveCycle>();
        public virtual ICollection<RiskCustomApprovalCycle> RiskCustomApprovalCycles { get; set; } = new HashSet<RiskCustomApprovalCycle>();

    }
}

using _4EPlatform.Domain.Models.LookupAndHistory;
using _4EPlatform.Domain.Models.RiskDynamicWorkFlowCycle;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4EPlatform.Domain.Models.Risk
{
    public class RiskCustomApprovalCycle : AuditEntity<Guid>
    {
        public virtual IdentifyRisk IdentifyRisk { get; set; }
        public Guid IdentifyRiskId { get; set; }
        public virtual LKRiskRequest LKRiskRequest { get; set; }
        public int LKRiskRequestId { get; set; }
        public virtual RiskApproveCycle RiskApproveCycle { get; set; }
        public Guid RiskApproveCycleId { get; set; }

    }
}

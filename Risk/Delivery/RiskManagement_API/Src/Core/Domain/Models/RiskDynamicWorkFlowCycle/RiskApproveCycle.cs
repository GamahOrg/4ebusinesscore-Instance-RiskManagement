using _4EPlatform.Domain.Models.LookupAndHistory;
using _4EPlatform.Domain.Models.Risk;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace _4EPlatform.Domain.Models.RiskDynamicWorkFlowCycle
{
    public class RiskApproveCycle :AuditEntity<Guid>
    {
        public Guid ItemId { get; set; }
        public Guid MainClassificationId { get; set; }
        public Guid ServiceCatalogId { get; set; }
        public Guid CategoryId { get; set; }
        public string ItemName { get; set; }
        public string Name { get; set; }
        public bool IsNeeded { get; set; }
        public bool IsVisabled { get; set; }
        public  virtual LKRiskRequest? LKRiskRequest { get; set; }
        public int? LKRiskRequestId { get; set; }
        public virtual ICollection<InherentRisk> InherentRisks { get; set; } = new HashSet<InherentRisk>();
        public virtual ICollection<IdentifyRisk> IdentifyRisks { get; set; } = new HashSet<IdentifyRisk>();
        public virtual ICollection<RemainRisk> RemainRisks { get; set; } = new HashSet<RemainRisk>();
        public virtual ICollection<ProcessingPlan> ProcessingPlans { get; set; } = new HashSet<ProcessingPlan>();
        public virtual ICollection<RegulatoryControl> RegulatoryControls { get; set; } = new HashSet<RegulatoryControl>();
        public virtual ICollection<RiskCustomApprovalCycle> RiskCustomApprovalCycles { get; set; } = new HashSet<RiskCustomApprovalCycle>();

    }
}

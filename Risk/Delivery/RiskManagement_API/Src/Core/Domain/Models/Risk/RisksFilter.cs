using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4EPlatform.Domain.Models.Risk
{
    public class RisksFilter : AuditEntity<Guid>
    {
        public Guid UserId { get; set; }
        public bool AmbassadorOfDanger { get; set; }
        public bool Approvals { get; set; }
        public bool DangerAddress { get; set; }
        public bool DangerSymbol { get; set; }
        public bool DateOfDiscovery { get; set; }
        public bool InherentRiskLevel { get; set; }
        public bool MainCategory { get; set; }
        public bool OriginOfDanger { get; set; }
        public bool OwnerOfTheRisk { get; set; }
        public bool PlanExpiryDate { get; set; }
        public bool Procedures { get; set; }
        public bool ResidualRiskScore { get; set; }
        public bool SectorManagement { get; set; }
        public bool SubcategoryRisk { get; set; }
        public bool TreatmentPlanOwner { get; set; }
        public bool TreatmentPlanStatus { get; set; }
        public bool TreatmentPlanType { get; set; }
        public bool StepName { get; set; }
        public bool RequestStatus { get; set; }


    }

}

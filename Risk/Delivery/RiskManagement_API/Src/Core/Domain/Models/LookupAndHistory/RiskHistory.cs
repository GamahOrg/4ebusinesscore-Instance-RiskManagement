namespace _4EPlatform.Domain.Models
{
    public class RiskHistory : AuditEntity<Guid>
    {
        public Guid RecordId { get; set; }
        public Guid? IdentifyRiskId { get; set; }
        public virtual IdentifyRisk IdentifyRisk { get; set; }
        public string TableName { get; set; }
        public string Action { get; set; }
        public string? OldValue { get; set; }
        public string? NewValue { get; set; }
        public Guid? RequestInstanceId { get; set; }

    }
}

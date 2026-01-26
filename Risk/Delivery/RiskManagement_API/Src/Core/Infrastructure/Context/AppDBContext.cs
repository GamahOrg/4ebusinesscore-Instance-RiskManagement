using _4EPlatform.Domain.Models.AmbassadorsAndRiskOwners;
using _4EPlatform.Domain.Models.LookupAndHistory;
using _4EPlatform.Domain.Models.Risk;
using _4EPlatform.Domain.Models.RiskDynamicWorkFlowCycle;
using _4EPlatform.Domain.Models.RiskTemp;

namespace Infrastrucure.Context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options)
        {
        }
        public virtual DbSet<RiskUser> RiskUsers { get; set; }
        public virtual DbSet<UserRiskOrg> UserRiskOrgs { get; set; }
        public virtual DbSet<RisksFilter> RisksFilter { get; set; }
        public virtual DbSet<LkRiskType> LkRiskTypes { get; set; }
        public virtual DbSet<RiskHistory> RiskHistories { get; set; }
        public virtual DbSet<ImplementationStatus> ImplementationStatuses { get; set; }
        public virtual DbSet<TypeTreatmentPlan> TypeTreatmentPlans { get; set; }
        public virtual DbSet<Control> Controls { get; set; }
        public virtual DbSet<EffectOfTheEvent> EffectOfTheEvents { get; set; }
        public virtual DbSet<ProbabilityOfEffectivenes> ProbabilityOfEffectivenes { get; set; }
        public virtual DbSet<IdentifyRisk> IdentifyRisks { get; set; }
        public virtual DbSet<InherentRisk> InherentRisks { get; set; }
        public virtual DbSet<ProcessingPlan> ProcessingPlans { get; set; }
        public virtual DbSet<RegulatoryControl> RegulatoryControls { get; set; }
        public virtual DbSet<RemainRisk> RemainRisks { get; set; }
        public virtual DbSet<Impact> Impacts { get; set; }
        public virtual DbSet<ProbabilityOfOccurrence> ProbabilityOfOccurrences { get; set; }
        public virtual DbSet<RiskCriteria> RiskCriterias { get; set; }
        public virtual DbSet<Cateory> Cateories { get; set; }
        public virtual DbSet<SubCateory> SubCateories { get; set; }
        public virtual DbSet<RiskApproveCycle> RiskApproveCycles { get; set; }
        public virtual DbSet<RiskCustomApprovalCycle> RiskCustomApprovalCycles { get; set; }
        public virtual DbSet<LKRiskRequest> LKRiskRequests { get; set; }
        public virtual DbSet<IdentifyRiskTemp> IdentifyRiskTemps { get; set; }
        public virtual DbSet<InherentRiskTemp> InherentRiskTemps { get; set; }
        public virtual DbSet<ProcessingPlanTemp> ProcessingPlanTemps { get; set; }
        public virtual DbSet<RegulatoryControlTemp> RegulatoryControlTemps { get; set; }
        public virtual DbSet<RemainRiskTemp> RemainRiskTemps { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentifyRiskTemp>()
                .HasOne(x => x.LkRiskType)
                .WithMany(y => y.IdentifyRiskTemps)
                .HasForeignKey(x => x.LkRiskTypeId)
                .OnDelete(DeleteBehavior.Restrict);
            modelBuilder.Entity<IdentifyRiskTemp>()
                .HasOne(x => x.SubCateory)
                .WithMany(y => y.IdentifyRiskTemps)
                .HasForeignKey(x => x.SubCateoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InherentRiskTemp>()
                .HasOne(x => x.Impact)
                .WithMany(y => y.InherentRiskTemps)
                .HasForeignKey(x => x.ImpactId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InherentRiskTemp>()
                .HasOne(x => x.ProbabilityOfOccurrence)
                .WithMany(y => y.InherentRiskTemps)
                .HasForeignKey(x => x.ProbabilityOfOccurrenceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<InherentRiskTemp>()
                .HasOne(x => x.RiskCriteria)
                .WithMany(y => y.InherentRiskTemps)
                .HasForeignKey(x => x.RiskCriteriaId)
                .OnDelete(DeleteBehavior.Restrict);


            modelBuilder.Entity<RemainRiskTemp>()
                .HasOne(x => x.Impact)
                .WithMany(y => y.RemainRiskTemps)
                .HasForeignKey(x => x.ImpactId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RemainRiskTemp>()
                .HasOne(x => x.ProbabilityOfOccurrence)
                .WithMany(y => y.RemainRiskTemps)
                .HasForeignKey(x => x.ProbabilityOfOccurrenceId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RemainRiskTemp>()
                .HasOne(x => x.RiskCriteria)
                .WithMany(y => y.RemainRiskTemps)
                .HasForeignKey(x => x.RiskCriteriaId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProcessingPlanTemp>()
                .HasOne(x => x.ImplementationStatus)
                .WithMany(y => y.ProcessingPlanTemps)
                .HasForeignKey(x => x.ImplementationStatusId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ProcessingPlanTemp>()
                .HasOne(x => x.TypeTreatmentPlan)
                .WithMany(y => y.ProcessingPlanTemps)
                .HasForeignKey(x => x.TypeTreatmentPlanId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RegulatoryControlTemp>()
                .HasOne(x => x.Control)
                .WithMany(y => y.RegulatoryControlTemps)
                .HasForeignKey(x => x.ControlId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RegulatoryControlTemp>()
                .HasOne(x => x.EffectOfTheEvent)
                .WithMany(y => y.RegulatoryControlTemps)
                .HasForeignKey(x => x.EffectOfTheEventId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<RegulatoryControlTemp>()
                .HasOne(x => x.ProbabilityOfEffectivenes)
                .WithMany(y => y.RegulatoryControlTemps)
                .HasForeignKey(x => x.ProbabilityOfEffectivenesId)
                .OnDelete(DeleteBehavior.Restrict);


            base.OnModelCreating(modelBuilder);

        }
        public bool AllMigrationsApplied()
        {
            var applied = this.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var total = this.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !total.Except(applied).Any();
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }
        public void Migrate()
        {
            this.Database.Migrate();
        }
    }
}

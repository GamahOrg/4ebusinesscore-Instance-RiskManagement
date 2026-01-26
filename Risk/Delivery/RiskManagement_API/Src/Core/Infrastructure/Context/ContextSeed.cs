using _4EPlatform.Domain.Models;
using _4EPlatform.Domain.Models.AmbassadorsAndRiskOwners;
using _4EPlatform.Domain.Models.LookupAndHistory;
using _4EPlatform.Domain.Models.Risk;
using _4EPlatform.Domain.Models.RiskDynamicWorkFlowCycle;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
namespace Infrastrucure.Context
{
    public static class ContextSeed
    {
        private static AppDBContext _dbContext;
        private static IServiceProvider _serviceProvider;
        private static IConfiguration _configuration;

        public static void Seed(AppDBContext dbContext, IServiceProvider services, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;

            SeedEntityLK<LkRiskType>("LkRiskTypes.json", _dbContext.LkRiskTypes);
            SeedEntityLK<LKRiskRequest>("LKRiskRequestData.json", _dbContext.LKRiskRequests);

            // Fix for CS0019: Convert the string value to a boolean using bool.Parse or bool.TryParse
            if (bool.TryParse(_configuration["IsSeedData"], out var isSeedData) && isSeedData)
            {
                SeedEntity<ImplementationStatus>("ImplementationStatuses.json", _dbContext.ImplementationStatuses);
                SeedEntity<Cateory>("Cateories.json", _dbContext.Cateories);
                SeedEntity<SubCateory>("SubCateories.json", _dbContext.SubCateories);
                SeedEntity<IdentifyRisk>("IdentifyRisks.json", _dbContext.IdentifyRisks);
                SeedEntity<Impact>("Impacts.json", _dbContext.Impacts);
                SeedEntity<ProbabilityOfOccurrence>("ProbabilityOfOccurrences.json", _dbContext.ProbabilityOfOccurrences);
                SeedEntity<RiskCriteria>("RiskCriterias.json", _dbContext.RiskCriterias);
                SeedEntity<InherentRisk>("InherentRisks.json", _dbContext.InherentRisks);
                SeedEntity<Control>("Controls.json", _dbContext.Controls);
                SeedEntity<EffectOfTheEvent>("EffectOfTheEvents.json", _dbContext.EffectOfTheEvents);
                SeedEntity<ProbabilityOfEffectivenes>("ProbabilityOfEffectivenes.json", _dbContext.ProbabilityOfEffectivenes);
                SeedEntity<RegulatoryControl>("RegulatoryControls.json", _dbContext.RegulatoryControls);
                SeedEntity<RemainRisk>("RemainRisks.json", _dbContext.RemainRisks);
                SeedEntity<TypeTreatmentPlan>("TypeTreatmentPlans.json", _dbContext.TypeTreatmentPlans);
                SeedEntity<ProcessingPlan>("ProcessingPlans.json", _dbContext.ProcessingPlans);
                SeedEntity<RiskUser>("RiskUsers.json", _dbContext.RiskUsers);
                SeedEntity<UserRiskOrg>("UserRiskOrgs.json", _dbContext.UserRiskOrgs);
                SeedEntity<RiskHistory>("RiskHistories.json", _dbContext.RiskHistories);
                SeedEntity<RisksFilter>("RisksFilter.json", _dbContext.RisksFilter);
                //SeedEntity<RiskApproveCycle>("RiskApproveCycleData.json", _dbContext.RiskApproveCycles);

            }
        }

        private static void SeedEntity<T>(string fileName, DbSet<T> dbSet) where T : class
        {
            string path = Path.Combine("SeedData", fileName);
            if (!File.Exists(path)) return;

            var json = File.ReadAllText(path);

            var entities = JsonConvert.DeserializeObject<List<T>>(json);
            if (entities == null || !entities.Any()) return;

            _dbContext.Database.OpenConnection();
            try
            {

                // Get existing IDs from DB as lowercase strings for safe comparison
                var existingData = dbSet
                    .AsNoTracking().ToList();

                if (!existingData.Any())
                {

                    // Filter only new items (skip existing ones)
                    var newEntities = entities
                        .ToList();

                    // Set CreatedOn if it exists
                    foreach (var entity in newEntities)
                    {
                        var createdOnProp = typeof(T).GetProperty("CreatedOn");
                        if (createdOnProp != null &&
                            (createdOnProp.PropertyType == typeof(DateTime) || createdOnProp.PropertyType == typeof(DateTime?)))
                        {
                            createdOnProp.SetValue(entity, DateTime.Now);
                        }
                    }

                    if (newEntities.Any())
                    {
                        var tableName = typeof(T).Name;
                        var idProsp = typeof(T).GetProperty("Id");

                        // Check if Id is int or nullable int
                        bool isIntId = idProsp != null &&
                                       (idProsp.PropertyType == typeof(int) || idProsp.PropertyType == typeof(int?));

                        if (isIntId)
                        {
                            _dbContext.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [{tableName}s] ON");
                        }

                        try
                        {
                            dbSet.AddRange(newEntities);
                            _dbContext.SaveChanges();
                        }
                        catch (Exception ex)
                        {

                            if (ex != null)
                            {
                                // skip if the error is about Wrong ForienKey
                                if (ex.Message.Contains("The INSERT statement conflicted with the FOREIGN KEY constraint"))
                                {
                                    return;
                                }
                            }
                        }

                        if (isIntId)
                        {
                            _dbContext.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [{tableName}s] OFF");
                        }
                    }
                }

            }
            finally
            {
                _dbContext.Database.CloseConnection();
            }
        }

        private static void SeedEntityLK<T>(string fileName, DbSet<T> dbSet) where T : class
        {
            string path = Path.Combine("SeedData", fileName);
            if (!File.Exists(path)) return;

            var json = File.ReadAllText(path);

            var entities = JsonConvert.DeserializeObject<List<T>>(json);
            if (entities == null || !entities.Any()) return;

            _dbContext.Database.OpenConnection();
            try
            {
                var idProp = typeof(T).GetProperty("Id");
                if (idProp == null) return;

                // Get existing IDs from DB as lowercase strings for safe comparison
                var existingIds = dbSet
                    .AsNoTracking()
                    .Select(e => EF.Property<object>(e, "Id"))
                    .Where(id => id != null)
                    .Select(id => id.ToString().ToLower())
                    .ToHashSet();

                // Filter only new items (skip existing ones)
                var newEntities = entities
                    .Where(entity =>
                    {
                        var idValue = idProp.GetValue(entity);
                        return idValue != null && !existingIds.Contains(idValue.ToString().ToLower());
                    })
                    .ToList();

                // Set CreatedOn if it exists
                foreach (var entity in newEntities)
                {
                    var createdOnProp = typeof(T).GetProperty("CreatedOn");
                    if (createdOnProp != null &&
                        (createdOnProp.PropertyType == typeof(DateTime) || createdOnProp.PropertyType == typeof(DateTime?)))
                    {
                        createdOnProp.SetValue(entity, DateTime.Now);
                    }
                }

                if (newEntities.Any())
                {
                    var tableName = typeof(T).Name;
                    var idProsp = typeof(T).GetProperty("Id");

                    // Check if Id is int or nullable int
                    bool isIntId = idProsp != null &&
                                   (idProsp.PropertyType == typeof(int) || idProsp.PropertyType == typeof(int?));

                    if (isIntId)
                    {
                        _dbContext.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [{tableName}s] ON");
                    }

                    dbSet.AddRange(newEntities);
                    _dbContext.SaveChanges();

                    if (isIntId)
                    {
                        _dbContext.Database.ExecuteSqlRaw($"SET IDENTITY_INSERT [{tableName}s] OFF");
                    }
                }

            }
            finally
            {
                _dbContext.Database.CloseConnection();
            }
        }
    }

}


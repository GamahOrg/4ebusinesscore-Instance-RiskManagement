namespace _4EPlatForm.Infrastrucure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContext _context;
        private IDbContextTransaction _transaction;
        public Guid _loggedInUserId;
        public UnitOfWork(AppDBContext context, IHttpContextAccessor _httpContextAccessor)
        {
            _context = context;
            _loggedInUserId = LoggedInUserProvider.GetLoggedInUserId(_httpContextAccessor);
            repoistories = new Hashtable();

        }
        Hashtable repoistories;
        public IGRepository<TEntity> Repository<TEntity>() where TEntity : AuditEntity<Guid>
        {
            var key = typeof(TEntity).Name;
            if (!repoistories.ContainsKey(key))
            {
                var repository = new GRepository<TEntity>(_context);
                repoistories.Add(key, repository);
            }
            return repoistories[key] as IGRepository<TEntity>;


        }
        public IGRepository<TEntity> LK_Repository<TEntity>() where TEntity : AuditEntity<int>
        {
            var key = typeof(TEntity).Name;
            if (!repoistories.ContainsKey(key))
            {
                var repository = new GRepository<TEntity>(_context);
                repoistories.Add(key, repository);
            }
            return repoistories[key] as IGRepository<TEntity>;


        }
        #region Transaction
        public void BeginTransaction() => _transaction = _context.Database.BeginTransaction();
        public async Task BeginTransactionAsync() => _transaction = await _context.Database.BeginTransactionAsync();
        public void Commit() => _transaction.Commit();
        public async Task CommitAsync() => await _transaction.CommitAsync();
        public void Rollback() => _transaction?.Rollback();
        public async Task RollbackAsync() => await _transaction.RollbackAsync();

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
        public async Task DisposeAsync()
        {
            await _transaction.DisposeAsync();
            await _context.DisposeAsync();
        }
        #endregion


        #region SaveChanges
        public void SaveChanges()
        {
            try
            {
                var tablesName = new List<string>() { "IdentifyRisk", "InherentRisk", "ProcessingPlan", "RegulatoryControl", "RemainRisk" };

                var entries = _context.ChangeTracker.Entries()
                       .Where(e => (e.Entity is BaseEntity<Guid>) &&
                                   (e.State == EntityState.Added || e.State == EntityState.Modified))
                       .ToList();

                foreach (var entityEntry in entries)
                {
                    if (entityEntry.State == EntityState.Modified)
                    {
                        ((AuditEntity<Guid>)entityEntry.Entity).UpdatedOn = DateTime.Now;
                        ((AuditEntity<Guid>)entityEntry.Entity).UpdatedBy = _loggedInUserId;
                        entityEntry.Property("CreatedOn").IsModified = false;
                        entityEntry.Property("CreatedBy").IsModified = false;

                        var tableName = entityEntry.Entity.GetType().Name.Replace("Proxy", "");
                        if (tablesName.Contains(tableName))
                        {
                            if (((AuditEntity<Guid>)entityEntry.Entity).State == 0)
                            {
                                // collect changes
                                var changes = entityEntry.Properties
                                    .Where(p => p.OriginalValue?.ToString() != p.CurrentValue?.ToString())
                                    .Select(p => new { p.Metadata.Name, p.OriginalValue, p.CurrentValue })
                                    .ToList();

                                if (changes.Any()) // only log if real changes
                                {
                                    dynamic OriginalObj = new ExpandoObject();
                                    dynamic CurrentObj = new ExpandoObject();

                                    foreach (var change in changes)
                                    {
                                        AddProperty(OriginalObj, change.Name, change.OriginalValue);
                                        AddProperty(CurrentObj, change.Name, change.CurrentValue);
                                    }

                                    string jsonStringOriginal = JsonSerializer.Serialize(OriginalObj);
                                    string jsonStringCurrent = JsonSerializer.Serialize(CurrentObj);

                                    Guid riskId = GetPropertyValueAsGuid(entityEntry.Entity, "IdentifyRiskId");
                                    if (riskId == Guid.Empty)
                                        riskId = GetPropertyValueAsGuid(entityEntry.Entity, "Id");

                                    Guid requestInstanceId = GetPropertyValueAsGuid(entityEntry.Entity, "RequestInstanceId");

                                    _context.RiskHistories.Add(new _4EPlatform.Domain.Models.RiskHistory
                                    {
                                        TableName = tableName,
                                        RecordId = Guid.Parse(entityEntry.Properties.First(p => p.Metadata.IsPrimaryKey()).CurrentValue.ToString()),
                                        Action = "Update",
                                        IdentifyRiskId = riskId,
                                        OldValue = jsonStringOriginal,
                                        NewValue = jsonStringCurrent,
                                        CreatedBy = _loggedInUserId,
                                        CreatedOn = DateTime.Now,
                                        RequestInstanceId = requestInstanceId
                                    });
                                }
                            }
                            else
                            {
                                // delete logging
                                dynamic OriginalObj = new ExpandoObject();
                                foreach (var p in entityEntry.Properties.Where(p => p.OriginalValue != null))
                                    AddProperty(OriginalObj, p.Metadata.Name, p.OriginalValue);

                                string jsonStringOriginal = JsonSerializer.Serialize(OriginalObj);

                                Guid riskId = GetPropertyValueAsGuid(entityEntry.Entity, "IdentifyRiskId");
                                if (riskId == Guid.Empty)
                                    riskId = GetPropertyValueAsGuid(entityEntry.Entity, "Id");

                                Guid requestInstanceId = GetPropertyValueAsGuid(entityEntry.Entity, "RequestInstanceId");

                                _context.RiskHistories.Add(new _4EPlatform.Domain.Models.RiskHistory
                                {
                                    TableName = tableName,
                                    RecordId = Guid.Parse(entityEntry.Properties.First(p => p.Metadata.IsPrimaryKey()).CurrentValue.ToString()),
                                    Action = "Delete",
                                    IdentifyRiskId = riskId,
                                    OldValue = jsonStringOriginal,
                                    CreatedBy = _loggedInUserId,
                                    CreatedOn = DateTime.Now,
                                    RequestInstanceId = requestInstanceId
                                });
                            }
                        }
                    }

                    if (entityEntry.State == EntityState.Added)
                    {
                        ((AuditEntity<Guid>)entityEntry.Entity).CreatedOn = DateTime.Now;
                        ((AuditEntity<Guid>)entityEntry.Entity).CreatedBy = _loggedInUserId;

                        var tableName = entityEntry.Entity.GetType().Name;
                        if (tablesName.Contains(tableName))
                        {
                            dynamic CurrentObj = new ExpandoObject();
                            foreach (var p in entityEntry.Properties.Where(p => p.CurrentValue != null))
                                AddProperty(CurrentObj, p.Metadata.Name, p.CurrentValue);

                            string jsonStringCurrent = JsonSerializer.Serialize(CurrentObj);

                            Guid riskId = GetPropertyValueAsGuid(entityEntry.Entity, "IdentifyRiskId");
                            if (riskId == Guid.Empty)
                                riskId = GetPropertyValueAsGuid(entityEntry.Entity, "Id");

                            Guid requestInstanceId = GetPropertyValueAsGuid(entityEntry.Entity, "RequestInstanceId");

                            _context.RiskHistories.Add(new _4EPlatform.Domain.Models.RiskHistory
                            {
                                TableName = tableName,
                                RecordId = Guid.Parse(entityEntry.Properties.First(p => p.Metadata.IsPrimaryKey()).CurrentValue.ToString()),
                                Action = "Insert",
                                IdentifyRiskId = riskId,
                                NewValue = jsonStringCurrent,
                                CreatedBy = _loggedInUserId,
                                CreatedOn = DateTime.Now,
                                RequestInstanceId = requestInstanceId
                            });
                        }
                    }
                }

                if (_context.Database.CurrentTransaction == null)
                    BeginTransaction();

                _context.SaveChanges();
                //Commit();
            }
            catch
            {
                Rollback();
                throw;
            }
        }

        public async Task SaveChangesAsync()
        {
            try
            {
                var tablesName = new List<string>() { "IdentifyRisk", "InherentRisk", "ProcessingPlan", "RegulatoryControl", "RemainRisk" };

                var entries = _context.ChangeTracker.Entries()
                       .Where(e => (e.Entity is BaseEntity<Guid>) &&
                                   (e.State == EntityState.Added || e.State == EntityState.Modified))
                       .ToList();

                foreach (var entityEntry in entries)
                {
                    if (entityEntry.State == EntityState.Modified)
                    {
                        ((AuditEntity<Guid>)entityEntry.Entity).UpdatedOn = DateTime.Now;
                        ((AuditEntity<Guid>)entityEntry.Entity).UpdatedBy = _loggedInUserId;
                        entityEntry.Property("CreatedOn").IsModified = false;
                        entityEntry.Property("CreatedBy").IsModified = false;

                        var tableName = entityEntry.Entity.GetType().Name.Replace("Proxy", "");
                        if (tablesName.Contains(tableName))
                        {
                            if (((AuditEntity<Guid>)entityEntry.Entity).State == 0)
                            {
                                var changes = entityEntry.Properties
                                    .Where(p => p.OriginalValue?.ToString() != p.CurrentValue?.ToString())
                                    .Select(p => new { p.Metadata.Name, p.OriginalValue, p.CurrentValue })
                                    .ToList();

                                if (changes.Any())
                                {
                                    dynamic OriginalObj = new ExpandoObject();
                                    dynamic CurrentObj = new ExpandoObject();

                                    foreach (var change in changes)
                                    {
                                        AddProperty(OriginalObj, change.Name, change.OriginalValue);
                                        AddProperty(CurrentObj, change.Name, change.CurrentValue);
                                    }

                                    string jsonStringOriginal = JsonSerializer.Serialize(OriginalObj);
                                    string jsonStringCurrent = JsonSerializer.Serialize(CurrentObj);

                                    Guid riskId = GetPropertyValueAsGuid(entityEntry.Entity, "IdentifyRiskId");
                                    if (riskId == Guid.Empty)
                                        riskId = GetPropertyValueAsGuid(entityEntry.Entity, "Id");

                                    Guid requestInstanceId = GetPropertyValueAsGuid(entityEntry.Entity, "RequestInstanceId");

                                    await _context.RiskHistories.AddAsync(new _4EPlatform.Domain.Models.RiskHistory
                                    {
                                        TableName = tableName,
                                        RecordId = Guid.Parse(entityEntry.Properties.First(p => p.Metadata.IsPrimaryKey()).CurrentValue.ToString()),
                                        Action = "Update",
                                        IdentifyRiskId = riskId,
                                        OldValue = jsonStringOriginal,
                                        NewValue = jsonStringCurrent,
                                        CreatedBy = _loggedInUserId,
                                        CreatedOn = DateTime.Now,
                                        RequestInstanceId = requestInstanceId
                                    });
                                }
                            }
                            else
                            {
                                dynamic OriginalObj = new ExpandoObject();
                                foreach (var p in entityEntry.Properties.Where(p => p.OriginalValue != null))
                                    AddProperty(OriginalObj, p.Metadata.Name, p.OriginalValue);

                                string jsonStringOriginal = JsonSerializer.Serialize(OriginalObj);

                                Guid riskId = GetPropertyValueAsGuid(entityEntry.Entity, "IdentifyRiskId");
                                if (riskId == Guid.Empty)
                                    riskId = GetPropertyValueAsGuid(entityEntry.Entity, "Id");

                                Guid requestInstanceId = GetPropertyValueAsGuid(entityEntry.Entity, "RequestInstanceId");

                                await _context.RiskHistories.AddAsync(new _4EPlatform.Domain.Models.RiskHistory
                                {
                                    TableName = tableName,
                                    RecordId = Guid.Parse(entityEntry.Properties.First(p => p.Metadata.IsPrimaryKey()).CurrentValue.ToString()),
                                    Action = "Delete",
                                    IdentifyRiskId = riskId,
                                    OldValue = jsonStringOriginal,
                                    CreatedBy = _loggedInUserId,
                                    CreatedOn = DateTime.Now,
                                    RequestInstanceId = requestInstanceId
                                });
                            }
                        }
                    }

                    if (entityEntry.State == EntityState.Added)
                    {
                        ((AuditEntity<Guid>)entityEntry.Entity).CreatedOn = DateTime.Now;
                        ((AuditEntity<Guid>)entityEntry.Entity).CreatedBy = _loggedInUserId;

                        var tableName = entityEntry.Entity.GetType().Name;
                        if (tablesName.Contains(tableName))
                        {
                            dynamic CurrentObj = new ExpandoObject();
                            foreach (var p in entityEntry.Properties.Where(p => p.CurrentValue != null))
                                AddProperty(CurrentObj, p.Metadata.Name, p.CurrentValue);

                            string jsonStringCurrent = JsonSerializer.Serialize(CurrentObj);

                            Guid riskId = GetPropertyValueAsGuid(entityEntry.Entity, "IdentifyRiskId");
                            if (riskId == Guid.Empty)
                                riskId = GetPropertyValueAsGuid(entityEntry.Entity, "Id");

                            Guid requestInstanceId = GetPropertyValueAsGuid(entityEntry.Entity, "RequestInstanceId");

                            await _context.RiskHistories.AddAsync(new _4EPlatform.Domain.Models.RiskHistory
                            {
                                TableName = tableName,
                                RecordId = Guid.Parse(entityEntry.Properties.First(p => p.Metadata.IsPrimaryKey()).CurrentValue.ToString()),
                                Action = "Insert",
                                IdentifyRiskId = riskId,
                                NewValue = jsonStringCurrent,
                                CreatedBy = _loggedInUserId,
                                CreatedOn = DateTime.Now,
                                RequestInstanceId = requestInstanceId
                            });
                        }
                    }
                }

                if (_context.Database.CurrentTransaction == null)
                    await BeginTransactionAsync();

                await _context.SaveChangesAsync();
                //await CommitAsync();
            }
            catch
            {
                await RollbackAsync();
                throw;
            }
        }
        #endregion


        void AddProperty(ExpandoObject expando, string propertyName, object value)
        {
            // Cast ExpandoObject to IDictionary to add properties dynamically
            var expandoDict = (IDictionary<string, object>)expando;
            expandoDict[propertyName] = value;
        }
        private Guid GetPropertyValueAsGuid(object entity, string propertyName)
        {
            if (entity.GetType().GetProperty(propertyName) != null)
            {
                return (Guid)(entity.GetType().GetProperty(propertyName)?.GetValue(entity) ?? default(Guid));
            }
            return default(Guid);
        }
    }
}

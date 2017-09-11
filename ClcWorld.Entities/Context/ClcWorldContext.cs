using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ClcWorld.Entities.Entities;
using ClcWorld.Entities.Entities.Mapping;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

//https://www.exceptionnotfound.net/entity-change-tracking-using-dbcontext-in-entity-framework-6/
namespace ClcWorld.Entities.Context
{
    public class ClcWorldContext : DbContext, IClcWorldContext
    {
        #region [Constructor]

        public ClcWorldContext() : base("ClcWorldContext")
        {
        }

        #endregion
        
        #region [Interface]

        public Database GetDatabase => Database;
        public DbChangeTracker GetChangeTracker => ChangeTracker;

        public T EntryWithState<T>(T entity, EntityState state) where T : class
        {
            if (entity == null)
                return null;

            var objContext = ((IObjectContextAdapter)this).ObjectContext;
            var objSet = objContext.CreateObjectSet<T>();
            var entityKey = objContext.CreateEntityKey(objSet.EntitySet.Name, entity);

            object foundState;

            var exists = objContext.TryGetObjectByKey(entityKey, out foundState);
            if (exists)
            {
                objContext.ObjectStateManager.ChangeObjectState(foundState, state);
                return foundState as T;
            }

            var entry = Entry(entity);
            entry.State = state;

            return entry.Entity;
        }

        public DbContextConfiguration GetConfiguration()
        {
            return Configuration;
        }
        #endregion

        #region [Override]

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add(new CarMap());
            modelBuilder.Configurations.Add(new CarBrandMap());
            modelBuilder.Configurations.Add(new FranchiseeMap());
            modelBuilder.Configurations.Add(new AuditMap());

            base.OnModelCreating(modelBuilder);
        }

        public override int SaveChanges()
        {
            ChangeTracking();
            return base.SaveChanges();
        }

        public override Task<int> SaveChangesAsync()
        {
            ChangeTracking();
            return base.SaveChangesAsync();
        }
        #endregion

        #region [Private Methods]
        private void ChangeTracking()
        {
            var modifiedChanges = ChangeTracker.Entries().ToList();
            var now = DateTime.Now;
            if (modifiedChanges == null) return;
            foreach (var modifiedChange in modifiedChanges)
            {
                var entityName = modifiedChange.Entity.GetType().Name;
                var primaryKey = GetPrimaryKeyValue(modifiedChange);
                var audit = new Audit
                {
                    Action = modifiedChange.State.ToString(),
                    DateChanged = now,
                    EntityIdentifier = primaryKey.ToString(),
                    EntityName = entityName
                };
                Audits.Add(audit);
            }
        }
        private object GetPrimaryKeyValue(DbEntityEntry entry)
        {
            var objectStateEntry = ((IObjectContextAdapter)this).ObjectContext.ObjectStateManager.GetObjectStateEntry(entry.Entity);
            return objectStateEntry.EntityKey.EntityKeyValues[0].Value;
        }
        #endregion
        #region [Entities]
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<Franchisee> Franchisees { get; set; }
        public DbSet<Audit> Audits { get; set; }
      
        #endregion

    }
}
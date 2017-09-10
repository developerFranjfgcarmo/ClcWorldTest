using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ClcWorld.Entities.Entities;
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

        #region [Entities]
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarBrand> CarBrands { get; set; }
        public DbSet<Franchisee> Franchisees { get; set; }
        #endregion
       
    }
}
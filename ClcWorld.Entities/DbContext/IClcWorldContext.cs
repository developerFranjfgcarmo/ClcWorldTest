using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace ClcWorld.Entities.DbContext
{
    interface IClcWorldContext:IDisposable
    {
        Database Database { get; }
        DbChangeTracker GetChangeTracker { get; }
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbEntityEntry Entry(object entity);
        T EntryWithState<T>(T entity, EntityState state) where T : class;
        List<string> GetModifiedProperties<T>(T entity) where T : class;
        DbContextConfiguration GetConfiguration();
        
    }
}

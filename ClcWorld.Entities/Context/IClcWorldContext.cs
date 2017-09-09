using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using ClcWorld.Entities.Entities;

namespace ClcWorld.Entities.Context
{
    public interface IClcWorldContext :IDisposable
    {
        Database Database { get; }
        DbChangeTracker GetChangeTracker { get; }
        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
        DbEntityEntry Entry(object entity);
        T EntryWithState<T>(T entity, EntityState state) where T : class;

        DbSet<Car> Cars { get; set; }
        DbSet<CarBrand> CarBrands { get; set; }
        DbSet<Franchisee> Franchisees { get; set; }
    }
}

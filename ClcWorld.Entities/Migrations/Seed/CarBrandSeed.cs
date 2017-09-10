using System.Data.Entity.Migrations;
using ClcWorld.Entities.Context;
using ClcWorld.Entities.Entities;

namespace ClcWorld.Entities.Migrations.Seed
{
    public static class CarBrandSeed
    {
        public static void Seed(ClcWorldContext context)
        {   
            context.CarBrands.AddOrUpdate(new CarBrand {Id = 1,Name = "Opel"});
            context.CarBrands.AddOrUpdate(new CarBrand { Id = 2, Name = "Fiat" });
            context.CarBrands.AddOrUpdate(new CarBrand { Id = 3, Name = "Citroen" });
            context.CarBrands.AddOrUpdate(new CarBrand { Id = 4, Name = "Kia" });
            context.CarBrands.AddOrUpdate(new CarBrand { Id = 5, Name = "Peogeot" });
            context.CarBrands.AddOrUpdate(new CarBrand { Id = 6, Name = "Renault" });
            context.CarBrands.AddOrUpdate(new CarBrand { Id = 7, Name = "Ford" });
            context.CarBrands.AddOrUpdate(new CarBrand { Id = 8, Name = "Audit" });
            context.CarBrands.AddOrUpdate(new CarBrand { Id = 9, Name = "Seat" });
            context.CarBrands.AddOrUpdate(new CarBrand { Id = 10, Name = "Mercedes" });
            context.CarBrands.AddOrUpdate(new CarBrand { Id = 11, Name = "Bmw" });
            context.CarBrands.AddOrUpdate(new CarBrand { Id = 12, Name = "Volvo" });            
        }
    }
}

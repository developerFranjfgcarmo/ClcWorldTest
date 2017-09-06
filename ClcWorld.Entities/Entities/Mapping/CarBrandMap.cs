using System.Data.Entity.ModelConfiguration;

namespace ClcWorld.Entities.Entities.Mapping
{
    internal class CarBrandMap:EntityTypeConfiguration<CarBrand>
    {
        public CarBrandMap()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(50);
        }
    }
}

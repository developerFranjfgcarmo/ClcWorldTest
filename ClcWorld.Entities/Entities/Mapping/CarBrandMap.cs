using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace ClcWorld.Entities.Entities.Mapping
{
    internal class CarBrandMap:EntityTypeConfiguration<CarBrand>
    {
        public CarBrandMap()
        {
            Property(p => p.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
            Property(p => p.Name).IsRequired().HasMaxLength(50);
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;

namespace ClcWorld.Entities.Entities.Mapping
{
    internal class CarMap : EntityTypeConfiguration<Car>
    {
        public CarMap()
        {
            Property(p => p.Registration).HasMaxLength(8).HasColumnAnnotation("IndexRegistration",
                new IndexAnnotation(new IndexAttribute("IX_Registration") {IsUnique = true}));
        }
    }
}
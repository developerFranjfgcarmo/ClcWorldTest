using System.Data.Entity.ModelConfiguration;

namespace ClcWorld.Entities.Entities.Mapping
{
    internal class AuditMap : EntityTypeConfiguration<Audit>
    {
        public AuditMap()
        {
           // Property(p => p.EntityName).HasMaxLength(50);
            Property(p => p.EntityIdentifier).HasMaxLength(100);
            Property(p => p.Action).HasMaxLength(20);
        }
    }
}
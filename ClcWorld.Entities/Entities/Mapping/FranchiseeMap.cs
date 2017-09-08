using System.Data.Entity.ModelConfiguration;

namespace ClcWorld.Entities.Entities.Mapping
{
    internal class FranchiseeMap : EntityTypeConfiguration<Franchisee>
    {
        public FranchiseeMap()
        {
            Property(p => p.Name).IsRequired().HasMaxLength(50);
            Property(p => p.AddressFranchisee).HasMaxLength(100);
        }
    }
}
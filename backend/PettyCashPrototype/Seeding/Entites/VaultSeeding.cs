using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PettyCashPrototype.Seeding.Entites
{
    public class VaultSeeding: IEntityTypeConfiguration<Vault>
    {
        public void Configure(EntityTypeBuilder<Vault> builder)
        {
            builder.HasData(
                new Vault
                {
                    VaultId = 1,
                    CurrentAmount = 10000,
                    IsActive = true,
                });
        }
    }
}

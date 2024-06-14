using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PettyCashPrototype.Seeding.Entites
{
    public class PurposeSeeding: IEntityTypeConfiguration<Purpose>
    {
        public void Configure(EntityTypeBuilder<Purpose> builder)
        {
            builder.HasData(
                new Purpose
                {
                    PurposeId = 1,
                    Name = "ADM",
                    Description = "Administration",
                    IsActive = true,
                },
                new Purpose
                {
                    PurposeId = 2,
                    Name = "RGC",
                    Description = "Regulatory Compliance",
                    IsActive = true,
                },
                new Purpose
                {
                    PurposeId = 3,
                    Name = "DMT",
                    Description = "Diamond Trade",
                    IsActive = true,
                },
                new Purpose
                {
                    PurposeId = 4,
                    Name = "ZZZ",
                    IsActive = true,
                }
            );
        }
    }
}

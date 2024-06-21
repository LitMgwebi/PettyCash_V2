﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PettyCashPrototype.Seeding.Entites
{
    public class OfficeSeeding: IEntityTypeConfiguration<Office>
    {
        public void Configure(EntityTypeBuilder<Office> builder)
        {
            builder.HasData(
                new Office
                {
                    OfficeId = 1,
                    Name = "JHB",
                    Description = "Johannesburg",
                    IsActive = true,
                },
                new Office
                {
                    OfficeId = 2,
                    Name = "KIM",
                    Description = "Kimberely",
                    IsActive = true,
                },
                new Office
                {
                    OfficeId = 3,
                    Name = "CPT",
                    Description = "Cape Town",
                    IsActive = true,
                }
                );
        }
    }
}

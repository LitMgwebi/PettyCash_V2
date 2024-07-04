using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PettyCashPrototype.Seeding.Entites
{
    public class TripStatusSeeding: IEntityTypeConfiguration<TripStatus>
    {
        public void Configure(EntityTypeBuilder<TripStatus> builder)
        {
            builder.HasData(
                new TripStatus
                {
                    TripStatusId = 1,
                    Description = "Approved",
                    IsActive = true
                },
                new TripStatus
                {
                    TripStatusId = 2,
                    Description = "Declined",
                    IsActive = true
                },
                new TripStatus
                {
                    TripStatusId = 3,
                    Description = "Recommended",
                    IsActive = true
                },
                new TripStatus
                {
                    TripStatusId = 4,
                    Description = "Not Recommended",
                    IsActive = true
                }
                );
        }
    }
}

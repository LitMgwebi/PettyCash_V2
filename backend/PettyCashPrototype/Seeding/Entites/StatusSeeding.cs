using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PettyCashPrototype.Seeding.Entites
{
    public class StatusSeeding: IEntityTypeConfiguration<Status>
    {
        public void Configure(EntityTypeBuilder<Status> builder)
        {
            builder.HasData(
                new Status
                {
                    StatusId = 1,
                    Description = "Approved",
                    IsApproved = true,
                    IsRecommended = false,
                    IsActive = true
                },
                new Status
                {
                    StatusId = 2,
                    Description = "Declined",
                    IsApproved = true,
                    IsRecommended = false,
                    IsActive = true
                },
                new Status
                {
                    StatusId = 3,
                    Description = "Recommended",
                    IsApproved = false,
                    IsRecommended = true,
                    IsActive = true
                },
                new Status
                {
                    StatusId = 4,
                    Description = "Not Recommended",
                    IsApproved = false,
                    IsRecommended = true,
                    IsActive = true
                }
                );
        }
    }
}

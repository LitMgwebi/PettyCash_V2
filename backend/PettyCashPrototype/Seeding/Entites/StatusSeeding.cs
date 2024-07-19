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
                    Option = "Approve",
                    Description = "Approved",
                    IsApproved = true,
                    IsRecommended = false,
                    IsActive = true
                },
                new Status
                {
                    StatusId = 2,
                    Option = "Decline",
                    Description = "Declined",
                    IsApproved = true,
                    IsRecommended = false,
                    IsActive = true
                },
                new Status
                {
                    StatusId = 3,
                    Option = "Recommend",
                    Description = "Recommended",
                    IsApproved = false,
                    IsRecommended = true,
                    IsActive = true
                },
                new Status
                {
                    StatusId = 4,
                    Option = "Reject",
                    Description = "Rejected",
                    IsApproved = false,
                    IsRecommended = true,
                    IsActive = true
                }
                );
        }
    }
}

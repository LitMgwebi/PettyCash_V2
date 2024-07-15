using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PettyCashPrototype.Seeding.Entites
{
    public class JobTitleSeeding: IEntityTypeConfiguration<JobTitle>
    {
        public void Configure(EntityTypeBuilder<JobTitle> builder)
        {
            builder.HasData(
                new JobTitle
                {
                    JobTitleId = 1,
                    Description = "CEO"
                },
                new JobTitle
                {
                    JobTitleId = 2,
                    Description = "CFO"
                },
                new JobTitle
                {
                    JobTitleId = 3,
                    Description = "GM: Corporate Services"
                },
                new JobTitle
                {
                    JobTitleId = 4,
                    Description = "GM: Governance"
                },
                new JobTitle
                {
                    JobTitleId = 5,
                    Description = "GM: Regulatory Compliance"
                },
                new JobTitle
                {
                    JobTitleId = 6,
                    Description = "GM: Trade"
                },
                new JobTitle
                {
                    JobTitleId = 7,
                    Description = "Manager"
                },
                new JobTitle
                {
                    JobTitleId = 8,
                    Description = "Staff"
                },
                new JobTitle
                {
                    JobTitleId = 9,
                    Description = "Consultant"
                },
                new JobTitle
                {
                    JobTitleId = 10,
                    Description = "Chair Person"
                },
                new JobTitle
                {
                    JobTitleId = 11,
                    Description = "Board Member"
                },
                new JobTitle
                {
                    JobTitleId = 12,
                    Description = "WGM"
                },
                new JobTitle
                {
                    JobTitleId = 13,
                    Description = "General Manager"
                },
                new JobTitle
                {
                    JobTitleId = 13,
                    Description = "Accountant"
                },
                new JobTitle
                {
                    JobTitleId = 13,
                    Description = "Bookkeeper"
                }
                );
        }
    }
}

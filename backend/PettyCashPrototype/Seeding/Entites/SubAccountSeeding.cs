using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PettyCashPrototype.Seeding.Entites
{
    public class SubAccountSeeding: IEntityTypeConfiguration<SubAccount>
    {
        public void Configure(EntityTypeBuilder<SubAccount> builder)
        {
            builder.HasData(
                new SubAccount
                {
                    SubAccountId = 1,
                    AccountNumber = "0206",
                    Name = "IT Audit",
                    IsActive = true,
                },
                new SubAccount
                {
                    SubAccountId = 2,
                    AccountNumber = "0045",
                    Name = "Meeting Fees",
                    IsActive = true,
                },
                new SubAccount
                {
                    SubAccountId = 3,
                    AccountNumber = "0001",
                    Name = "Accomodation",
                    IsActive = true,
                },
                new SubAccount
                {
                    SubAccountId = 4,
                    AccountNumber = "0006",
                    Name = "Basic Salaries",
                    IsActive = true,
                },
                new SubAccount
                {
                    SubAccountId = 5,
                    AccountNumber = "0034",
                    Name = "Housing",
                    IsActive = true,
                },
                new SubAccount
                {
                    SubAccountId = 6,
                    AccountNumber = "0101",
                    Name = "Membership Fees",
                    IsActive = true,
                },
                new SubAccount
                {
                    SubAccountId = 7,
                    AccountNumber = "0094",
                    Name = "System Support",
                    IsActive = true,
                },
                new SubAccount
                {
                    SubAccountId = 8,
                    AccountNumber = "0002",
                    Name = "Air travel",
                    IsActive = true,
                },
                new SubAccount
                {
                    SubAccountId = 9,
                    AccountNumber = "0066",
                    Name = "Shuttle and Taxi Service",
                    IsActive = true,
                },
                new SubAccount
                {
                    SubAccountId = 10,
                    AccountNumber = "0044",
                    Name = "Medical Aid",
                    IsActive = true,
                },
                new SubAccount
                {
                    SubAccountId = 11,
                    AccountNumber = "0010",
                    Name = "Cellphones and Data",
                    IsActive = true,
                },
                new SubAccount
                {
                    SubAccountId = 12,
                    AccountNumber = "0086",
                    Name = "Vehicle Rental",
                    IsActive = true,
                }
                );
        }
    }
}

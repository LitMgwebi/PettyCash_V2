using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PettyCashPrototype.Seeding.Entites
{
    public class MainAccountSeeding: IEntityTypeConfiguration<MainAccount>
    {
        public void Configure(EntityTypeBuilder<MainAccount> builder)
        {
            builder.HasData(
                new MainAccount
                {
                    MainAccountId = 1,
                    AccountNumber = "2013",
                    Name = "Insurance",
                    IsActive = true,
                },
                new MainAccount
                {
                    MainAccountId = 2,
                    AccountNumber = "2012",
                    Name = "Inspection",
                    IsActive = true,
                },
                new MainAccount
                {
                    MainAccountId = 3,
                    AccountNumber = "2007",
                    Name = "Domestic Travel",
                    IsActive = true,
                },
                new MainAccount
                {
                    MainAccountId = 4,
                    AccountNumber = "2031",
                    Name = "Staff Renumeration",
                    IsActive = true,
                },
                new MainAccount
                {
                    MainAccountId = 5,
                    AccountNumber = "2017",
                    Name = "Legal Fees",
                    IsActive = true,
                },
                new MainAccount
                {
                    MainAccountId = 6,
                    AccountNumber = "2080",
                    Name = "Support Services",
                    IsActive = true,
                },
                new MainAccount
                {
                    MainAccountId = 7,
                    AccountNumber = "2038",
                    Name = "Training and Development",
                    IsActive = true,
                },
                new MainAccount
                {
                    MainAccountId = 8,
                    AccountNumber = "2035",
                    Name = "Telecommunication",
                    IsActive = true,
                },
                new MainAccount
                {
                    MainAccountId = 9,
                    AccountNumber = "2011",
                    Name = "Hospitality",
                    IsActive = true,
                }
                );
        }
    }
}

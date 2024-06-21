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
                }
                );
        }
    }
}

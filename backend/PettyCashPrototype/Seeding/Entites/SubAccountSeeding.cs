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
                }
                );
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PettyCashPrototype.Seeding.Entites
{
    public class RolesSeeding: IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole
                {
                    Name = "Admin"
                },
                new IdentityRole
                {
                    Name = "Finance Officer"
                },
                new IdentityRole
                {
                    Name = "Finance Manager"
                },
                new IdentityRole
                {
                    Name = "ICT Officer"
                },
                new IdentityRole
                {
                    Name = "ICT Manager"
                }

                );
        }
    }
}

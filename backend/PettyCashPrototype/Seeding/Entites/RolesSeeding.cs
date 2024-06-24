using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PettyCashPrototype.Seeding.Entites
{
    public class RolesSeeding: IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            builder.HasData(
                new Role
                {
                    Name = "Admin"
                },
                new Role
                {
                    Name = "Finance Officer"
                },
                new Role
                {
                    Name = "Finance Manager"
                },
                new Role
                {
                    Name = "ICT Officer"
                },
                new Role
                {
                    Name = "ICT Manager"
                }

                );
        }
    }
}

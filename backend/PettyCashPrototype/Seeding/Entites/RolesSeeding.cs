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
                    Name = "Super_User"
                },
                new IdentityRole
                {
                    Name = "Manager"
                },
                new IdentityRole
                {
                    Name = "GM_Manager"
                },
                new IdentityRole
                {
                    Name = "ICT_Admin"
                },
                new IdentityRole
                {
                    Name = "Cashier"
                },
                new IdentityRole
                {
                    Name = "HR_Admin"
                },
                new IdentityRole
                {
                    Name = "Finance_Admin"
                },
                new IdentityRole
                {
                    Name = "PA_Admin"
                },
                new IdentityRole
                {
                    Name = "CEO_Admin"
                },
                new IdentityRole
                {
                    Name = "SCM_Admin"
                },
                new IdentityRole
                {
                    Name = "Employee"
                },
                new IdentityRole
                {
                    Name = "DEEC_Admin"
                },
                new IdentityRole
                {
                    Name = "SRM_Admin"
                }

                );
        }
    }
}

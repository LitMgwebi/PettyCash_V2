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
                    Name = "Super_User",
                    NormalizedName = "Super_User"
                },
                new IdentityRole
                {
                    Name = "Manager",
                    NormalizedName = "Manager",
                },
                new IdentityRole
                {
                    Name = "GM_Manager",
                    NormalizedName = "GM_Manager"
                },
                new IdentityRole
                {
                    Name = "ICT_Admin",
                    NormalizedName = "ICT_Admin"
                },
                new IdentityRole
                {
                    Name = "Cashier",
                    NormalizedName = "Cashier",
                },
                new IdentityRole
                {
                    Name = "HR_Admin",
                    NormalizedName = "HR_Admin",
                },
                new IdentityRole
                {
                    Name = "Finance_Admin",
                    NormalizedName = "Finance_Admin",
                },
                new IdentityRole
                {
                    Name = "PA_Admin",
                    NormalizedName = "PA_Admin",
                },
                new IdentityRole
                {
                    Name = "CEO_Admin",
                    NormalizedName = "CEO_Admin",
                },
                new IdentityRole
                {
                    Name = "SCM_Admin",
                    NormalizedName = "SCM_Admin",
                },
                new IdentityRole
                {
                    Name = "Employee",
                    NormalizedName = "Employee",
                },
                new IdentityRole
                {
                    Name = "DEEC_Admin",
                    NormalizedName = "DEEC_Admin",
                },
                new IdentityRole
                {
                    Name = "SRM_Admin",
                    NormalizedName = "SRM_Admin",
                }

                );
        }
    }
}

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace PettyCashPrototype.Seeding.Entites
{
    public class DepartmentSeeding: IEntityTypeConfiguration<Department>
    {
        public void Configure(EntityTypeBuilder<Department> builder)
        {
            builder.HasData(
                new Department
                {
                    DepartmentId = 1,
                    Name = "INS",
                    Description = "Inspectorate",
                    IsActive = true,
                }, 
                new Department
                {
                    DepartmentId = 2,
                    Name = "ICT",
                    Description = "Information Communication Technology",
                    IsActive = true,
                },
                new Department
                {
                    DepartmentId = 3,
                    Name = "LEG",
                    Description = "Legal",
                    IsActive = true,
                }
                );
        }
    }
}

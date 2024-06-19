namespace PettyCashPrototype.Services.DepartmentService
{
    public interface IDepartment
    {
        public Task<IEnumerable<Department>> GetAll();
        public Task<Department> GetOne(int id);
        public void Create(Department department);
        public void Edit(Department department);
        public void SoftDelete(Department department);
    }
}

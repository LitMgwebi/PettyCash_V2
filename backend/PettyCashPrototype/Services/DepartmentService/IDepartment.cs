namespace PettyCashPrototype.Services.DepartmentService
{
    public interface IDepartment
    {
        public Task<IEnumerable<Department>> GetAll();
        public Task<Department> GetOne(int id);
    }
}

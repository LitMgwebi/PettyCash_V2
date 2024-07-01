namespace PettyCashPrototype.Services.DepartmentService
{
    public interface IDepartment
    {
        public Task<IEnumerable<Division>> GetAll();
        public Task<Division> GetOne(int id);
        public void Create(Division department);
        public void Edit(Division department);
        public void SoftDelete(Division department);
    }
}

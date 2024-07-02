using PettyCashPrototype.Models;

namespace PettyCashPrototype.Services.DepartmentService
{
    public class DepartmentService: IDepartment
    {
        private PettyCashPrototypeContext _db;
        public DepartmentService(PettyCashPrototypeContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Department>> GetAll()
        {
            try
            {
                IEnumerable<Department> departments = await _db.Departments
                    .Where(x => x.IsActive == true)
                    .ToListAsync();

                if (departments == null)
                    throw new Exception("System could not find any departments");

                return departments;
            }
            catch { throw; }
        }


        public async Task<Department> GetOne(int id)
        {
            try
            {
                Department department = await _db.Departments
                .Where(a => a.IsActive == true)
                .SingleAsync(x => x.DepartmentId == id);

                if (department == null) throw new Exception("System could not retrieve the Department.");

                return department;
            }
            catch { throw; }
        }
    }
}

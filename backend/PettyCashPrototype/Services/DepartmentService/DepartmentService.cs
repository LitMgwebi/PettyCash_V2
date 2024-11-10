using PettyCashPrototype.Models;

namespace PettyCashPrototype.Services.DepartmentService
{
    public class DepartmentService : IDepartment
    {
        private PettyCashContext _db;
        public DepartmentService(PettyCashContext db) { _db = db; }

        public async Task<IEnumerable<Department>> GetAll()
        {
            try
            {
                IEnumerable<Department> departments = await _db.Departments
                    .Where(x => x.IsActive == true)
                    .AsNoTracking()
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
                    .AsNoTracking()
                .FirstOrDefaultAsync(x => x.DepartmentId == id);

                if (department == null) throw new Exception("System could not retrieve the Department.");

                return department;
            }
            catch { throw; }
        }
    }
}

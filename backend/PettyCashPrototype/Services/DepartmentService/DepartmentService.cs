namespace PettyCashPrototype.Services.DepartmentService
{
    public class DepartmentService: IDepartment
    {
        private PettyCashPrototypeContext _db;
        public DepartmentService(PettyCashPrototypeContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Division>> GetAll()
        {
            try
            {
                IEnumerable<Division> departments = await _db.Departments
                    .Where(x => x.IsActive == true)
                    .ToListAsync();

                if (departments == null)
                    throw new Exception("System could not find any departments");

                return departments;
            }
            catch { throw; }
        }

        public async Task<Division> GetOne(int id)
        {
            try
            {
                Division department = await _db.Departments
                    .Where(a => a.IsActive == true)
                    .SingleAsync(x => x.DepartmentId == id);

                if (department == null) throw new Exception("System could not retrieve the Department.");

                return department;
            }
            catch { throw; }
        }

        public void Create(Division department)
        {
            try
            {
                _db.Departments.Add(department);
                int result = _db.SaveChanges();

                if (result == 0) throw new DbUpdateException("System was unable to add the new departments.");
            }
            catch { throw; }
        }

        public void Edit(Division department)
        {
            try
            {
                _db.Departments.Update(department);
                int result = _db.SaveChanges();

                if (result == 0) throw new DbUpdateException($"System could not edit ${department.Name}");
            }
            catch { throw; }
        }

        public void SoftDelete(Division department)
        {
            try
            {
                department.IsActive = false;
                _db.Departments.Update(department);
                int result = _db.SaveChanges();

                if(result == 0) throw new DbUpdateException($"System could not delete ${department.Name}");
            }
            catch { throw; }
        }
    }
}

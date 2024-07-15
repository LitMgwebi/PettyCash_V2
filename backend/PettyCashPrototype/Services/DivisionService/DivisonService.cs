namespace PettyCashPrototype.Services.DivisionService
{
    public class DivisonService: IDivision
    {
        private PettyCashPrototypeContext _db;
        public DivisonService(PettyCashPrototypeContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Division>> GetAll()
        {
            try
            {
                IEnumerable<Division> divisions = await _db.Divisions
                    .Where(x => x.IsActive == true)
                    .ToListAsync();

                if (divisions == null)
                    throw new Exception("System could not find any departments");

                return divisions;
            }
            catch { throw; }
        }

        public async Task<Division> GetOne(int id)
        {
            try
            {
                Division division = await _db.Divisions
                    .Where(a => a.IsActive == true)
                    .Include(d => d.Department)
                    .FirstOrDefaultAsync(x => x.DivisionId == id);

                if (division == null) throw new Exception("System could not retrieve the Department.");

                return division;
            }
            catch { throw; }
        }

        public void Create(Division division)
        {
            try
            {
                _db.Divisions.Add(division);
                int result = _db.SaveChanges();

                if (result == 0) throw new DbUpdateException("System was unable to add the new departments.");
            }
            catch { throw; }
        }

        public void Edit(Division division)
        {
            try
            {
                _db.Divisions.Update(division);
                int result = _db.SaveChanges();

                if (result == 0) throw new DbUpdateException($"System could not edit ${division.Name}");
            }
            catch { throw; }
        }

        public void SoftDelete(Division division)
        {
            try
            {
                division.IsActive = false;
                _db.Divisions.Update(division);
                int result = _db.SaveChanges();

                if(result == 0) throw new DbUpdateException($"System could not delete ${division.Name}");
            }
            catch { throw; }
        }
    }
}

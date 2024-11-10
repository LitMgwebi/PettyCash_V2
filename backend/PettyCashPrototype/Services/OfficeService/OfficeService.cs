namespace PettyCashPrototype.Services.OfficeService
{
    public class OfficeService: IOffice
    {
        private PettyCashContext _db;
        public OfficeService(PettyCashContext db) => _db = db;


        public async Task<IEnumerable<Office>> GetAll()
        {
            try
            {
                IEnumerable<Office> offices = await _db.Offices
                    .Where(x => x.IsActive == true)
                    .AsNoTracking()
                    .ToListAsync();

                if (offices == null)
                    throw new Exception("System could not find any offices.");

                return offices;
            }
            catch { throw; }
        }

        public async Task<Office> GetOne(int id)
        {
            try
            {
                Office office = await _db.Offices
                    .Where(a => a.IsActive == true)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(i => i.OfficeId == id);

                if (office == null) throw new Exception("System could not retrieve Office.");

                return office;
            }
            catch { throw; }
        }

        public void Create(Office office)
        {
            try
            {
                _db.Offices.Add(office);
                int result = _db.SaveChanges();

                if (result == 0) throw new Exception("System was unable to add the new office.");
            }
            catch { throw; }
        }

        public void Edit(Office office)
        {
            try
            {
                _db.Offices.Update(office);
                int result = _db.SaveChanges();

                if (result == 0) throw new DbUpdateException($"System could not edit {office.Name}.");
            }
            catch { throw; }
        }

        public void SoftDelete(Office office)
        {
            try
            {
                office.IsActive = false;
                _db.Offices.Update(office);
                int result = _db.SaveChanges();

                if (result == 0) throw new DbUpdateException($"System could not delete ${office.Name}.");
            } 
            catch { throw; }
        }
    }
}

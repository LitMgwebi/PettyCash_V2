namespace PettyCashPrototype.Services.PurposeService
{
    public class PurposeService: IPurpose
    {
        private PettyCashPrototypeContext _db;
        public PurposeService(PettyCashPrototypeContext db) => _db = db;


        public async Task<IEnumerable<Purpose>> GetAll()
        {
            try
            {
                IEnumerable<Purpose> purposes = await _db.Purposes
                    .Where(x => x.IsActive == true)
                    .ToListAsync();

                if (purposes == null)
                    throw new Exception("System could not find any Purposes.");

                return purposes;
            } 
            catch
            {
                throw;
            }
        }

        public async Task<Purpose> GetOne(int id)
        {
            try
            {
                Purpose purpose = await _db.Purposes
                    .Where(a => a.IsActive == true)
                    .SingleAsync(x => x.PurposeId == id);
                
                if (purpose == null)
                    throw new Exception("System could not retrieve the Purpose.");

                return purpose;
            }
            catch
            {
                throw;
            }
        }

        public void Create(Purpose purpose)
        {
            try
            {
                _db.Purposes!.Add(purpose);
                int result = _db.SaveChanges();

                if (result == 0)
                    throw new DbUpdateException("System was not able to add the new purpose.");
            }
            catch
            {
                throw;
            }
        }

        public void Edit(Purpose purpose)
        {
            try
            {
                _db.Purposes!.Update(purpose);
                int result = _db.SaveChanges();

                if (result == 0)
                    throw new DbUpdateException($"System could not edit ${purpose.Name}.");

            }
            catch
            {
                throw;
            }
        }

        public void SoftDelete(Purpose purpose)
        {
            try
            {
                purpose.IsActive = false;
                _db.Purposes!.Update(purpose);
                int result = _db.SaveChanges();

                if (result == 0)
                    throw new DbUpdateException($"System could not delete ${purpose.Name}.");
            }
            catch
            {
                throw;
            }
        }
    }
}

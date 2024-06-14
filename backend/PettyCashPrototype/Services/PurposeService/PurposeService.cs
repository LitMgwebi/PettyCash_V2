using PettyCashPrototype.Models;

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
                    throw new Exception("System could not find any Purposes");

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
                    .SingleOrDefaultAsync(x => x.PurposeId == id);
                
                if (purpose == null)
                    throw new Exception("System could not retrieve the Purpose");

                return purpose;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Create(Purpose purpose)
        {
            try
            {
                await _db.Purposes!.AddAsync(purpose);
                int result = await _db.SaveChangesAsync();
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Edit(Purpose purpose)
        {
            try
            {
                _db.Purposes!.Update(purpose);
                int result = await _db.SaveChangesAsync();
                return result;
            }
            catch
            {
                throw;
            }
        }

        public async Task<int> Delete(int id)
        {
            try
            {
                Purpose purpose = await GetOne(id);
                purpose.IsActive = false;
                _db.Purposes!.Update(purpose);
                int result = await _db.SaveChangesAsync();
                return result;
            }
            catch
            {
                throw;
            }
        }
    }
}

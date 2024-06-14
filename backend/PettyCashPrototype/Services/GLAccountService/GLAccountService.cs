namespace PettyCashPrototype.Services.GLAccountService
{
    public class GLAccountService: IGLAccount
    {
        private PettyCashPrototypeContext _db;
        public GLAccountService(PettyCashPrototypeContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<Glaccount>> GetAll()
        {
            try
            {
                IEnumerable<Glaccount> glAccounts = await _db.Glaccounts
                    .Where(x => x.IsActive == true)
                    .ToListAsync();

                if (glAccounts == null)
                    throw new Exception("System could not find any GL accounts.");

                return glAccounts;
            } catch { throw; }
        }

        public async Task<Glaccount> GetOne(int id)
        {
            try
            {
                Glaccount glAccount = await _db.Glaccounts
                    .Where(a => a.IsActive == true)
                    .SingleAsync();

                if (glAccount == null) throw new Exception("System could not retrieve the GL account.");

                return glAccount;
            }
            catch { throw; }
        }

        public void Create(Glaccount glAccount)
        {
            try
            {
                _db.Glaccounts.Add(glAccount);
                int result = _db.SaveChanges();

                if (result == 0)
                    throw new DbUpdateException("System could not add the new GL account");
            }
            catch { throw; }
        }

        public void Edit(Glaccount glAccount)
        {
            try
            {
                _db.Glaccounts.Update(glAccount);
                int result = _db.SaveChanges();

                if (result == 0)
                    throw new DbUpdateException($"System could not edit {glAccount.Name}.");
            }
            catch { throw; }
        }

        public void SoftDelete(Glaccount glAccount)
        {
            try
            {
                glAccount.IsActive = false;
                _db.Glaccounts.Update(glAccount);
                int result = _db.SaveChanges();

                if (result == 0)
                    throw new DbUpdateException($"System could not delete ${glAccount.Name}");
            }
            catch { throw; }
        }
    }
}

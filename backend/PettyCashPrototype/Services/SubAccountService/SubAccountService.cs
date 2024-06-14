namespace PettyCashPrototype.Services.SubAccountService
{
    public class SubAccountService: ISubAccount
    {
        private PettyCashPrototypeContext _db;
        public SubAccountService(PettyCashPrototypeContext db) => _db = db;


        public async Task<IEnumerable<SubAccount>> GetAll()
        {
            try
            {
                IEnumerable<SubAccount> subAccounts = await _db.SubAccounts
                    .Where(x => x.IsActive == true)
                    .ToListAsync();

                if (subAccounts == null)
                    throw new Exception("System could not find any Sub Accounts.");

                return subAccounts;
            }
            catch { throw; }
        }

        public async Task<SubAccount> GetOne(int id)
        {
            try
            {
                SubAccount subAccount = await _db.SubAccounts
                    .Where(a => a.IsActive == true)
                    .SingleAsync(x => x.SubAccountId == id);

                if (subAccount == null)
                    throw new Exception("System could not retrieve the Sub Account.");

                return subAccount;
            }
            catch { throw; }
        }

        public void Create(SubAccount subAccount)
        {
            try
            {
                _db.SubAccounts.Add(subAccount);
                int result = _db.SaveChanges();

                if (result == 0)
                    throw new DbUpdateException("System could not add the new sub account.");
            }
            catch { throw; }
        }

        public void Edit(SubAccount subAccount)
        {
            try
            {
                _db.SubAccounts.Update(subAccount);
                int result = _db.SaveChanges();

                if (result == 0)
                    throw new DbUpdateException($"System could not edit {subAccount.Name}.");

            }
            catch { throw; }
        }

        public void SoftDelete(SubAccount subAccount)
        {
            try
            {
                subAccount.IsActive = false;
                _db.SubAccounts.Update(subAccount);
                int result = _db.SaveChanges();

                if (result == 0)
                    throw new DbUpdateException($"System could not delete ${subAccount.Name}.");
            }
            catch { throw; }
        }
    }
}

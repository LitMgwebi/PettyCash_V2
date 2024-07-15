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
                    .OrderBy(x => x.Name)
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
                    .FirstOrDefaultAsync(x => x.SubAccountId == id);

                if (subAccount == null)
                    throw new Exception("System could not retrieve the Sub Account.");

                return subAccount;
            }
            catch { throw; }
        }

        public async Task Create(SubAccount subAccount)
        {
            try
            {
                IEnumerable<SubAccount> subAccounts = await GetAll();

                if (subAccounts.Select(x => x.Name).ToList().Contains(subAccount.Name))
                    throw new DbUpdateException($"System already contains Sub Account with the name: {subAccount.Name}");

                if(subAccounts.Select(x => x.AccountNumber).ToList().Contains(subAccount.AccountNumber))
                    throw new DbUpdateException($"System already contains Sub Account with the account number: {subAccount.AccountNumber}");

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

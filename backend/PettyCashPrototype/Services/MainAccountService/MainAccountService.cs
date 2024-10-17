﻿namespace PettyCashPrototype.Services.MainAccountService
{
    public class MainAccountService: IMainAccount
    {
        private PettyCashPrototypeContext _db;
        public MainAccountService(PettyCashPrototypeContext db)
        {
            _db = db;
        }

        public async Task<IEnumerable<MainAccount>> GetAll()
        {
            try
            {
                IEnumerable<MainAccount> mainAccounts = await _db.MainAccounts
                    .Where(x => x.IsActive == true)
                    .OrderBy(x => x.Name)
                    .AsNoTracking()
                    .ToListAsync();

                if (mainAccounts == null)
                    throw new Exception("System could not find any main accounts.");

                return mainAccounts;
            }
            catch { throw; }
        }

        public async Task<MainAccount> GetOne(int id)
        {
            try
            {
                MainAccount mainAccount = await _db.MainAccounts
                    .Where(a => a.IsActive == true)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.MainAccountId == id);

                if (mainAccount == null)
                    throw new Exception("System could not retrieve the main account.");

                return mainAccount;
            }
            catch { throw; }
        }

        public async Task Create(MainAccount mainAccount)
        {
            try
            {
                IEnumerable<MainAccount> mainAccounts = await GetAll();

                if (mainAccounts.Select(x => x.Name).ToList().Contains(mainAccount.Name))
                    throw new DbUpdateException($"System already contains Main Account with the name: {mainAccount.Name}");
                
                if (mainAccounts.Select(x => x.AccountNumber).ToList().Contains(mainAccount.AccountNumber))
                    throw new DbUpdateException($"System already contains Main Account with the number: {mainAccount.AccountNumber}");
                
                var res = _db.MainAccounts.Add(mainAccount);
                int result = _db.SaveChanges();

                if (result == 0)
                    throw new DbUpdateException("System could not add the new main account.");
            }
            catch { throw; }
        }

        public void Edit(MainAccount mainAccount)
        {
            try
            {
                _db.MainAccounts.Update(mainAccount);
                int result = _db.SaveChanges();
                if (result == 0)
                    throw new DbUpdateException($"System could not edit {mainAccount.Name}.");
            }
            catch { throw; }
        }

        public void SoftDelete(MainAccount mainAccount)
        {
            try
            {
                mainAccount.IsActive = false;
                _db.MainAccounts.Update(mainAccount);
                int result = _db.SaveChanges();

                if (result == 0)
                    throw new DbUpdateException($"System could not delete ${mainAccount.Name}.");

            }
            catch { throw; }
        }
    }
}

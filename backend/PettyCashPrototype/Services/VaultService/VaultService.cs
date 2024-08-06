namespace PettyCashPrototype.Services.VaultService
{
    public class VaultService: IVault
    {
        private PettyCashPrototypeContext _db;

        public VaultService(PettyCashPrototypeContext db) { _db = db; }


        public async Task<IEnumerable<Vault>> GetAll()
        {
            try
            {
                IEnumerable<Vault> vaults = await _db.Vaults
                    .Where(a => a.IsActive == true)
                    .AsNoTracking()
                    .ToListAsync();

                if (vaults == null)
                    throw new DBConcurrencyException("System could not find any vaults.");
            
                return vaults;
            }
            catch { throw; }
        }

        public async Task<Vault> GetOne(int vaultId)
        {
            try
            {
                Vault vault = await _db.Vaults
                    .Where(a => a.IsActive == true)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(i => i.VaultId == vaultId);

                if (vault == null)
                    throw new DBConcurrencyException("System could not retrieve the vault.");

                return vault;
            }
            catch { throw; }
        }

        public async Task Create(Vault vault)
        {
            try
            {
                _db.Vaults.Add(vault);
                if (await _db.SaveChangesAsync() == 0)
                    throw new DbUpdateException("System could not add the new vault.");
            }
            catch { throw; }
        }

        public async Task Edit(Vault vault)
        {

            try
            {
                _db.Vaults.Update(vault);
                int result = await _db.SaveChangesAsync();

                if (result == 0)
                    throw new DbUpdateException("System was unable to update vault");
            }
            catch { throw; }
        }

        public async Task SoftDelete(Vault vault)
        {

            try
            {
                vault.IsActive = false;
                _db.Vaults.Update(vault);
                if (await _db.SaveChangesAsync() == 0)
                    throw new DbUpdateException($"System was unable to delete vault #{vault.VaultId}.");
            }
            catch { throw; }
        }
    }
}

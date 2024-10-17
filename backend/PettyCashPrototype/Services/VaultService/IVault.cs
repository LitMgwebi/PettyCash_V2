namespace PettyCashPrototype.Services.VaultService
{
    public interface IVault
    {
        public Task<IEnumerable<Vault>> GetAll();
        public Task<Vault> GetOne(int vaultId);
        public Task Create(Vault vault);
        public Task Edit(Vault vault);
        public Task SoftDelete(Vault vault);
    }
}

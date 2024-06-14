namespace PettyCashPrototype.Services.MainAccountService
{
    public interface IMainAccount
    {
        public Task<IEnumerable<MainAccount>> GetAll();
        public Task<MainAccount> GetOne(int id);
        public void Create(MainAccount mainAccount);
        public void Edit(MainAccount mainAccount);
        public void SoftDelete(MainAccount mainAccount);
    }
}

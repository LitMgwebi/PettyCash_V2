namespace PettyCashPrototype.Services.GLAccountService
{
    public interface IGLAccount
    {
        public Task<IEnumerable<Glaccount>> GetAll();
        public Task<Glaccount> GetOne(int id);
        public void Create(Glaccount glAccount);
        public void Edit(Glaccount glAccount);
        public void SoftDelete(Glaccount glAccount);
    }
}

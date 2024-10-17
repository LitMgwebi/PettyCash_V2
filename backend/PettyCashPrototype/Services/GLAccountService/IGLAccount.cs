namespace PettyCashPrototype.Services.GLAccountService
{
    public interface IGLAccount
    {
        public Task<IEnumerable<Glaccount>> GetAll(string command, string userId = "", int division = 0);
        public Task<Glaccount> GetOne(int id);
        public Task Create(Glaccount glAccount);
        public Task Edit(Glaccount glAccount);
        public void SoftDelete(Glaccount glAccount);
    }
}

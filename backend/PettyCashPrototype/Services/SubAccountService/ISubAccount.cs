namespace PettyCashPrototype.Services.SubAccountService
{
    public interface ISubAccount
    {
        public Task<IEnumerable<SubAccount>> GetAll();
        public Task<SubAccount> GetOne(int id);
        public void Create(SubAccount subAccount);
        public void Edit(SubAccount subAccount);
        public void SoftDelete(SubAccount subAccount);
    }
}

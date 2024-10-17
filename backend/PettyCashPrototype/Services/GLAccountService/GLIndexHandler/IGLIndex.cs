namespace PettyCashPrototype.Services.GLAccountService.GLIndexHandler
{
    public interface IGLIndex
    {
        Task<IEnumerable<Glaccount>> GetGlAccounts(PettyCashPrototypeContext db, User user);
    }
}

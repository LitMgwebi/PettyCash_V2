namespace PettyCashPrototype.Services.GLAccountService.GLIndexHandler
{
    public class GetAllState: IGLIndex
    {
        public async Task<IEnumerable<Glaccount>> GetGlAccounts(PettyCashPrototypeContext db, User user)
        {
            IEnumerable<Glaccount> glAccounts = await db.Glaccounts
                   .Where(x => x.IsActive == true)
                   .ToListAsync();

            if (glAccounts == null)
                throw new Exception("System could not find any GL accounts.");

            return glAccounts;
        }
    }
}

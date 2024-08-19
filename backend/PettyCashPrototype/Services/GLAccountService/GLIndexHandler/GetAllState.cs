namespace PettyCashPrototype.Services.GLAccountService.GLIndexHandler
{
    public class GetAllState : IGLIndex
    {
        private readonly Division? division;
        public GetAllState(Division? division)
        {
            this.division = division;
        }
        public async Task<IEnumerable<Glaccount>> GetGlAccounts(PettyCashPrototypeContext db, User user)
        {
            IEnumerable<Glaccount> glAccounts = new List<Glaccount>();
            if (division!.DivisionId == 0)
            {
                glAccounts = await db.Glaccounts
                .Where(x => x.IsActive == true)
                .AsNoTracking()
                .ToListAsync();
            }
            else
            {
                glAccounts = await db.Glaccounts
                    .Include(d => d.Division)
                    .Where(x => x.Division == division)
                .Where(x => x.IsActive == true)
                .AsNoTracking()
                .ToListAsync();
            }

            if (glAccounts == null)
                throw new Exception("System could not find any GL accounts.");

            return glAccounts;
        }
    }
}

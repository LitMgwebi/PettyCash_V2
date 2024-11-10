﻿namespace PettyCashPrototype.Services.GLAccountService.GLIndexHandler
{
    public class GetAllbyDivisionState: IGLIndex
    {
        public async Task<IEnumerable<Glaccount>> GetGlAccounts(PettyCashContext db, User user)
        {
            IEnumerable<Glaccount> glAccounts = await db.Glaccounts
                .Where(d => d.DivisionId == user.DivisionId)
                .Where(x => x.IsActive == true)
                .AsNoTracking()
                .ToListAsync();

            if (glAccounts == null)
                throw new Exception("System could not find any GL accounts in your department.");

            return glAccounts;
        }
    }
}

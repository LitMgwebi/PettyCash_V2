﻿namespace PettyCashPrototype.Services.GLAccountService.GLIndexHandler
{
    public interface IGLIndex
    {
        Task<IEnumerable<Glaccount>> GetGlAccounts(PettyCashContext db, User user);
    }
}

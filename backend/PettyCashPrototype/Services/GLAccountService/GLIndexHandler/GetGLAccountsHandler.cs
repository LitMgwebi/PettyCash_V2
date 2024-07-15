namespace PettyCashPrototype.Services.GLAccountService.GLIndexHandler
{
    public class GetGLAccountsHandler
    {
        private IGLIndex state = null!;

        public void setState(IGLIndex state) => this.state = state;

        public async Task<IEnumerable<Glaccount>> request(PettyCashPrototypeContext db, User? user = null)
        {
            IEnumerable<Glaccount> glaccounts = await state.GetGlAccounts(db, user!);

            return glaccounts;
        }
    }
}

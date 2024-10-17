using PettyCashPrototype.Services.GLAccountService.GLIndexHandler;

namespace PettyCashPrototype.Services.GLAccountService
{
    public class GLAccountService: IGLAccount
    {
        private PettyCashPrototypeContext _db;
        private readonly IDivision _department;
        private readonly IUser _user;
        private readonly IMainAccount _mainAccount;
        private readonly ISubAccount _subAccount;
        private readonly IPurpose _purpose;
        private readonly IOffice _office;
        private readonly IDivision _division;
        public GLAccountService(PettyCashPrototypeContext db, IDivision department, IMainAccount mainAccount, ISubAccount subAccount, IPurpose purpose, IOffice office, IUser user, IDivision division)
        {
            _db = db;
            _department = department;
            _mainAccount = mainAccount;
            _subAccount = subAccount;
            _purpose = purpose;
            _office = office;
            _user = user;
            _division = division;
        }

        public async Task<IEnumerable<Glaccount>> GetAll(string command, string userId = "", int divisionId = 0)
        {
            try
            {
                User user = new User();
                Division division = new Division();
                IEnumerable<Glaccount> glAccounts = new List<Glaccount>();
                GetGLAccountsHandler getGLAccounts = new GetGLAccountsHandler();
                if(divisionId > 0) 
                    division = await _division.GetOne(divisionId);
                if(command == "all")
                {
                    getGLAccounts.setState(new GetAllState(division));
                    glAccounts = await getGLAccounts.request(_db);
                } else if(command == "division")
                {
                    user = await _user.GetUserById(userId);
                    getGLAccounts.setState(new GetAllbyDivisionState());
                    glAccounts = await getGLAccounts.request(_db, user);
                } else if(command == "office")
                {
                    getGLAccounts.setState(new GetAllbyOfficeDivisionState());
                    glAccounts = await getGLAccounts.request(_db);
                }

                return glAccounts;
            } catch { throw; }
        }

        public async Task<Glaccount> GetOne(int id)
        {
            try
            {
                Glaccount glAccount = await _db.Glaccounts
                    .Where(a => a.IsActive == true)
                    .Include(x => x.Purpose)
                    .Include(x => x.MainAccount)
                    .Include(x => x.SubAccount)
                    .Include(x => x.Division)
                    .Include(x => x.Office)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(x => x.GlaccountId == id);

                if (glAccount == null) throw new Exception("System could not retrieve the GL account.");

                return glAccount;
            }
            catch { throw; }
        }

        public async Task Create(Glaccount glAccount)
        {
            try
            {
                MainAccount mainAccount = await _mainAccount.GetOne(glAccount.MainAccountId);
                SubAccount subAccount = await _subAccount.GetOne(glAccount.SubAccountId);
                Division division = await _department.GetOne(glAccount.DivisionId);
                Purpose purpose = await _purpose.GetOne(glAccount.PurposeId);
                Office office = await _office.GetOne(glAccount.OfficeId);
                glAccount.Description = $"{mainAccount.AccountNumber}/{subAccount.AccountNumber}/{division.Name}/{purpose.Name}/{office.Name}";

                glAccount.Name = $"{division.Description} {mainAccount.Name} ({subAccount.Name})";

                IEnumerable<Glaccount> glAccounts = await GetAll(command: "all");

                if(glAccounts.Select(x => x.Name).ToList().Contains(glAccount.Name))
                    throw new DbUpdateException($"System already contains GL Account with the name: {glAccount.Name}");

                _db.Glaccounts.Add(glAccount);
                int result = _db.SaveChanges();

                if (result == 0)
                    throw new DbUpdateException("System could not add the new GL account");
            }
            catch { throw; }
        }

        public async Task Edit(Glaccount glAccount)
        {
            try
            {
                glAccount.MainAccount = await _mainAccount.GetOne(glAccount.MainAccountId);
                glAccount.SubAccount = await _subAccount.GetOne(glAccount.SubAccountId);
                glAccount.Division = await _department.GetOne(glAccount.DivisionId);
                glAccount.Purpose = await _purpose.GetOne(glAccount.PurposeId);
                glAccount.Office = await _office.GetOne(glAccount.OfficeId);
                glAccount.Description = $"{glAccount.MainAccount.AccountNumber}/{glAccount.SubAccount.AccountNumber}/{glAccount.Division.Name}/{glAccount.Purpose.Name}/{glAccount.Office.Name}";
                glAccount.Name = $"{glAccount.Division.Description} {glAccount.MainAccount.Name} ({glAccount.SubAccount.Name})";
                _db.Glaccounts.Update(glAccount);
                int result = _db.SaveChanges();

                if (result == 0)
                    throw new DbUpdateException($"System could not edit {glAccount.Name}.");
            }
            catch { throw; }
        }

        public void SoftDelete(Glaccount glAccount)
        {
            try
            {
                glAccount.IsActive = false;
                _db.Glaccounts.Update(glAccount);
                int result = _db.SaveChanges();

                if (result == 0)
                    throw new DbUpdateException($"System could not delete ${glAccount.Name}");
            }
            catch { throw; }
        }
    }
}

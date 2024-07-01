namespace PettyCashPrototype.Services.GLAccountService
{
    public class GLAccountService: IGLAccount
    {
        private PettyCashPrototypeContext _db;
        private readonly IDepartment _department;
        private readonly IMainAccount _mainAccount;
        private readonly ISubAccount _subAccount;
        private readonly IPurpose _purpose;
        private readonly IOffice _office;
        public GLAccountService(PettyCashPrototypeContext db, IDepartment department, IMainAccount mainAccount, ISubAccount subAccount, IPurpose purpose, IOffice office)
        {
            _db = db;
            _department = department;
            _mainAccount = mainAccount;
            _subAccount = subAccount;
            _purpose = purpose;
            _office = office;
        }

        public async Task<IEnumerable<Glaccount>> GetAll()
        {
            try
            {
                IEnumerable<Glaccount> glAccounts = await _db.Glaccounts
                    .Where(x => x.IsActive == true)
                    .ToListAsync();

                if (glAccounts == null)
                    throw new Exception("System could not find any GL accounts.");

                return glAccounts;
            } catch { throw; }
        }

        public async Task<IEnumerable<Glaccount>> GetAllbyDepartment(int divisionId)
        {
            try
            {
                IEnumerable<Glaccount> glAccounts = await _db.Glaccounts
                    .Where(d =>  d.DivisionId == divisionId)
                    .Where(x => x.IsActive == true)
                    .ToListAsync();

                if (glAccounts == null)
                    throw new Exception("System could not find any GL accounts in your department.");

                return glAccounts;
            }
            catch { throw; }
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
                    .SingleAsync(x => x.GlaccountId == id);

                if (glAccount == null) throw new Exception("System could not retrieve the GL account.");

                return glAccount;
            }
            catch { throw; }
        }

        public async Task Create(Glaccount glAccount)
        {
            try
            {
                glAccount.MainAccount = await _mainAccount.GetOne(glAccount.MainAccountId);
                glAccount.SubAccount = await _subAccount.GetOne(glAccount.SubAccountId);
                glAccount.Division = await _department.GetOne(glAccount.DivisionId);
                glAccount.Purpose = await _purpose.GetOne(glAccount.PurposeId);
                glAccount.Office = await _office.GetOne(glAccount.OfficeId);
                glAccount.Description = $"{glAccount.MainAccount.AccountNumber}/{glAccount.SubAccount.AccountNumber}/{glAccount.Division.Name}/{glAccount.Purpose.Name}/{glAccount.Office.Name}";
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

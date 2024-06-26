namespace PettyCashPrototype.Services.RequisitionService
{
    public class RequisitionService: IRequisition
    {
        private PettyCashPrototypeContext _db;
        private readonly IUser _user;
        public RequisitionService(PettyCashPrototypeContext db, IUser user) { 
            _db = db;
            _user = user;
        }

        public async Task<IEnumerable<Requisition>> GetAll()
        {
            try
            {
                IEnumerable<Requisition> requisitions = await _db.Requisitions
                    .Where(a => a.IsActive == true)
                    .ToListAsync();

                if (requisitions == null) throw new Exception("System could not find any requisitions.");
                return requisitions;
            }
            catch { throw; }
        }

        public async Task<IEnumerable<Requisition>> GetAllForManagerApproval()
        {
            try
            {
                IEnumerable<Requisition> requisitions = await _db.Requisitions
                    .Where(a => a.IsActive == true)
                    .Where(a => a.ManagerApproval == null && a.FinanceApproval == null)
                    .Include(a => a.Applicant)
                    .ToListAsync();

                if (requisitions == null) throw new Exception("System could not find any requisitions.");
                return requisitions;
            }
            catch { throw; }
        }

        public async Task<IEnumerable<Requisition>> GetByApplicant(string id)
        {
            try
            {
                IEnumerable<Requisition> requisitions = await _db.Requisitions
                    .Where(a => a.ApplicantId == id)
                    .Include(a => a.Applicant)
                    .Where(a => a.IsActive == true)
                    .ToListAsync();

                if (requisitions == null) throw new Exception("System could not find any of your requisition forms.");
                return requisitions;
            }
            catch { throw; }
        }

        public async Task<Requisition> GetOne(int id)
        {
            try
            {
                Requisition requisition= await _db.Requisitions
                    .Where(a => a.IsActive == true)
                    .Include(z => z.Applicant)
                    .SingleAsync(i => i.RequisitionId == id);

                if (requisition == null) throw new Exception("System could not retrieve the Requisition requested.");
                return requisition;
            }
            catch { throw; }
        }

        public async Task Create(Requisition requisition)
        {
            try
            {
                requisition.Applicant = await _user.GetUserById(requisition.ApplicantId);
                _db.Requisitions.Add(requisition);
                int result = _db.SaveChanges();

                if (result == 0) throw new DbUpdateException("System could not add the new Requisition.");
            }
            catch { throw; }
        }

        public void Edit(Requisition requisition)
        {
            try
            {
                _db.Requisitions.Update(requisition);
                int result = _db.SaveChanges();

                if (result == 0) throw new DbUpdateException($"System could not edit the requisition for {requisition.Applicant}.");
            }
            catch { throw; }
        }

        public void SoftDelete(Requisition requisition)
        {
            try
            {
                requisition.IsActive = false;
                _db.Requisitions.Update(requisition);
                int result = _db.SaveChanges();

                if (result == 0) throw new DbUpdateException($"System could not delete the requested requisition.");
            }
            catch { throw; }
        }
    }
}

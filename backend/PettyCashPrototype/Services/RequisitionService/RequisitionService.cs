namespace PettyCashPrototype.Services.RequisitionService
{
    public class RequisitionService: IRequisition
    {
        private PettyCashPrototypeContext _db;
        public RequisitionService(PettyCashPrototypeContext db) { _db = db; }

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

        public async Task<Requisition> GetOne(int id)
        {
            try
            {
                Requisition requisition= await _db.Requisitions
                    .Where(a => a.IsActive == true)
                    .SingleAsync(i => i.RequisitionId == id);

                if (requisition == null) throw new Exception("System could not retrieve the Requisition requested.");
                return requisition;
            }
            catch { throw; }
        }

        public void Create(Requisition requisition)
        {
            try
            {
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

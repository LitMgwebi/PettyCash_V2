namespace PettyCashPrototype.Services.StatusService
{
    public class StatusService: IStatus
    {
        private PettyCashContext _db;
        public StatusService(PettyCashContext db) { _db = db; }

        public async Task<IEnumerable<Status>> GetAll()
        {
            try
            {
                IEnumerable<Status> statuses = await _db.Statuses
                    .Where(a => a.IsActive == true)
                    .AsNoTracking()
                    .ToListAsync();

                if (statuses == null) throw new Exception("System could not find any statuses.");
                return statuses;
            }
            catch { throw; }
        }

        public async Task<IEnumerable<Status>> GetApproved()
        {
            try
            {
                IEnumerable<Status> statuses = await _db.Statuses
                    .Where(a => a.IsActive == true)
                    .Where(c => c.IsApproved == true)
                    .AsNoTracking()
                    .ToListAsync();

                if (statuses == null) throw new Exception("System could not find any statuses linked to approvals.");
                return statuses;
            }
            catch { throw; }
        }

        public async Task<IEnumerable<Status>> GetRecommended()
        {
            try
            {
                IEnumerable<Status> statuses = await _db.Statuses
                    .Where(a => a.IsActive == true)
                    .Where (c => c.IsRecommended == true)
                    .AsNoTracking()
                    .ToListAsync();

                if (statuses == null) throw new Exception("System could not find any statuses linked to recommendations.");
                return statuses;
            }
            catch { throw; }
        }

        public async Task<IEnumerable<Status>> GetRequisitionStates()
        {
            try
            {
                IEnumerable<Status> statuses = await _db.Statuses
                    .Where(a => a.IsActive == true)
                    .Where(c => c.IsState == true)
                    .AsNoTracking()
                    .ToListAsync();

                if (statuses == null) throw new Exception("System could not find any statuses linked to recommendations.");
                return statuses;
            }
            catch { throw; }
        }

        public async Task<Status> GetOne(int id)
        {
            try
            {
                Status status = await _db.Statuses
                    .Where(a => a.IsActive == true)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(i => i.StatusId == id);

                //requisition!.Motivations = await _motivation.GetAllByRequisition(id);

                if (status == null) throw new Exception("System could not retrieve the Requisition requested.");
                return status;
            }
            catch { throw; }
        }
    }
}

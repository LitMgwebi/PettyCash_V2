namespace PettyCashPrototype.Services.StatusService
{
    public class StatusService: IStatus
    {
        private PettyCashPrototypeContext _db;
        public StatusService(PettyCashPrototypeContext db) { _db = db; }

        public async Task<IEnumerable<Status>> GetApproved()
        {
            try
            {
                IEnumerable<Status> statuses = await _db.Statuses
                    .Where(a => a.IsActive == true)
                    .Where(c => c.IsApproved == true)
                    .AsNoTracking()
                    .ToListAsync();

                if (statuses == null) throw new Exception("System could not find any requisitions.");
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

                if (statuses == null) throw new Exception("System could not find any requisitions.");
                return statuses;
            }
            catch { throw; }
        }
    }
}

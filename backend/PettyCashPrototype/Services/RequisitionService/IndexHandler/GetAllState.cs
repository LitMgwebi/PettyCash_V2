namespace PettyCashPrototype.Services.RequisitionService.IndexHandler
{
    public class GetAllState: IIndexState
    {
        public async Task<IEnumerable<Requisition>> GetRequisitions(PettyCashPrototypeContext db, int divisionId, int jobTitleId, IJobTitle _jobTitle, string userId, string role)
        {
            IEnumerable<Requisition> requisitions = await db.Requisitions
                    .Include(gl => gl.Glaccount)
                    .Where(a => a.IsActive == true)
                    .AsNoTracking()
                    .ToListAsync();

            if (requisitions == null) throw new Exception("System could not find any requisitions.");
            return requisitions;
        }
    }
}

namespace PettyCashPrototype.Services.RequisitionService.IndexHandler
{
    public class GetAllState: IIndexState
    {
        public async Task<IEnumerable<Requisition>> GetRequisitions(PettyCashPrototypeContext db, int divisionId, int jobTitleId, IJobTitle _jobTitle, string userId)
        {
            IEnumerable<Requisition> requisitions = await db.Requisitions
                    .Where(a => a.IsActive == true)
                    .ToListAsync();

            if (requisitions == null) throw new Exception("System could not find any requisitions.");
            return requisitions;
        }
    }
}

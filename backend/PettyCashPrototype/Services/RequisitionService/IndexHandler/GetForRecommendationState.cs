namespace PettyCashPrototype.Services.RequisitionService.IndexHandler
{
    public class GetForRecommendationState : IIndexState
    {
        public async Task<IEnumerable<Requisition>> GetRequisitions(PettyCashPrototypeContext db, int divisionId, int jobTitleId, IJobTitle _jobTitle, string userId)
        {
            IEnumerable<Requisition> requisitions = await db.Requisitions
                .Include(a => a.Applicant)
                .Where(a => a.IsActive == true)
                .Where(d => d.Applicant!.DivisionId == divisionId)
                .Where(a => a.ManagerRecommendation == null && a.FinanceApproval == null)
                .ToListAsync();

            if (requisitions == null) throw new Exception("System could not find any requisitions.");
            return requisitions;
        }
    }
}

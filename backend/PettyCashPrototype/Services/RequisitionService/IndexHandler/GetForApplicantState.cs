namespace PettyCashPrototype.Services.RequisitionService.IndexHandler
{
    public class GetForApplicantState: IIndexState
    {
        public async Task<IEnumerable<Requisition>> GetRequisitions(PettyCashPrototypeContext db, int divisionId, int jobTitleId, IJobTitle _jobTitle, string userId)
        {
            IEnumerable<Requisition> requisitions = await db.Requisitions
                    .Where(a => a.ApplicantId == userId)
                    .Include(a => a.Applicant)
                    .Where(a => a.IsActive == true)
                    .ToListAsync();

            if (requisitions == null) throw new Exception("System could not find any of your requisition forms.");
            return requisitions;
        }
    }
}

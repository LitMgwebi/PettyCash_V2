namespace PettyCashPrototype.Services.RequisitionService.IndexHandler
{
    public class GetForApplicantState: IIndexState
    {
        public async Task<IEnumerable<Requisition>> GetRequisitions(PettyCashPrototypeContext db, int divisionId, int jobTitleId, IJobTitle _jobTitle, string userId, string role)
        {
            IEnumerable<Requisition> requisitions = await db.Requisitions
                    .Include(gl => gl.Glaccount)
                    .Where(a => a.ApplicantId == userId)
                    .Include(a => a.Applicant)
                    .Where(a => a.IsActive == true)
                    .AsNoTracking()
                    .ToListAsync();

            if (requisitions == null) throw new Exception("System could not find any of your requisition forms.");
            return requisitions;
        }
    }
}

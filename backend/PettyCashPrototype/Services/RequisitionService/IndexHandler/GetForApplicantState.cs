namespace PettyCashPrototype.Services.RequisitionService.IndexHandler
{
    public class GetForApplicantState: IIndexState
    {
        private readonly string userId;

        public GetForApplicantState(string userId)
        {
            this.userId = userId;
        }
        public async Task<IEnumerable<Requisition>> GetRequisitions(PettyCashPrototypeContext db)
        {
            // todo: Add code here to allow for the filtering of requisitions for requisitions that are "in process", "open" and "closed"
            IEnumerable<Requisition> requisitions = await db.Requisitions
                    .Include(gl => gl.Glaccount)
                    .Where(a => a.ApplicantId == userId)
                    .Include(a => a.Applicant)
                    .Where(a => a.IsActive == true)
                    .AsNoTracking()
                    .ToListAsync();

            return requisitions;
        }
    }
}

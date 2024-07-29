namespace PettyCashPrototype.Services.RequisitionService.IndexHandler
{
    public class GetForApplicantState: IIndexState
    {
        private readonly PettyCashPrototypeContext db;
        private readonly string userId;

        public GetForApplicantState(PettyCashPrototypeContext db, string userId)
        {
            this.db = db;
            this.userId = userId;
        }
        public async Task<IEnumerable<Requisition>> GetRequisitions()
        {
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

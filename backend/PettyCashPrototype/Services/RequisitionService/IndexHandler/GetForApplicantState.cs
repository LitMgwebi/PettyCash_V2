namespace PettyCashPrototype.Services.RequisitionService.IndexHandler
{
    public class GetForApplicantState: IIndexState
    {
        private readonly string userId;
        private Status status;

        public GetForApplicantState(string userId, Status status)
        {
            this.userId = userId;
            this.status = status;
        }
        public async Task<IEnumerable<Requisition>> GetRequisitions(PettyCashPrototypeContext db)
        {
            IEnumerable<Requisition> requisitions = new List<Requisition>();
            // todo: Add code here to allow for the filtering of requisitions for requisitions that are "in process", "open" and "closed"

            if (status != null)
            {
                if (status.Description == "In Process")
                {
                    requisitions = await db.Requisitions
                        .Include(gl => gl.Glaccount)
                        .Where(a => a.ApplicantId == userId)
                        .Include(a => a.Applicant)
                        .Where(a => a.IsActive == true)
                        .Where(c => c.ManagerRecommendationId == null)
                        .AsNoTracking()
                        .ToListAsync();
                }
                else if (status.Description == "Closed")
                {
                    requisitions = await db.Requisitions
                        .Include(gl => gl.Glaccount)
                        .Where(a => a.ApplicantId == userId)
                        .Include(a => a.Applicant)
                        .Where(a => a.IsActive == true)
                        .Where(c => c.CloseDate != null)
                        .AsNoTracking()
                        .ToListAsync();
                }
                else if (status.Description == "Open")
                {
                    requisitions = await db.Requisitions
                        .Include(gl => gl.Glaccount)
                        .Where(a => a.ApplicantId == userId)
                        .Include(a => a.Applicant)
                        .Where(a => a.IsActive == true)
                        .Where(c => c.FinanceApprovalId != null && c.CloseDate == null)
                        .AsNoTracking()
                        .ToListAsync();
                }
                else
                    throw new Exception("Status provided could not be processed by system. Please contact ICT");
            }
            else
                throw new Exception("Status was sent to server as null. Please contact ICT.");
            

            return requisitions;
        }
    }
}

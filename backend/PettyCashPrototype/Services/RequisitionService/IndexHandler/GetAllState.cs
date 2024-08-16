namespace PettyCashPrototype.Services.RequisitionService.IndexHandler
{
    public class GetAllState: IIndexState
    {
        private Status status;
        public GetAllState(Status status)
        {
            this.status = status;
        }
        public async Task<IEnumerable<Requisition>> GetRequisitions(PettyCashPrototypeContext db)
        {
            IEnumerable<Requisition> requisitions = new List<Requisition>();

            if (status.IsApproved)
            {
                requisitions = await db.Requisitions
                    .Include(gl => gl.Glaccount)
                    .Include(fa => fa.FinanceApproval)
                    .Include(mr => mr.ManagerRecommendation)
                    .Where(a => a.IsActive == true && a.CloseDate == null)
                    .Where(s => s.FinanceApproval! == status)
                    .AsNoTracking()
                    .ToListAsync();
            }
            else if (status.IsRecommended == true)
            {
                requisitions = await db.Requisitions
                    .Include(gl => gl.Glaccount)
                    .Include(a => a.Applicant)
                    .Include(fa => fa.FinanceApproval)
                    .Include(mr => mr.ManagerRecommendation)
                    .Where(a => a.IsActive == true && a.CloseDate == null)
                    .Where(s => s.ManagerRecommendation! == status)
                    .AsNoTracking()
                    .ToListAsync();
            }
            else if(status.IsState == true)
            {
                if (status.Option == "Process")
                {
                    requisitions = await db.Requisitions
                    .Include(gl => gl.Glaccount)
                        .Include(a => a.Applicant)
                        .Where(a => a.IsActive == true)
                        .Where(c => c.ManagerRecommendationId == null)
                        .AsNoTracking()
                        .ToListAsync();
                } else if (status.Option == "Close")
                {
                    requisitions = await db.Requisitions
                        .Include(gl => gl.Glaccount)
                        .Include(i => i.Issuer)
                        .Include(a => a.FinanceApproval)
                        .Include(a => a.ManagerRecommendation)
                        .Include(a => a.Applicant)
                        .Where(a => a.IsActive == true)
                        .Where(c => c.CloseDate != null)
                        .AsNoTracking()
                        .ToListAsync();
                } else if (status.Option == "Open")
                {
                    requisitions = await db.Requisitions
                        .Include(gl => gl.Glaccount)
                        .Include(a => a.FinanceApproval)
                        .Include(a => a.ManagerRecommendation)
                        .Include(a => a.Applicant)
                        .Where(a => a.IsActive == true)
                        .Where(c => c.FinanceApprovalId != null && c.CloseDate == null)
                        .AsNoTracking()
                        .ToListAsync();
                }
            }
            return requisitions;
        }
    }
}

namespace PettyCashPrototype.Services.RequisitionService.IndexHandler
{
    public class GetAllState : IIndexState
    {
        private Status status;
        public GetAllState(Status status)
        {
            this.status = status;
        }
        public async Task<IEnumerable<Requisition>> GetRequisitions(PettyCashPrototypeContext db)
        {
            IEnumerable<Requisition> requisitions = new List<Requisition>();
            if (status != null)
            {
                if (status.StatusId == 0)
                {
                    requisitions = await db.Requisitions
                    .Include(gl => gl.Glaccount)
                    .Include(a => a.Applicant)
                    .Include(mr => mr.ManagerRecommendation)
                    .Include(i => i.Issuer)
                    .Where(a => a.IsActive == true)
                    .AsNoTracking()
                    .ToListAsync();
                }
                else
                {
                    requisitions = await db.Requisitions
                        .Include(gl => gl.Glaccount)
                        .Include(a => a.Applicant)
                        .Include(mr => mr.ManagerRecommendation)
                        .Include(i => i.Issuer)
                        .Where(a => a.IsActive == true)
                        .Where(s => s.State! == status)
                        .AsNoTracking()
                        .ToListAsync();
                }
            }
            else
                throw new Exception("System could not handle status, please contact ICT.");
            //if (status.IsApproved)
            //{
            //    requisitions = await db.Requisitions
            //        .Include(gl => gl.Glaccount)
            //        .Include(a => a.Applicant)
            //        .Include(i => i.Issuer)
            //        .Include(fa => fa.FinanceApproval)
            //        .Include(mr => mr.ManagerRecommendation)
            //        .Where(a => a.IsActive == true && a.CloseDate == null)
            //        .Where(s => s.FinanceApproval! == status)
            //        .AsNoTracking()
            //        .ToListAsync();
            //}
            //else if (status.IsRecommended == true)
            //{
            //    requisitions = await db.Requisitions
            //        .Include(gl => gl.Glaccount)
            //        .Include(a => a.Applicant)
            //        .Include(i => i.Issuer)
            //        .Include(mr => mr.ManagerRecommendation)
            //        .Where(a => a.IsActive == true && a.CloseDate == null)
            //        .Where(s => s.ManagerRecommendation! == status)
            //        .AsNoTracking()
            //        .ToListAsync();
            //}
            //else if(status.IsState == true)
            //{

            //}
            return requisitions;
        }
    }
}

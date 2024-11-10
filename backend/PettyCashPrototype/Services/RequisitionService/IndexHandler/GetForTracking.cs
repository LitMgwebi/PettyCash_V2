namespace PettyCashPrototype.Services.RequisitionService.IndexHandler
{
    public class GetForTracking: IIndexState
    {
        public async Task<IEnumerable<Requisition>> GetRequisitions(PettyCashContext db)
        {
            IEnumerable<Requisition> requisitions = await db.Requisitions
                    .Include(gl => gl.Glaccount)
                    .Include(a => a.Applicant)
                    .Include(fa => fa.FinanceApproval)
                    .Include(fo => fo.FinanceOfficer)
                    .Include(i => i.Issuer)
                    .Include(mr => mr.ManagerRecommendation)
                    .Include(m => m.Manager)
                    .Include(i => i.Issuer)
                    .Where(a => a.IsActive == true)
                    .Where(c => c.ManagerRecommendation != null && c.FinanceApproval != null && c.Issuer != null && c.ConfirmChangeReceived != true)
                    .AsNoTracking()
                    .ToListAsync();

            return requisitions;
        }
    }
}

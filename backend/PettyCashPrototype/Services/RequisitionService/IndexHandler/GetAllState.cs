namespace PettyCashPrototype.Services.RequisitionService.IndexHandler
{
    public class GetAllState: IIndexState
    {
        private int status;
        public GetAllState(int statusId)
        {
            status = statusId;
        }
        public async Task<IEnumerable<Requisition>> GetRequisitions(PettyCashPrototypeContext db)
        {
            IEnumerable<Requisition> requisitions = new List<Requisition>();
            if (status == 0)
            {
                requisitions = await db.Requisitions
                        .Include(gl => gl.Glaccount)
                        .Where(a => a.IsActive == true && a.CloseDate == null)
                        .AsNoTracking()
                        .ToListAsync();
            }
            else if (status > 0 )
            {
                requisitions = await db.Requisitions
                    .Include(gl => gl.Glaccount)
                    .Where(a => a.IsActive == true && a.CloseDate == null)
                    .Where(s => s.FinanceApprovalId == status || s.ManagerRecommendationId == status)
                    .AsNoTracking()
                    .ToListAsync();
            }
            return requisitions;
        }
    }
}

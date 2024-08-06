namespace PettyCashPrototype.Services.RequisitionService.IndexHandler
{
    public class GetAllState: IIndexState
    {
        private readonly PettyCashPrototypeContext db;

        public GetAllState(PettyCashPrototypeContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<Requisition>> GetRequisitions()
        {
            IEnumerable<Requisition> requisitions = await db.Requisitions
                    .Include(gl => gl.Glaccount)
                    .Where(a => a.IsActive == true && a.CloseDate == null)
                    .AsNoTracking()
                    .ToListAsync();

            return requisitions;
        }
    }
}

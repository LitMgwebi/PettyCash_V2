namespace PettyCashPrototype.Services.RequisitionService.IndexHandler
{
    public class GetAllState: IIndexState
    {
        public async Task<IEnumerable<Requisition>> GetRequisitions(PettyCashPrototypeContext db)
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

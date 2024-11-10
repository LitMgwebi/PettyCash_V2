namespace PettyCashPrototype.Services.RequisitionService.IndexHandler
{
    public class GetForReceivingState: IIndexState
    {
        public async Task<IEnumerable<Requisition>> GetRequisitions(PettyCashContext db)
        {
            IEnumerable<Requisition> requisitions = new List<Requisition>();

            return requisitions;
        }
    }
}

namespace PettyCashPrototype.Services.RequisitionService.IndexHandler
{
    public class GetForReceivingState: IIndexState
    {
        private readonly PettyCashPrototypeContext db;

        public GetForReceivingState(PettyCashPrototypeContext db)
        {
            this.db = db;
        }
        public async Task<IEnumerable<Requisition>> GetRequisitions()
        {
            IEnumerable<Requisition> requisitions = new List<Requisition>();

            return requisitions;
        }
    }
}

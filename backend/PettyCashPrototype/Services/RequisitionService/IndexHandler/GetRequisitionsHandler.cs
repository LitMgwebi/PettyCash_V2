namespace PettyCashPrototype.Services.RequisitionService.IndexHandler
{
    public class GetRequisitionsHandler
    {
        private IIndexState state = null!;

        public void setState(IIndexState state) => this.state = state;

        public async Task<IEnumerable<Requisition>> request()
        {
            IEnumerable <Requisition> requisitions = await state.GetRequisitions();

            return requisitions;
        }
    }
}

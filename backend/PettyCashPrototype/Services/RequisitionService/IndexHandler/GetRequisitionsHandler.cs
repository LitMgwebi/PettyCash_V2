namespace PettyCashPrototype.Services.RequisitionService.IndexHandler
{
    public class GetRequisitionsHandler
    {
        private IIndexState state = null!;

        public void setState(IIndexState state) => this.state = state;

        public async Task<IEnumerable<Requisition>> request(PettyCashPrototypeContext db, int divisionId = 0, int jobTitleId = 0, IJobTitle? _jobTitle = null, string userId = "")
        {
            IEnumerable <Requisition> requisitions = await state.GetRequisitions(db, divisionId, jobTitleId, _jobTitle!, userId);

            return requisitions;
        }
    }
}

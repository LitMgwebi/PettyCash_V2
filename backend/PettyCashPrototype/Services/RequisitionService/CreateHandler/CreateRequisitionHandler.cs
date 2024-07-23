namespace PettyCashPrototype.Services.RequisitionService.CreateHandler
{
    public class CreateRequisitionHandler
    {
        private ICreateState state = null!;

        public void setState(ICreateState state) => this.state = state;

        public async Task<string> request(Requisition requisition, PettyCashPrototypeContext _db, string userId)
        {
            string message = await state.CreateRequisition(requisition, _db, userId);
            return message;
        } 
    }
}

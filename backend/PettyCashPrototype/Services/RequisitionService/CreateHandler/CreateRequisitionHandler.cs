namespace PettyCashPrototype.Services.RequisitionService.CreateHandler
{
    public class CreateRequisitionHandler
    {
        private ICreateState state = null!;

        public void setState(ICreateState state) => this.state = state;

        public async Task<string> request(PettyCashPrototypeContext db, Requisition requisition, string userId)
        {
            string message = await state.CreateRequisition(db, requisition, userId);
            return message;
        } 
    }
}

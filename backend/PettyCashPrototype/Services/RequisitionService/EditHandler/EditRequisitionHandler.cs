namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class EditRequisitionHandler
    {
        private IEditState state = null!;

        public void setState(IEditState state) => this.state = state;

        public async Task<string> request(IRequisition service, Requisition requisition, string userId = "")
        {
            string message = await state.EditRequisition(service, requisition, userId);
            return message;
        }
    }
}

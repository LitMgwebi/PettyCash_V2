namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class EditRequisitionHandler
    {
        private IEditState state = null!;

        public void setState(IEditState state) => this.state = state;

        public string request(IRequisition service, Requisition requisition, string userId = "")
        {
            string message = state.EditRequisition(service, requisition, userId);
            return message;
        }
    }
}

namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class EditRequisitionHandler
    {
        private IEditState state = null!;

        public void setState(IEditState state) => this.state = state;

        public async Task<string> request(PettyCashContext db, Requisition requisition)
        {
            string message = await state.EditRequisition(db, requisition);
            return message;
        }
    }
}

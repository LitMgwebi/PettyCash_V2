namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class EditRequisitionHandler
    {
        private IEditState state = null!;

        public void setState(IEditState state) => this.state = state;

        public async Task<string> request()
        {
            string message = await state.EditRequisition();
            return message;
        }
    }
}

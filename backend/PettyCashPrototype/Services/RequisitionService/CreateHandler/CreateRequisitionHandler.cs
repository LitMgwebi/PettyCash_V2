namespace PettyCashPrototype.Services.RequisitionService.CreateHandler
{
    public class CreateRequisitionHandler
    {
        private ICreateState state = null!;

        public void setState(ICreateState state) => this.state = state;

        public async Task<string> request()
        {
            string message = await state.CreateRequisition();
            return message;
        } 
    }
}

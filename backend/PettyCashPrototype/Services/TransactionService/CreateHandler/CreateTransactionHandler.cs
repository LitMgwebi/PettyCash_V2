namespace PettyCashPrototype.Services.TransactionService.CreateHandler
{
    public class CreateTransactionHandler
    {
        private ICreateTransaction state = null!;

        public void setState(ICreateTransaction state) => this.state = state;

        public async Task<string> request()
        {
            string message = await state.CreateTransaction();
            return message;
        }
    }
}

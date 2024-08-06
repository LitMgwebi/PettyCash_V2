namespace PettyCashPrototype.Services.TransactionService.CreateHandler
{
    public class CreateTransactionHandler
    {
        private ICreateTransaction state = null!;

        public void setState(ICreateTransaction state) => this.state = state;

        public string request()
        {
            string message = state.CreateTransaction();
            return message;
        }
    }
}

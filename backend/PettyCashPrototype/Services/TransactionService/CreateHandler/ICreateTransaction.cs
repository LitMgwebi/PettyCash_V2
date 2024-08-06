namespace PettyCashPrototype.Services.TransactionService.CreateHandler
{
    public interface ICreateTransaction
    {
        public Task<string> CreateTransaction();
    }
}

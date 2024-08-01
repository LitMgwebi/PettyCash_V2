namespace PettyCashPrototype.Services.TransactionService
{
    public interface ITransaction
    {
        public Task<IEnumerable<Transaction>> GetAll();
        public Task<Transaction> GetOne(int transactionId);
        public Task<string> Create(int requisitionId, decimal cashIssued, string type);
        public Task Edit(Transaction transaction);
        public Task SoftDelete(Transaction transaction);
    }
}

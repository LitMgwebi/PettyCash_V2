namespace PettyCashPrototype.Services.TransactionService
{
    public interface ITransaction
    {
        public Task<IEnumerable<Transaction>> GetAll(string type = "");
        public Task<Transaction> GetOne(int transactionId);
        public Task<string> Create(decimal cashIssued, string type, int requisitionId = 0, string note = "", string userId = "");
        public Task Edit(Transaction transaction);
        public Task SoftDelete(Transaction transaction);
    }
}

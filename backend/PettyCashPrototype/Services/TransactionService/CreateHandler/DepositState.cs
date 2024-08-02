namespace PettyCashPrototype.Services.TransactionService.CreateHandler
{
    public class DepositState : ICreateTransaction
    {
        private PettyCashPrototypeContext _db;
        private IVault _vault;
        private Transaction transaction;
        private readonly decimal cashAmount;
        public DepositState(PettyCashPrototypeContext db, IVault vault, Transaction transaction,  decimal cashAmount)
        {
            this.transaction = transaction;
            this.cashAmount = cashAmount;
            _db = db;
            _vault = vault;
        }

        public async Task<string> CreateTransaction()
        {
            if (cashAmount < 1)
                throw new Exception("Error, you cannot deposit an amount smaller than R1");

            transaction.Requisition = null;
            transaction.Amount = cashAmount;
            transaction.TransactionDate = DateTime.Now;
            transaction.TransactionType = typesOfTransaction.Deposit;
            transaction.VaultId = 1;

            Vault vault = await _vault.GetOne(transaction.VaultId);
            vault.CurrentAmount += transaction.Amount;
            await _vault.Edit(vault);

            _db.Transactions.Add(transaction);

            if (await _db.SaveChangesAsync() == 0)
                throw new DbUpdateException("System could not add new transaction.");

            return "System has successfully recorded the deposit.";
        }
    }
}

namespace PettyCashPrototype.Services.TransactionService.CreateHandler
{
    public class DepositState : ICreateTransaction
    {
        private PettyCashPrototypeContext _db;
        private IVault _vault;
        private Vault vault;
        private Transaction transaction;
        private readonly decimal cashAmount;
        private readonly int requisitionId;
        private string userId;
        public DepositState(PettyCashPrototypeContext db, IVault _vault, Vault vault, Transaction transaction,  decimal cashAmount, string userId, int requisitionId = 0)
        {
            this.transaction = transaction;
            this.cashAmount = cashAmount;
            _db = db;
            this.userId = userId;
            this._vault = _vault;
            this.vault = vault;
            this.requisitionId = requisitionId;
        }

        public async Task<string> CreateTransaction()
        {
            if (cashAmount < 0)
                throw new Exception("Error, you cannot deposit an amount smaller than R1");

            //transaction.RequisitionId = null;
            transaction.DepositorId = userId;
            transaction.Amount = cashAmount;
            transaction.TransactionDate = DateTime.Now;
            transaction.TransactionType = typesOfTransaction.Deposit;
            transaction.VaultId = 1;

            vault.CurrentAmount += transaction.Amount;
            await _vault.Edit(vault);

            _db.Transactions.Add(transaction);

            if (await _db.SaveChangesAsync() == 0)
                throw new DbUpdateException("System could not add new transaction.");

            return "System has successfully recorded the deposit.";
        }
    }
}

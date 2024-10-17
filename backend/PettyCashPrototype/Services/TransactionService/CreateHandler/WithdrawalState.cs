namespace PettyCashPrototype.Services.TransactionService.CreateHandler
{
    public class WithdrawalState: ICreateTransaction
    {
        private PettyCashPrototypeContext _db;
        private Transaction transaction;
        private readonly decimal cashAmount;
        private readonly int requisitionId;
        private Vault vault;
        private IVault _vault;
        public WithdrawalState(PettyCashPrototypeContext db, IVault _vault, Vault vault, Transaction transaction, decimal cashAmount, int requisitionId)
        {
            _db = db;
            this.vault = vault;
            this._vault = _vault;
            this.transaction = transaction;
            this.cashAmount = cashAmount;
            this.requisitionId = requisitionId;
        }

        public async Task<string> CreateTransaction()
        {
            if (cashAmount > vault.CurrentAmount)
            {
                throw new Exception($"System cannot process the withdrawal. Amount withdrawed is larger than the current amount left in the vault. Please replenish. Currently R{vault.CurrentAmount} left.");
            }

            transaction.RequisitionId = requisitionId;
            transaction.Amount = cashAmount * -1;
            transaction.TransactionDate = DateTime.Now;
            transaction.TransactionType = typesOfTransaction.Withdrawal;
            transaction.VaultId = 1;

            vault.CurrentAmount += transaction.Amount;
            await _vault.Edit(vault);

            _db.Transactions.Add(transaction);

            if (await _db.SaveChangesAsync() == 0)
                throw new DbUpdateException("System could not add the new withdrawal.");

            return "System has successfully recorded the withdrawal.";
        }
    }
}

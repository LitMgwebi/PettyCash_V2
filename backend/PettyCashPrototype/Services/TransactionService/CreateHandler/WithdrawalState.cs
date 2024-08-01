namespace PettyCashPrototype.Services.TransactionService.CreateHandler
{
    public class WithdrawalState: ICreateTransaction
    {
        private PettyCashPrototypeContext _db;
        private Transaction transaction;
        private readonly decimal cashAmount;
        private readonly int requisitionId;
        private IVault _vault;
        public WithdrawalState(PettyCashPrototypeContext db, IVault vault, Transaction transaction, decimal cashAmount, int requisitionId)
        {
            _db = db;
            _vault = vault;
            this.transaction = transaction;
            this.cashAmount = cashAmount;
            this.requisitionId = requisitionId;
        }

        public async Task<string> CreateTransaction()
        {
            transaction.RequisitionId = requisitionId;
            transaction.Amount = cashAmount * -1;
            transaction.TransactionDate = DateTime.Now;
            transaction.TransactionType = typesOfTransaction.Withdrawal;
            transaction.VaultId = 1;

            Vault vault = await _vault.GetOne(transaction.VaultId);
            vault.CurrentAmount += transaction.Amount;
            await _vault.Edit(vault);

            _db.Transactions.Add(transaction);
            if (await _db.SaveChangesAsync() == 0)
                throw new DbUpdateException("System could not add new transaction.");

            return "System has successfully recorded the withdrawal.";
        }
    }
}

namespace PettyCashPrototype.Services.TransactionService.CreateHandler
{
    public class ChangeState: ICreateTransaction
    {
        private PettyCashPrototypeContext _db;
        private IVault _vault;
        private Vault vault;
        private Transaction transaction;
        private readonly decimal cashAmount;
        private readonly int requisitionId;
        public ChangeState(PettyCashPrototypeContext db, IVault _vault, Vault vault, Transaction transaction, decimal cashAmount, int requisitionId)
        {
            this.transaction = transaction;
            this.cashAmount = cashAmount;
            _db = db;
            this._vault = _vault;
            this.vault = vault;
            this.requisitionId = requisitionId;
        }

        public async Task<string> CreateTransaction()
        {
            transaction.RequisitionId = requisitionId;
            transaction.Amount = cashAmount;
            transaction.TransactionDate = DateTime.Now;
            transaction.TransactionType = typesOfTransaction.Change;
            transaction.VaultId = 1;

            vault.CurrentAmount += transaction.Amount;
            await _vault.Edit(vault);

            _db.Transactions.Add(transaction);

            if (await _db.SaveChangesAsync() == 0)
                throw new DbUpdateException("System could not register your change. Please contact ICT.");

            return "System has successfully recorded the deposit of change.";
        }
    }
}

using PettyCashPrototype.Services.TransactionService.CreateHandler;

namespace PettyCashPrototype.Services.TransactionService
{
    public class TransactionService : ITransaction
    {
        private PettyCashContext _db;
        private IVault _vault;
        public TransactionService(PettyCashContext db, IVault vault)
        {
            _db = db;
            _vault = vault;
        }

        public async Task<IEnumerable<Transaction>> GetAll(string type = "")
        {
            try
            {
                IEnumerable<Transaction> transactions = new List<Transaction>();

                if (type == typesOfTransaction.Withdrawal)
                {
                    transactions = await _db.Transactions
                    .Include(d => d.Depositor)
                    .Include(r => r.Requisition)
                    .ThenInclude(a => a!.Applicant)
                    .Include(v => v.Vault)
                    .Where(x => x.IsActive == true)
                    .Where(t => t.TransactionType == typesOfTransaction.Withdrawal)
                    .OrderByDescending(o => o.TransactionDate)
                    .AsNoTracking()
                    .ToListAsync();
                }
                else if (type == typesOfTransaction.Deposit)
                {
                    transactions = await _db.Transactions
                    .Include(d => d.Depositor)
                    .Include(r => r.Requisition)
                    .ThenInclude(a => a!.Applicant)
                    .Include(v => v.Vault)
                    .Where(t => t.TransactionType == typesOfTransaction.Deposit)
                    .Where(x => x.IsActive == true)
                    .OrderByDescending(o => o.TransactionDate)
                    .AsNoTracking()
                    .ToListAsync();
                }
                else if (type == typesOfTransaction.Change)
                {
                    transactions = await _db.Transactions
                    .Include(d => d.Depositor)
                    .Include(r => r.Requisition)
                    .ThenInclude(a => a!.Applicant)
                    .Include(v => v.Vault)
                    .Where(t => t.TransactionType == typesOfTransaction.Change)
                    .Where(x => x.IsActive == true)
                    .OrderByDescending(o => o.TransactionDate)
                    .AsNoTracking()
                    .ToListAsync();
                }
                else if (type == typesOfTransaction.All)
                {
                    transactions = await _db.Transactions
                    .Include(d => d.Depositor)
                    .Include(r => r.Requisition)
                    .ThenInclude(a => a!.Applicant)
                    .Include(v => v.Vault)
                    .Where(x => x.IsActive == true)
                    .OrderByDescending(o => o.TransactionDate)
                    .AsNoTracking()
                    .ToListAsync();
                }

                if (transactions == null)
                    throw new Exception("System could not find any transactions.");

                return transactions;
            }
            catch { throw; }
        }

        public async Task<Transaction> GetOne(int transactionId)
        {
            try
            {
                Transaction transaction = await _db.Transactions
                    .Include(d => d.Depositor)
                    .Include(r => r.Requisition)
                    .ThenInclude(a => a.Applicant)
                    .Include(v => v.Vault)
                    .Where(x => x.IsActive == true)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(i => i.TransactionId == transactionId);

                if (transaction == null)
                    throw new Exception("System could not retrieve the transaction.");
                return transaction;
            }
            catch { throw; }
        }

        public async Task<string> Create(decimal cashAmount, string type, int requisitionId, string note, string userId)
        {
            try
            {
                Vault vault = await _vault.GetOne(1);
                Transaction transaction = new Transaction();
                transaction.Note = note;
                CreateTransactionHandler createTransactionHandler = new CreateTransactionHandler();
                string message = string.Empty;

                if (type == typesOfTransaction.Withdrawal)
                {
                    createTransactionHandler.setState(new WithdrawalState(_db, _vault, vault, transaction, cashAmount, requisitionId));
                    message = await createTransactionHandler.request();
                }
                else if (type == typesOfTransaction.Deposit)
                {
                    createTransactionHandler.setState(new DepositState(_db, _vault, vault, transaction, cashAmount, userId, requisitionId));
                    message = await createTransactionHandler.request();
                }
                else if (type == typesOfTransaction.Change)
                {
                    createTransactionHandler.setState(new ChangeState(_db, _vault, vault, transaction, cashAmount, requisitionId));
                    message = await createTransactionHandler.request();
                }
                else
                    throw new Exception("System was unable to resolve type of transaction. Please contact ICT.");

                return message;
            }
            catch { throw; }
        }

        public async Task Edit(Transaction transaction)
        {
            try
            {
                _db.Transactions.Update(transaction);
                if (await _db.SaveChangesAsync() == 0)
                    throw new DbUpdateException($"System could not add edit transaction #{transaction.TransactionId}.");
            }
            catch { throw; }
        }

        public async Task SoftDelete(Transaction transaction)
        {
            try
            {
                transaction.IsActive = false;
                _db.Transactions.Update(transaction);
                if (await _db.SaveChangesAsync() == 0)
                    throw new DbUpdateException($"System could not add delete transaction #{transaction.TransactionId}.");
            }
            catch { throw; }
        }
    }
}

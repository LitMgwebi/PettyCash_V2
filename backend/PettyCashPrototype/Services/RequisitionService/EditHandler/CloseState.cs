namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class CloseState : IEditState
    {
        private PettyCashPrototypeContext _db;
        private Requisition requisition;
        private ITransaction _transaction;
        public CloseState(PettyCashPrototypeContext db, ITransaction transaction, Requisition requisition)
        {
            _transaction = transaction;
            this.requisition = requisition;
            _db = db;
        }

        public async Task<string> EditRequisition()
        {
            if (requisition.TotalExpenses <= requisition.CashIssued)
            {
                requisition.CloseDate = DateTime.Now;
                requisition.Stage = "Change has been brought back to Accounts Payable and requisition is closed.";

                _db.Requisitions.Update(requisition);
                int result = await _db.SaveChangesAsync();

                if (result == 0) throw new DbUpdateException($"System could not edit the requisition for {requisition.Applicant!.FullName}.");

                await _transaction.Create((decimal)requisition.Change!, typesOfTransaction.Deposit, requisition.RequisitionId, $"{requisition.Applicant!.FullName} has brought back the change for their petty cash requisition.");

                return "Requisition has been closed.";
            }
            else
                throw new Exception("You entered in expenses that are higher than the issued cash. Please reenter amount.");
        }
    }
}

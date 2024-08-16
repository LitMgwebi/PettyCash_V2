namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class CloseState : IEditState
    {
        private ITransaction _transaction;
        public CloseState(ITransaction transaction)
        {
            _transaction = transaction;
        }

        public async Task<string> EditRequisition(PettyCashPrototypeContext _db, Requisition requisition)
        {
            if (requisition.TotalExpenses <= requisition.CashIssued)
            {
                requisition.CloseDate = DateTime.Now;
                //requisition.Status = "Closed";
                requisition.Stage = "Change has been brought back to Accounts Payable and requisition is closed.";

                await _transaction.Create((decimal)requisition.Change!, typesOfTransaction.Deposit, requisition.RequisitionId, $"{requisition.Applicant!.FullName} has brought back the change for their petty cash requisition.");

                _db.Requisitions.Update(requisition);
                int result = await _db.SaveChangesAsync();

                if (result == 0) throw new DbUpdateException($"System could not edit the requisition for {requisition.Applicant!.FullName}.");

                return "Requisition has been closed.";
            }
            else
                throw new Exception("You entered in expenses that are higher than the issued cash. Please reenter amount.");
        }
    }
}

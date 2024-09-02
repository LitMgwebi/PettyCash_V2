namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class ReturnedState : IEditState
    {
        public async Task<string> EditRequisition(PettyCashPrototypeContext _db, Requisition requisition)
        {
            if (requisition.ReceiptReceived == true && requisition.TotalExpenses != null)
            {
                requisition.Stage = "The receipts and total expenses for this requisition have been recorded. Please provide change to Accounts Payable.";
                requisition.State = null;
                requisition.StateId = 8;
                requisition.ReceiptReceived = true;

                _db.Requisitions.Update(requisition);
                int result = await _db.SaveChangesAsync();

                if (result == 0) throw new DbUpdateException($"System could not record the return of the change and receipts. Please contact ICT.");

                return "System has recorded your expenses and recipt/s. Please provide change to Accounts Payable.";
            }
            else
                throw new Exception("System can not handle this change. It seems you have no uploaded receipts and have not recorded your total expenses.");
        }
    }
}

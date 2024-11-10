
namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class ExpensesState: IEditState
    {
        public async Task<string> EditRequisition(PettyCashContext _db, Requisition requisition)
        {
            if (requisition.TotalExpenses <= requisition.CashIssued)
            {
                requisition.Change = requisition.CashIssued - requisition.TotalExpenses;
                requisition.Stage = "Total Expenses has been recorded. Please upload the receipt/s.";

                _db.Requisitions.Update(requisition);
                int result = await _db.SaveChangesAsync();

                if (result == 0) throw new DbUpdateException($"System could not add the expenses to requisition #{requisition.RequisitionId}.");

                return "Expenses have been added to the requisition.";
            } else
                throw new Exception("You entered in expenses that are higher than the issued cash. Please reenter amount.");
        }
    }
}

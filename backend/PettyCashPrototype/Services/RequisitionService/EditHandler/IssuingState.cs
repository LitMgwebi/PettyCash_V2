namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class IssuingState : IEditState
    {
        private readonly Requisition requisition;
        private string userId;
        private ITransaction _transaction;
        private PettyCashPrototypeContext _db;
        private readonly int attemptCode;

        public IssuingState(PettyCashPrototypeContext db, ITransaction transaction, Requisition requisition, string userId, int attemptCode)
        {
            this.requisition = requisition;
            this.userId = userId;
            _db = db;
            _transaction = transaction;
            this.attemptCode = attemptCode;
        }


        public async Task<string> EditRequisition()
        {
            if (attemptCode != requisition.ApplicantCode)
                throw new Exception("Applicant code is incorrect. Please review your code then enter it again.");

            requisition.IssueDate = DateTime.Now;
            requisition.IssuerId = userId;
            requisition.ConfirmApplicantCode = true;
            requisition.Stage = "Petty Cash has been issued. Please bring back change and receipt as soon as possible.";

            await _transaction.Create((decimal)requisition.CashIssued!, typesOfTransaction.Withdrawal, requisition.RequisitionId, $"Petty Cash has been issued to {requisition.Applicant!.FullName}");

            _db.Requisitions.Update(requisition);
            int result = await _db.SaveChangesAsync();

            if (result == 0) throw new DbUpdateException($"System could not update the requisition for {requisition.Applicant!.FullName}.");

            return "Issuing of Petty Cash has taken place.";
        }

    }
}

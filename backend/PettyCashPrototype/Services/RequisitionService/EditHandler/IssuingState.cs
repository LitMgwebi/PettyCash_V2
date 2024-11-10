namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class IssuingState : IEditState
    {
        private string userId;
        private ITransaction _transaction;
        private readonly int attemptCode;

        public IssuingState(ITransaction transaction, string userId, int attemptCode)
        {
            this.userId = userId;
            _transaction = transaction;
            this.attemptCode = attemptCode;
        }


        public async Task<string> EditRequisition(PettyCashContext _db, Requisition requisition)
        {
            if (requisition.FinanceApprovalId == 2)
                throw new Exception("This requisition has already been declined by finance.");
            else if (requisition.ManagerRecommendationId == 4)
                throw new Exception("This requisition has already been rejected by their line manager.");

            if (attemptCode != requisition.ApplicantCode)
                throw new Exception("Applicant code is incorrect. Please review your code then enter it again.");

            /*
             Add email code here to be sent to the applicant informing them that the money has
             */

            requisition.IssueDate = DateTime.Now;
            requisition.IssuerId = userId;
            requisition.ConfirmApplicantCode = true;
            requisition.StateId = 7;
            requisition.Stage = "Petty Cash has been issued. Please bring back change and receipt as soon as possible.";

            await _transaction.Create((decimal)requisition.CashIssued!, typesOfTransaction.Withdrawal, requisition.RequisitionId, $"Petty Cash has been issued to {requisition.Applicant!.FullName}");

            _db.Requisitions.Update(requisition);
            int result = await _db.SaveChangesAsync();

            if (result == 0) throw new DbUpdateException($"System could not update the requisition for {requisition.Applicant!.FullName}.");

            return "Issuing of Petty Cash has taken place.";
        }

    }
}

namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class ApprovalState : IEditState
    {
        private readonly Requisition reviewRequisition;
        private string userId;
        public ApprovalState(Requisition reviewRequisition, string userId)
        {
            this.reviewRequisition = reviewRequisition;
            this.userId = userId;
        }

        public async Task<string> EditRequisition(PettyCashPrototypeContext _db, Requisition requisition)
        {
            string message = string.Empty;
            if (reviewRequisition.FinanceApproval == null)
            {
                Random code = new Random();
                requisition.FinanceOfficerId = userId;
                requisition.FinanceApprovalDate = DateTime.Now;
                /*
                    Email code will be sent to applicant 
                The result of the approval will be added to the email within the if statments, then will be sent after the DB check

                    if(approved)
                        state users code. send email to accounts payable about the new requisition added and the amount and applicant
                    if(declined)
                        stating the stage of their requisition
                 */

                if (requisition.FinanceApprovalId == 1)
                {
                    requisition.ApplicantCode = code.Next(10000, 99999);
                    requisition.Stage = "Finance has approved this requisition. Go to Finance to retrieve the petty cash. Don't forget your applicant code.";
                    message = "The approval has been saved to the system.";
                }
                else if (requisition.FinanceApprovalId == 2)
                {
                    requisition.Stage = "Finance has declined this requisition.";
                    message = "The choice to decline the requisition has been saved to the system.";
                }
                _db.Requisitions.Update(requisition);
                int result = await _db.SaveChangesAsync();

                if (result == 0) throw new DbUpdateException($"System could not edit the requisition for {requisition.Applicant!.FullName}.");
                return message;
            }
            else
            {
                throw new Exception($"This requisition has already been reviewed by {reviewRequisition.FinanceOfficer!.FullName}.");
            }
        }
    }
}

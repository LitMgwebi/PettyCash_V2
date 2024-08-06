namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class ApprovalState : IEditState
    {
        private readonly Requisition reviewRequisition;
        private readonly Requisition requisition;
        private string userId;
        private PettyCashPrototypeContext _db;
        public ApprovalState(PettyCashPrototypeContext db, Requisition reviewRequisition, Requisition requisition, string userId)
        {
            this.reviewRequisition = reviewRequisition;
            this.requisition = requisition;
            this.userId = userId;
            _db = db;
        }

        public async Task<string> EditRequisition()
        {
            string message = string.Empty;
            if (reviewRequisition.FinanceApproval == null)
            {
                Random code = new Random();
                requisition.ApplicantCode = code.Next(10000, 99999);
                requisition.FinanceOfficerId = userId;
                requisition.FinanceApprovalDate = DateTime.Now;

                if (requisition.FinanceApprovalId == 1)
                {
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

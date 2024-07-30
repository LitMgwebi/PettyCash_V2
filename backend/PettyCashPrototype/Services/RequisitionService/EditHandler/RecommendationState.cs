namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class RecommendationState : IEditState
    {
        private readonly Requisition reviewRequisition;
        private readonly Requisition requisition;
        private string userId;
        private PettyCashPrototypeContext _db;
        public RecommendationState(PettyCashPrototypeContext db, Requisition reviewRequisition, Requisition requisition, string userId)
        {
            this.reviewRequisition = reviewRequisition;
            this.requisition = requisition;
            this.userId = userId;
            _db = db;
        }

        public async Task<string> EditRequisition()
        {
            /*
             * There has to code here which is used to send emails to the applicant and the specific Financial Auth
             * 
             * First - Implement dependency injection betweeen this class and IUser
             * Second - Determine which threshold the amountRequested by the user falls unders
             * Third - Set a user variable to a finance person who will be authorising based on the threshold of amountRequested
             * Fourth - Pass the user's email address through the email API to tell user about the recommended requisition
             * 
             */
            if (reviewRequisition.ManagerRecommendation == null)
            {
                requisition.ManagerId = userId;
                requisition.ManagerRecommendationDate = DateTime.UtcNow;
                string message = string.Empty;

                if (requisition.ManagerRecommendationId == 4)
                {
                    requisition.Stage = "Your requisition has been rejected.";
                    message = "The rejection has been saved to system.";
                }
                else if (requisition.ManagerRecommendationId == 3)
                {
                    requisition.Stage = "Your requisition has been recommended. Awaiting Finance Approval.";
                    message = "The recommendation has ben saved to system";
                }
                _db.Requisitions.Update(requisition);
                int result = await _db.SaveChangesAsync();

                if (result == 0) throw new DbUpdateException($"System could not edit the requisition for {requisition.Applicant!.FullName}.");

                return message;
            }
            else { throw new Exception($"This requisition has already been reviewed by {reviewRequisition.Manager!.FullName}."); }
        }
    }
}

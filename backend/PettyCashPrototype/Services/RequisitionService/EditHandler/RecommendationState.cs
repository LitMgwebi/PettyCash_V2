namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class RecommendationState : IEditState
    {
        private readonly Requisition reviewRequisition;
        private string userId;
        public RecommendationState(Requisition reviewRequisition, string userId)
        {
            this.reviewRequisition = reviewRequisition;
            this.userId = userId;
        }

        public async Task<string> EditRequisition(PettyCashPrototypeContext _db, Requisition requisition)
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
                requisition.ManagerRecommendationDate = DateTime.Now;
                string message = string.Empty;

                if (requisition.ManagerRecommendationId == 4)
                {
                    requisition.Stage = "This requisition has been rejected.";
                    requisition.CloseDate = DateTime.Now;
                    requisition.StateId = 9;
                    //requisition.Status = "Closed";
                    message = "The rejection has been saved to system.";
                }
                else if (requisition.ManagerRecommendationId == 3)
                {
                    requisition.Stage = "This requisition has been recommended. Awaiting Finance Approval.";
                    message = "The recommendation has been saved to system.";
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

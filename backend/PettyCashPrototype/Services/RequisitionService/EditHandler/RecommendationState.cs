namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class RecommendationState: IEditState
    {
        public async Task<string> EditRequisition(IRequisition service, Requisition requisition, string userId)
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
            Requisition reviewRequisition = await service.GetOne(requisition.RequisitionId);
            if (reviewRequisition.ManagerRecommendation == null)
            {
                requisition.ManagerId = userId;
                requisition.ManagerRecommendationDate = DateTime.UtcNow;

                if (requisition.ManagerRecommendationId == 4)
                    requisition.Stage = "Your requisition has been rejected.";
                else if (requisition.ManagerRecommendationId == 3)
                    requisition.Stage = "Your requisition has been recommended. Awaiting Finance Approval.";

                service.Edit(requisition);
                return "Your choice has been recorded.";
            } else { throw new Exception($"This requisition has already been reviewed by {reviewRequisition.Manager!.FullName}."); }
        }
    }
}

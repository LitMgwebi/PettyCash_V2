namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class ManagerRecommendationState: IEditState
    {
        public string EditRequisition(IRequisition service, Requisition requisition, string userId)
        {
            requisition.ManagerId = userId;
            requisition.ManagerRecommendationDate = DateTime.UtcNow;

            if (requisition.ManagerRecommendationId == 4)
                requisition.Stage = "Your requisition has been rejected.";
            else if (requisition.ManagerRecommendationId == 3)
                requisition.Stage = "Your requisition has been recommended. Awaiting Finance Approval.";

            service.Edit(requisition);
            return "Your choice has been recorded.";
        }
    }
}

namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class ManagerRecommendationState: IEditState
    {
        public string EditRequisition(IRequisition service, Requisition requisition, string userId)
        {
            requisition.ManagerId = userId;
            requisition.ManagerRecommendationDate = DateTime.UtcNow;

            if (requisition.ManagerRecommendationId == 4)
                requisition.Stage = "Line manager has not recommended this requisition.";
            else if (requisition.ManagerRecommendationId == 3)
                requisition.Stage = "Line manager has recommended this requisition. Awaiting Finance Approval.";

            service.Edit(requisition);
            return "Your recommendation has been added to the system.";
        }
    }
}

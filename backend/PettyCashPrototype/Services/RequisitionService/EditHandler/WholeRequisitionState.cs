namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class WholeRequisitionState : IEditState
    {
        public async Task<string> EditRequisition(IRequisition service, Requisition requisition, string userId)
        {
            if (requisition.ManagerRecommendationId == null)
            {
                service.Edit(requisition);
                return "The requisition has been edited.";
            }
            else
            {
                throw new Exception("You cannot edit a requisition after recommendation.");
            }
        }
    }
}

namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class WholeRequisitionState : IEditState
    {
        private readonly IRequisition service;
        private readonly Requisition requisition;
        public WholeRequisitionState(IRequisition service, Requisition requisition)
        {
            this.service = service;
            this.requisition = requisition;
        }

        public async Task<string> EditRequisition()
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

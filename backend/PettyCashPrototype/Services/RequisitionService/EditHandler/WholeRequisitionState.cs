namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class WholeRequisitionState: IEditState
    {
        public string EditRequisition(IRequisition service, Requisition requisition, string userId)
        {
            service.Edit(requisition);
            return "The requisition has been edited.";
        }
    }
}

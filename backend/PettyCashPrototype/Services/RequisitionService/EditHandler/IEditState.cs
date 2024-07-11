namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public interface IEditState
    {
        string EditRequisition(IRequisition service, Requisition requisition, string userId);
    }
}

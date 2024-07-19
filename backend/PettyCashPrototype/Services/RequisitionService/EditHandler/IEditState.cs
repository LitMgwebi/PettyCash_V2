namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public interface IEditState
    {
        Task<string> EditRequisition(IRequisition service, Requisition requisition, string userId);
    }
}

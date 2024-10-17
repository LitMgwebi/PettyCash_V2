namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public interface IEditState
    {
        Task<string> EditRequisition(PettyCashPrototypeContext db, Requisition requisition);
    }
}

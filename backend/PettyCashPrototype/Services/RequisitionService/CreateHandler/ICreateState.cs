namespace PettyCashPrototype.Services.RequisitionService.CreateHandler
{
    public interface ICreateState
    {
        public Task<string> CreateRequisition(PettyCashPrototypeContext db, Requisition requisition, string userId);
    }
}

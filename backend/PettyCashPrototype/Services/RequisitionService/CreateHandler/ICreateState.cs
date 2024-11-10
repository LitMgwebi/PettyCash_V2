namespace PettyCashPrototype.Services.RequisitionService.CreateHandler
{
    public interface ICreateState
    {
        public Task<string> CreateRequisition(PettyCashContext db, Requisition requisition, string userId);
    }
}

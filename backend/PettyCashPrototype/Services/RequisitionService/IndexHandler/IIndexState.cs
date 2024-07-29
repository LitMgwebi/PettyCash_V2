namespace PettyCashPrototype.Services.RequisitionService.IndexHandler
{
    public interface IIndexState
    {
        Task<IEnumerable<Requisition>> GetRequisitions();
    }
}

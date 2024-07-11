namespace PettyCashPrototype.Services.RequisitionService.IndexHandler
{
    public interface IIndexState
    {
        Task<IEnumerable<Requisition>> GetRequisitions(PettyCashPrototypeContext db, int divisionId, int jobTitleId, IJobTitle _jobTitle, string userId);
    }
}

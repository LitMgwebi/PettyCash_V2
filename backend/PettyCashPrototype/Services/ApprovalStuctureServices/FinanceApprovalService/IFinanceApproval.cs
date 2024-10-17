namespace PettyCashPrototype.Services.ApprovalStuctureServices.FinanceApprovalService
{
    public interface IFinanceApproval
    {
        Task<IEnumerable<Requisition>> GetRequisitionsForApproval(string jobTitle);
        void SetNext(IFinanceApproval financeOfficer);
    }
}

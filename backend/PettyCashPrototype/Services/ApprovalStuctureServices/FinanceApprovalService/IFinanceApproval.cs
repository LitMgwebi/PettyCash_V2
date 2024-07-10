namespace PettyCashPrototype.Services.ApprovalStuctureServices.FinanceApprovalService
{
    public interface IFinanceApproval
    {
        Task<IEnumerable<Requisition>> GetRequisitions(string jobTitle);
        void SetNext(IFinanceApproval financeOfficer);
    }
}

using PettyCashPrototype.Services.ApprovalStuctureServices.FinanceApprovalService;

namespace PettyCashPrototype.Services.RequisitionService.IndexHandler
{
    public class GetForApprovalState : IIndexState
    {
        private readonly int divisionId;
        private readonly int jobTitleId;
        private readonly IJobTitle _jobTitle;
        private readonly string userId;

        public GetForApprovalState(int divisionId, int jobTitleId, IJobTitle _jobTitle, string userId)
        {
            this.divisionId = divisionId;
            this.jobTitleId = jobTitleId;
            this._jobTitle = _jobTitle;
            this.userId = userId;
        }

        public async Task<IEnumerable<Requisition>> GetRequisitions(PettyCashContext db)
        {
            JobTitle jobTitle = await _jobTitle.GetOne(jobTitleId);
            IEnumerable<Requisition> requisitions = new List<Requisition>();
            if (divisionId == 6)
            {

                IFinanceApproval Deputy = new Deputy(db, userId);
                IFinanceApproval Manager = new Manager(db);
                IFinanceApproval CFO = new CFO(db);

                CFO.SetNext(Manager);
                Manager.SetNext(Deputy);

                requisitions = await CFO.GetRequisitionsForApproval(jobTitle.Description);
            }
            else
                throw new Exception("You have to be in the Finance Department to approve of this requisitions.");
            return requisitions;
        }
    }
}

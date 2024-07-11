using PettyCashPrototype.Services.ApprovalStuctureServices.FinanceApprovalService;

namespace PettyCashPrototype.Services.RequisitionService.IndexHandler
{
    public class GetForApprovalState: IIndexState
    {
        public async Task<IEnumerable<Requisition>> GetRequisitions(PettyCashPrototypeContext db, int divisionId, int jobTitleId, IJobTitle _jobTitle, string userId)
        {
            JobTitle jobTitle = await _jobTitle.GetOne(jobTitleId);
            IEnumerable<Requisition> requisitions = new List<Requisition>();
            if (divisionId == 6)
            {

                IFinanceApproval Deputy = new Deputy(db);
                IFinanceApproval Manager = new Manager(db);
                IFinanceApproval CFO = new CFO(db);

                CFO.SetNext(Manager);
                Manager.SetNext(Deputy);

                requisitions = await CFO.GetRequisitions(jobTitle.Description);
            }
            else
                throw new Exception("You have to be in the Finance Department to approve of this requisitions.");

            if (requisitions == null) throw new Exception("System could not find any requisitions.");
            return requisitions;
        }
    }
}

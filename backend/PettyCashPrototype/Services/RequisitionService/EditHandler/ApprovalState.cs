namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class ApprovalState : IEditState
    {
        public string EditRequisition(IRequisition service, Requisition requisition, string userId)
        {
            requisition.FinanceOfficerId = userId;
            requisition.FinanceApprovalDate = DateTime.UtcNow;

            if (requisition.FinanceApprovalId == 1)
                requisition.Stage = "Finance has approved this requisition.";
            else if (requisition.FinanceApprovalId == 2)
                requisition.Stage = "Finance has declined this requisition";

            service.Edit(requisition);
            return "Your choice has been recorded.";
        }
    }
}

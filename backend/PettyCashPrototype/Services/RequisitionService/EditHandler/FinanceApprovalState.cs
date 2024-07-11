namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class FinanceApprovalState: IEditState
    {
        public string EditRequisition(IRequisition service, Requisition requisition, string userId)
        {
            requisition.FinanceOfficerId = userId;
            requisition.FinanceApprovalDate = DateTime.UtcNow;

            if (requisition.FinanceApprovalId == 1)
                requisition.Stage = "Finance has approved of this requisition.";
            else if (requisition.FinanceApprovalId == 2)
                requisition.Stage = "Finance has declined of this requisition";

            service.Edit(requisition);
            return "Your approval has been recorded by the system.";
        }
    }
}

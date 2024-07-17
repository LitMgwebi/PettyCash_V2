namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class FinanceApprovalState: IEditState
    {
        public string EditRequisition(IRequisition service, Requisition requisition, string userId)
        {
            if(requisition.FinanceOfficerId == null)
            {
                requisition.FinanceOfficerId = userId;
                requisition.FinanceApprovalDate = DateTime.UtcNow;

                if (requisition.FinanceApprovalId == 1)
                    requisition.Stage = "Finance has approved this requisition.";
                else if (requisition.FinanceApprovalId == 2)
                    requisition.Stage = "Finance has declined this requisition";

                service.Edit(requisition);
                return "Your choice has been recorded.";
            } else
            {
                throw new Exception($"This request has already been dealt with by: {requisition.FinanceOfficer!.FullName}");
            }
        }
    }
}

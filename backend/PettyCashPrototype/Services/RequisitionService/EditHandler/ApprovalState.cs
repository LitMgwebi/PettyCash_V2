namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class ApprovalState : IEditState
    {
        public async Task<string> EditRequisition(IRequisition service, Requisition requisition, string userId)
        {
            Requisition reviewReq = await service.GetOne(requisition.RequisitionId);
            if (reviewReq.FinanceApproval == null)
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
                throw new Exception($"This requisition has already been reviewed by { reviewReq.FinanceOfficer!.FullName }.");
            }
        }
    }
}

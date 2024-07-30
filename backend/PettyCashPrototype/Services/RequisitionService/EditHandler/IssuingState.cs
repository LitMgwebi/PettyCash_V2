namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class IssuingState: IEditState
    {
        private readonly Requisition requisition;
        private string userId;
        private PettyCashPrototypeContext _db;
        private readonly int attemptCode;

        public IssuingState(PettyCashPrototypeContext db, Requisition requisition, string userId, int attemptCode)
        {
            this.requisition = requisition;
            this.userId = userId;
            _db = db;
            this.attemptCode = attemptCode;
        }


        public async Task<string> EditRequisition()
        {
            if (attemptCode != requisition.ApplicantCode)
                throw new Exception("Applicant code is incorrect. Please review your code then enter it again.");

            requisition.IssueDate = DateTime.Now;
            requisition.IssuerId = userId;
            requisition.ConfirmApplicantCode = true;

            _db.Requisitions.Update(requisition);
            int result = await _db.SaveChangesAsync();

            if (result == 0) throw new DbUpdateException($"System could not update the requisition for {requisition.Applicant!.FullName}.");

            return "";
        }
    }
}

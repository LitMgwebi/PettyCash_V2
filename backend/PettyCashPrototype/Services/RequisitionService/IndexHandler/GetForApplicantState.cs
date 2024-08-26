namespace PettyCashPrototype.Services.RequisitionService.IndexHandler
{
    public class GetForApplicantState : IIndexState
    {
        private readonly string userId;
        private Status status;

        public GetForApplicantState(string userId, Status status)
        {
            this.userId = userId;
            this.status = status;
        }
        public async Task<IEnumerable<Requisition>> GetRequisitions(PettyCashPrototypeContext db)
        {
            IEnumerable<Requisition> requisitions = new List<Requisition>();

            if (status != null)
            {
                requisitions = await db.Requisitions
                    .Include(gl => gl.Glaccount)
                    .Include(a => a.Applicant)
                    .Include(mr => mr.ManagerRecommendation)
                    .Include(mr => mr.FinanceApproval)
                    .Include(i => i.Issuer)
                    .Where(a => a.ApplicantId == userId)
                    .Where(a => a.IsActive == true)
                    .Where(s => s.State! == status)
                    .AsNoTracking()
                    .ToListAsync();
                //if (status.Description == "In Process")
                //{
                //    //TODO Test if the "In process" state is reflected properly
                //    requisitions = await db.Requisitions
                //        .Include(gl => gl.Glaccount)
                //        .Where(a => a.ApplicantId == userId)
                //        .Include(a => a.Applicant)
                //        .Where(a => a.IsActive == true)
                //        .Where(c => c.FinanceApprovalId == null && c.CloseDate == null)
                //        .AsNoTracking()
                //        .ToListAsync();
                //}
                //else if (status.Description == "Open")
                //{
                //    requisitions = await db.Requisitions
                //        .Include(gl => gl.Glaccount)
                //        .Where(a => a.ApplicantId == userId)
                //        .Include(a => a.Applicant)
                //        .Where(a => a.IsActive == true)
                //        .Where(c => c.FinanceApprovalId != null && c.IssueDate == null)
                //        .AsNoTracking()
                //        .ToListAsync();
                //}
                //else if (status.Description == "Issued")
                //{
                //    requisitions = await db.Requisitions
                //        .Include(gl => gl.Glaccount)
                //        .Where(a => a.ApplicantId == userId)
                //        .Include(a => a.Applicant)
                //        .Where(a => a.IsActive == true)
                //        .Where(c => c.IssuerId != null && c.ReceiptReceived == false)
                //        .AsNoTracking()
                //        .ToListAsync();
                //}else if (status.Description == "Returned")
                //{
                //    requisitions = await db.Requisitions
                //        .Include(gl => gl.Glaccount)
                //        .Where(a => a.ApplicantId == userId)
                //        .Include(a => a.Applicant)
                //        .Where(a => a.IsActive == true)
                //        .Where(c => c.ReceiptReceived == true && c.ConfirmChangeReceived == false)
                //        .AsNoTracking()
                //        .ToListAsync();
                //}
                //else if (status.Description == "Closed")
                //{
                //    requisitions = await db.Requisitions
                //        .Include(gl => gl.Glaccount)
                //        .Where(a => a.ApplicantId == userId)
                //        .Include(a => a.Applicant)
                //        .Where(a => a.IsActive == true)
                //        .Where(c => c.CloseDate != null)
                //        .AsNoTracking()
                //        .ToListAsync();
                //}
                //else
                //    throw new Exception("Status provided could not be processed by system. Please contact ICT");
            }
            else
                throw new Exception("Status was sent to server as null. Please contact ICT.");


            return requisitions;
        }
    }
}

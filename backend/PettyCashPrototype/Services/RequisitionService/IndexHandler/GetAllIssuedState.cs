namespace PettyCashPrototype.Services.RequisitionService.IndexHandler
{
    public class GetAllIssuedState: IIndexState
    {
        private readonly IUser _user = null!;
        private readonly string userId;
        private readonly string issueState;

        public GetAllIssuedState(IUser user, string userId, string issuedState)
        {
            _user = user;
            this.userId = userId;
            this.issueState = issuedState;
        }
        public async Task<IEnumerable<Requisition>> GetRequisitions(PettyCashPrototypeContext db)
        {
            User user = await _user.GetUserById(userId);
            IEnumerable<Requisition> requisitions = new List<Requisition>();
            if (user.JobTitle!.JobTitleId == 16)
            {
                if(issueState == issuedRequisitionState.Red)
                {
                    requisitions = await db.Requisitions
                        .Include(a => a.Applicant)
                        .Include(m => m.Manager)
                        .Include(f => f.FinanceOfficer)
                        .Include(gl => gl.Glaccount)
                        .Where(a => a.IsActive == true)
                        .Where(a => a.StateId == 7)
                        .Where(d => d.IssueDate!.Value.AddDays(1) < DateTime.Now)
                        .AsNoTracking()
                        .ToListAsync();
                } else if (issueState == issuedRequisitionState.Green)
                {
                    requisitions = await db.Requisitions
                        .Include(a => a.Applicant)
                        .Include(m => m.Manager)
                        .Include(f => f.FinanceOfficer)
                        .Include(gl => gl.Glaccount)
                        .Where(a => a.IsActive == true)
                        .Where(d => d.IssueDate!.Value.AddDays(1) > DateTime.Now)
                        .Where(a => a.StateId == 7)
                        .AsNoTracking()
                        .ToListAsync();
                }
            }
            else
            {
                throw new Exception("You have to be an Accounts Payable to view the requisitions that require issuing.");
            }
            return requisitions;
        }
    }
}

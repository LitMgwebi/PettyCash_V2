namespace PettyCashPrototype.Services.RequisitionService.IndexHandler
{
    public class GetForRecommendationState : IIndexState
    {
        private readonly string userId;
        private readonly string role;
        private readonly IUser _user = null!;

        public GetForRecommendationState(IUser user, string userId, string role)
        {
            _user = user;
            this.userId = userId;
            this.role = role;
        }
        public async Task<IEnumerable<Requisition>> GetRequisitions(PettyCashPrototypeContext db)
        {
            IEnumerable<Requisition> requisitions = new List<Requisition>();
            User user = await _user.GetUserById(userId);

            if (user.JobTitle!.Description.Contains("GM") || user.JobTitle!.JobTitleId == 13)
            {
                requisitions = await db.Requisitions
                    .Include(a => a.Applicant)
                    .Include(m => m.Documents)
                    .Include(gl => gl.Glaccount)
                    .Where(nm => (nm.NeedsMotivation == true && nm.Documents.Count > 0) || nm.NeedsMotivation == false)
                    .Where(a => a.IsActive == true)
                    .Where(u => u.Applicant!.Id != user.Id)
                    .Where(d => d.Applicant!.JobTitle!.JobTitleId == 7 && d.Applicant.Division!.DepartmentId == user.Division!.DepartmentId)
                    .Where(a => a.ManagerRecommendation == null && a.FinanceApproval == null)
                    .AsNoTracking()
                    .ToListAsync();
            }
            else if (user.JobTitle!.JobTitleId == 7 && user.DivisionId != 6)
            {
                requisitions = await db.Requisitions
                    .Include(a => a.Applicant)
                    .Include(m => m.Documents)
                    .Include(gl => gl.Glaccount)
                    .Where(a => a.IsActive == true)
                    .Where(u => u.Applicant!.Id != user.Id)
                    .Where(nm => (nm.NeedsMotivation == true && nm.Documents.Count > 0) || nm.NeedsMotivation == false)
                    .Where(d => d.Applicant!.DivisionId == user.DivisionId && d.Applicant!.JobTitle!.JobTitleId != 7)
                    .Where(a => a.ManagerRecommendation == null && a.FinanceApproval == null)
                    .AsNoTracking()
                    .ToListAsync();
            }
            else if (role == "Senior_Employee" && user.DivisionId == 6)
            {
                requisitions = await db.Requisitions
                    .Include(a => a.Applicant)
                    .Include(m => m.Documents)
                    .Include(gl => gl.Glaccount)
                    .Where(nm => (nm.NeedsMotivation == true && nm.Documents.Count > 0) || nm.NeedsMotivation == false)
                    .Where(a => a.IsActive == true)
                    .Where(u => u.Applicant!.Id != user.Id)
                    .Where(d => d.Applicant!.DivisionId == user.DivisionId)
                    .Where(a => a.ManagerRecommendation == null && a.FinanceApproval == null)
                    .AsNoTracking()
                    .ToListAsync();
            }
            return requisitions;
        }
    }
}

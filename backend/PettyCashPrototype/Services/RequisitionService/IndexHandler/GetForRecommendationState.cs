namespace PettyCashPrototype.Services.RequisitionService.IndexHandler
{
    public class GetForRecommendationState : IIndexState
    {
        private readonly IUser _user = null!;

        public GetForRecommendationState(IUser user) { _user = user; }
        public async Task<IEnumerable<Requisition>> GetRequisitions(PettyCashPrototypeContext db, int divisionId, int jobTitleId, IJobTitle _jobTitle, string userId, string role)
        {
            IEnumerable<Requisition> requisitions = new List<Requisition>();
            User user = await _user.GetUserById(userId);

            if (user.JobTitle!.Description.Contains("GM") || user.JobTitle!.JobTitleId == 13)
            {
                requisitions = await db.Requisitions
                    .Include(a => a.Applicant)
                    .Include(gl => gl.Glaccount)
                    .Where(a => a.IsActive == true)
                    .Where(d => d.Applicant!.JobTitle!.JobTitleId == 7 && d.Applicant.Division!.DepartmentId == user.Division!.DepartmentId)
                    .Where(a => a.ManagerRecommendation == null && a.FinanceApproval == null)
                    .AsNoTracking()
                    .ToListAsync();
            }
            else if (user.JobTitle!.JobTitleId == 7 && user.DivisionId != 6)
            {
                requisitions = await db.Requisitions
                    .Include(a => a.Applicant)
                    .Include(gl => gl.Glaccount)
                    .Where(a => a.IsActive == true)
                    .Where(d => d.Applicant!.DivisionId == user.DivisionId && d.Applicant!.JobTitle!.JobTitleId != 7)
                    .Where(a => a.ManagerRecommendation == null && a.FinanceApproval == null)
                    .AsNoTracking()
                    .ToListAsync();
            }
            else if (role == "Senior_Employee" && user.DivisionId == 6)
            {
                requisitions = await db.Requisitions
                    .Include(a => a.Applicant)
                    .Include(gl => gl.Glaccount)
                    .Where(a => a.IsActive == true)
                    .Where(d => d.Applicant!.DivisionId == user.DivisionId)
                    .Where(a => a.ManagerRecommendation == null && a.FinanceApproval == null)
                    .AsNoTracking()
                    .ToListAsync();
            }
            if (requisitions == null) throw new Exception("System could not find any requisitions.");
            return requisitions;
        }
    }
}

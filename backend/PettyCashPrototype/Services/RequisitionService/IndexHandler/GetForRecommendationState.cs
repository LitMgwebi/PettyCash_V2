namespace PettyCashPrototype.Services.RequisitionService.IndexHandler
{
    public class GetForRecommendationState : IIndexState
    {
        private readonly IUser _user = null!;

        public GetForRecommendationState(IUser user) { _user = user; }
        public async Task<IEnumerable<Requisition>> GetRequisitions(PettyCashPrototypeContext db, int divisionId, int jobTitleId, IJobTitle _jobTitle, string userId)
        {
            IEnumerable<Requisition> requisitions = new List<Requisition>();
            User user = await _user.GetUserById(userId);

            if (user.JobTitle!.Description.Contains("GM") || user.JobTitle!.Description == "General Manager")
            {
                requisitions = await db.Requisitions
                    .Include(a => a.Applicant)
                    .Where(a => a.IsActive == true)
                    .Where(d => d.Applicant!.JobTitle!.Description == "Manager" && d.Applicant.Division!.DepartmentId == user.Division!.DepartmentId)
                    .Where(a => a.ManagerRecommendation == null && a.FinanceApproval == null)
                    .ToListAsync();
            }
            else if (user.JobTitle!.Description == "Manager")
            {
                requisitions = await db.Requisitions
                    .Include(a => a.Applicant)
                    .Where(a => a.IsActive == true)
                    .Where(d => d.Applicant!.DivisionId == user.DivisionId && d.Applicant!.JobTitle!.Description != "Manager")
                    .Where(a => a.ManagerRecommendation == null && a.FinanceApproval == null)
                    .ToListAsync();
            } 
            //else if (user.JobTitle!.Description == "Bookkeeper" || user.JobTitle!.Description == "Accountant")
            //{
            //    requisitions = await db.Requisitions
            //        .Include(a => a.Applicant)
            //        .Where(a => a.IsActive == true)
            //        .Where(d => d.Applicant!.DivisionId == user.DivisionId && d.Applicant!.JobTitle!.Description != "Manager" && d.Applicant!.Division!.Description == "Finance")
            //        .Where(a => a.ManagerRecommendation == null && a.FinanceApproval == null)
            //        .ToListAsync();
            //}
            if (requisitions == null) throw new Exception("System could not find any requisitions.");
            return requisitions;
        }
    }
}

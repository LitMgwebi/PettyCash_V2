namespace PettyCashPrototype.Services.ApprovalStuctureServices.FinanceApprovalService
{
    public class Manager : IFinanceApproval
    {
        private IFinanceApproval? nextOfficer;
        private PettyCashContext _db;
        private string requiredTitle = "Manager";

        public Manager(PettyCashContext db)
        {
            _db = db;
        }


        public void SetNext(IFinanceApproval nextOfficer)
        {
            this.nextOfficer = nextOfficer;
        }


        public async Task<IEnumerable<Requisition>> GetRequisitionsForApproval(string jobTitle)
        {
            if (jobTitle == requiredTitle)
            {
                return await _db.Requisitions
                    .Include(a => a.Applicant)
                    .Include(gl => gl.Glaccount)
                    .Include(m => m.Manager)
                    .Include(mr => mr.ManagerRecommendation)
                    .Where(a => a.IsActive == true)
                    .Where(m => m.ManagerRecommendation != null && m.ManagerRecommendation.Description == "Recommended")
                    .Where(a => a.FinanceApproval == null)
                    .Where(ar => ar.AmountRequested < 1000 && ar.AmountRequested >= 500)
                    .AsNoTracking()
                    .ToListAsync();
            }
            else
            {
                if (nextOfficer != null)
                    return await nextOfficer!.GetRequisitionsForApproval(jobTitle);
                else
                    throw new Exception("Error on the Manager level");
            }
        }
    }
}

namespace PettyCashPrototype.Services.ApprovalStuctureServices.FinanceApprovalService
{
    public class CFO : IFinanceApproval
    {
        private IFinanceApproval? nextOfficer;
        private PettyCashPrototypeContext _db;
        private string requiredTitle = "CFO";

        public CFO(PettyCashPrototypeContext db)
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
                            .Include(m => m.Manager)
                            .Include(mr => mr.ManagerRecommendation)
                    .Include(gl => gl.Glaccount)
                            .Where(a => a.IsActive == true)
                            .Where(m => m.ManagerRecommendation != null && m.ManagerRecommendation.Description == "Recommended")
                            .Where(a => a.FinanceApproval == null)
                            .Where(am => am.AmountRequested >= 1000)
                    .AsNoTracking()
                            .ToListAsync();
            }
            else
            {
                if (nextOfficer != null)
                    return await nextOfficer!.GetRequisitionsForApproval(jobTitle);
                else
                    throw new Exception("Error on CFO level");
            }
        }
    }
}

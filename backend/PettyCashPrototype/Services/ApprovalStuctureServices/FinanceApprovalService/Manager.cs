namespace PettyCashPrototype.Services.ApprovalStuctureServices.FinanceApprovalService
{
    public class Manager : IFinanceApproval
    {
        private IFinanceApproval? nextOfficer;
        private PettyCashPrototypeContext _db;
        private string requiredTitle = "Manager";

        public Manager(PettyCashPrototypeContext db)
        {
            _db = db;
        }


        public void SetNext(IFinanceApproval nextOfficer)
        {
            this.nextOfficer = nextOfficer;
        }


        public async Task<IEnumerable<Requisition>> GetRequisitions(string jobTitle)
        {
            if (jobTitle == requiredTitle)
            {
                return await _db.Requisitions
                            .Include(a => a.Applicant)
                            .Include(m => m.Manager)
                            .Include(mr => mr.ManagerRecommendation)
                            .Where(a => a.IsActive == true)
                            .Where(m => m.ManagerRecommendation != null && m.ManagerRecommendation.Description == "Recommended")
                            .Where(a => a.FinanceApproval == null)
                            .Where(ar => ar.AmountRequested < 1000 && ar.AmountRequested > 500)
                            .ToListAsync();
            }
            else
            {
                if (nextOfficer != null)
                    return await nextOfficer!.GetRequisitions(jobTitle);
                else
                    throw new Exception("Error on the Manager level");
            }
        }
    }
}

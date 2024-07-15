namespace PettyCashPrototype.Services.ApprovalStuctureServices.FinanceApprovalService
{
    public class Deputy: IFinanceApproval
    {
        private IFinanceApproval nextOfficer = null!;
        private PettyCashPrototypeContext _db;
        private string requiredTitle = "Deputy";

        public Deputy(PettyCashPrototypeContext db)
        {
            _db = db;
        }


        public void SetNext(IFinanceApproval nextOfficer) { }


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
                            .Where(ar => ar.AmountRequested < 500)
                            .ToListAsync();
            }
            else
            {
                if (nextOfficer != null)
                    return new List<Requisition>();
                else
                    throw new Exception("Error on the Deputy level");
            }
        }
    }
}

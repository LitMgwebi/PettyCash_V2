namespace PettyCashPrototype.Services.ApprovalStuctureServices.FinanceApprovalService
{
    public class Deputy : IFinanceApproval
    {
        private IFinanceApproval nextOfficer = null!;
        private PettyCashPrototypeContext _db;
        private string _userId;
        private string firstTitle = "Accountant";
        private string secondTitle = "Bookkeeper";

        public Deputy(PettyCashPrototypeContext db, string userId)
        {
            _userId = userId;
            _db = db;
        }


        public void SetNext(IFinanceApproval nextOfficer) { }


        public async Task<IEnumerable<Requisition>> GetRequisitionsForApproval(string jobTitle)
        {
            if (jobTitle == firstTitle)
            {
                return await _db.Requisitions
                    .Include(a => a.Applicant)
                    .Include(m => m.Manager)
                    .Include(mr => mr.ManagerRecommendation)
                    .Include(gl => gl.Glaccount)
                    .Where(a => a.IsActive == true)
                    .Where(m => m.ManagerRecommendation != null && m.ManagerRecommendation.Description == "Recommended")
                    .Where(a => a.FinanceApproval == null)
                    .Where(ar => ar.AmountRequested < 500)
                    .Where(m => m.Manager!.JobTitle!.Description != firstTitle)
                    .AsNoTracking()
                    .ToListAsync();
            }
            else if (jobTitle == secondTitle)
            {
                return await _db.Requisitions
                    .Include(a => a.Applicant)
                    .Include(m => m.Manager)
                    .Include(gl => gl.Glaccount)
                    .Include(mr => mr.ManagerRecommendation)
                    .Where(a => a.IsActive == true)
                    .Where(m => m.ManagerRecommendation != null && m.ManagerRecommendation.Description == "Recommended")
                    .Where(a => a.FinanceApproval == null)
                    .Where(ar => ar.AmountRequested < 500)
                    .Where(m => m.Manager!.JobTitle!.Description != secondTitle)
                    .AsNoTracking()
                    .ToListAsync();
            }
            else
            {
                return new List<Requisition>();
                //if (nextOfficer != null)
                //    return new List<Requisition>();
                //else
                //    throw new Exception("Error on the Deputy level");
            }
        }
    }
}

using PettyCashPrototype.Models;
using PettyCashPrototype.Services.UserService;

namespace PettyCashPrototype.Services.RequisitionService.IndexHandler
{
    public class GetForIssuingState: IIndexState
    {
        private readonly IUser _user = null!;
        private readonly PettyCashPrototypeContext db;
        private readonly string userId;

        public GetForIssuingState(IUser user, PettyCashPrototypeContext db, string userId) 
        { 
            _user = user;
            this.db = db;
            this.userId = userId;
        }
        public async Task<IEnumerable<Requisition>> GetRequisitions()
        {
            User user = await _user.GetUserById(userId);
            IEnumerable<Requisition> requisitions = new List<Requisition>();
            if (user.JobTitle!.JobTitleId == 16)
            {
                requisitions = await db.Requisitions
                    .Include(a => a.Applicant)
                    .Include(m => m.Manager)
                    .Include(f => f.FinanceOfficer)
                    .Include(gl => gl.Glaccount)
                    .Where(a => a.IsActive == true)
                    .Where(a => a.ManagerRecommendation != null && a.FinanceApproval != null)
                    .AsNoTracking()
                    .ToListAsync();
            }
            return requisitions;
        }
    }
}

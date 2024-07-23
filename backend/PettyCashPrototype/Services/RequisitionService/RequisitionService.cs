using PettyCashPrototype.Models;
using PettyCashPrototype.Services.RequisitionService.CreateHandler;
using PettyCashPrototype.Services.RequisitionService.IndexHandler;

namespace PettyCashPrototype.Services.RequisitionService
{
    public class RequisitionService : IRequisition
    {
        private PettyCashPrototypeContext _db;
        private readonly IUser _user;
        private readonly IGLAccount _glAccount;
        private readonly IJobTitle _jobTitle;
        public RequisitionService(PettyCashPrototypeContext db, IUser user, IGLAccount gLAccount, IJobTitle jobTitle)
        {
            _db = db;
            _user = user;
            _glAccount = gLAccount;
            _jobTitle = jobTitle;
        }

        public async Task<IEnumerable<Requisition>> GetAll(string command, int divisionId, int jobTitleId, string userId, string role)
        {
            try
            {
                GetRequisitionsHandler indexHandler = new GetRequisitionsHandler();
                IEnumerable<Requisition> requisitions = new List<Requisition>();

                if (command == "all")
                {
                    indexHandler.setState(new GetAllState());
                    requisitions = await indexHandler.request(_db);
                } else if (command == "forOne") 
                {
                    indexHandler.setState(new GetForApplicantState());
                    requisitions = await indexHandler.request(_db, userId: userId);
                } else if (command == "recommendation")
                {
                    indexHandler.setState(new GetForRecommendationState(_user));
                    requisitions = await indexHandler.request(_db, userId: userId, role: role);
                } else if(command == "approval")
                {
                    indexHandler.setState(new GetForApprovalState());
                    requisitions = await indexHandler.request(_db, jobTitleId: jobTitleId, divisionId: divisionId, _jobTitle: _jobTitle);
                }
                return requisitions;
            }
            catch { throw; }
        }

        public async Task<Requisition> GetOne(int id)
        {
            try
            {
                Requisition requisition = await _db.Requisitions
                    .Include(m => m.ManagerRecommendation)
                    .Include(f => f.FinanceApproval)
                    .Include(m => m.Manager)
                    .Include(f => f.FinanceOfficer)
                    .Include(z => z.Applicant)
                    .Include(gl => gl.Glaccount)
                    .Where(a => a.IsActive == true)
                    .AsNoTracking()
                    .FirstOrDefaultAsync(i => i.RequisitionId == id);

                if (requisition == null) throw new Exception("System could not retrieve the Requisition requested.");
                return requisition;
            }
            catch { throw; }
        }

        public async Task<string> Create(Requisition requisition , string userId)
        {
            try
            {
                Glaccount glaccount = await _glAccount.GetOne(requisition.GlaccountId);
                CreateRequisitionHandler createHandler = new CreateRequisitionHandler();
                string message = string.Empty;

                if(glaccount.NeedsMotivation == true)
                {
                    createHandler.setState(new WithMotivation());
                    message = await createHandler.request(requisition, _db, userId);
                } 
                else if( glaccount.NeedsMotivation == false)
                {
                    createHandler.setState(new WithoutMotivation());
                    message = await createHandler.request(requisition, _db, userId);
                }

                return message;
            }
            catch { throw; }
        }


        public void Edit(Requisition requisition)
        {
            try
            {
                _db.Requisitions.Update(requisition);
                int result = _db.SaveChanges();

                if (result == 0) throw new DbUpdateException($"System could not edit the requisition for {requisition.Applicant!.FullName}.");
            }
            catch { throw; }
        }

        public void SoftDelete(Requisition requisition)
        {
            try
            {
                requisition.IsActive = false;
                _db.Requisitions.Update(requisition);
                int result = _db.SaveChanges();

                if (result == 0) throw new DbUpdateException($"System could not delete the requested requisition.");
            }
            catch { throw; }
        }
    }
}

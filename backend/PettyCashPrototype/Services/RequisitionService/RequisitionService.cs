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
        private readonly IMotivation _motivation;
        public RequisitionService(PettyCashPrototypeContext db, IUser user, IGLAccount gLAccount, IJobTitle jobTitle, IMotivation motivation)
        {
            _db = db;
            _user = user;
            _glAccount = gLAccount;
            _jobTitle = jobTitle;
            _motivation = motivation;
        }

        public async Task<IEnumerable<Requisition>> GetAll(string command, int divisionId, int jobTitleId, string userId, string role)
        {
            try
            {
                GetRequisitionsHandler indexHandler = new GetRequisitionsHandler();
                IEnumerable<Requisition> requisitions = new List<Requisition>();

                if (command == "all")
                {
                    indexHandler.setState(new GetAllState(_db));
                    requisitions = await indexHandler.request();
                } else if (command == "forOne") 
                {
                    indexHandler.setState(new GetForApplicantState(_db, userId));
                    requisitions = await indexHandler.request();
                } else if (command == "recommendation")
                {
                    indexHandler.setState(new GetForRecommendationState(_user, _db, userId, role));
                    requisitions = await indexHandler.request();
                } else if(command == "approval")
                {
                    indexHandler.setState(new GetForApprovalState(_db, divisionId, jobTitleId, _jobTitle, userId));
                    requisitions = await indexHandler.request();
                } else if(command == "issuing")
                {
                    indexHandler.setState(new GetForIssuingState(_user, _db, userId));
                    requisitions = await indexHandler.request();
                } 
                if (requisitions == null) throw new Exception("System could not find any of your requisition forms.");
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

                //requisition!.Motivations = await _motivation.GetAllByRequisition(id);

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

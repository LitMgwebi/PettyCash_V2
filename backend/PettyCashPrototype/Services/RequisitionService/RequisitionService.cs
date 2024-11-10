using PettyCashPrototype.Services.RequisitionService.CreateHandler;
using PettyCashPrototype.Services.RequisitionService.EditHandler;
using PettyCashPrototype.Services.RequisitionService.IndexHandler;

namespace PettyCashPrototype.Services.RequisitionService
{
    public class RequisitionService : IRequisition
    {
        private PettyCashContext _db;
        private readonly IUser _user;
        private readonly ITransaction _transaction;
        private readonly IGLAccount _glAccount;
        private readonly IJobTitle _jobTitle;
        private readonly IStatus _status;
        public RequisitionService(PettyCashContext db, IUser user, IGLAccount gLAccount, IJobTitle jobTitle, ITransaction transaction, IStatus status)
        {
            _db = db;
            _user = user;
            _glAccount = gLAccount;
            _jobTitle = jobTitle;
            _transaction = transaction;
            _status = status;
        }

        public async Task<IEnumerable<Requisition>> GetAll(string command, int divisionId, int jobTitleId, string userId, string role, int statusId, string issuedState)
        {
            try
            {
                GetRequisitionsHandler indexHandler = new GetRequisitionsHandler();
                IEnumerable<Requisition> requisitions = new List<Requisition>();
                Status status = new Status();

                if(statusId > 0)
                    status = await _status.GetOne(statusId);

                if (command == getRequisitionStates.All)
                {
                    indexHandler.setState(new GetAllState(status!));
                    requisitions = await indexHandler.request(_db);
                }
                else if (command == getRequisitionStates.ForOne)
                {
                    indexHandler.setState(new GetForApplicantState(userId, status!));
                    requisitions = await indexHandler.request(_db);
                }
                else if (command == getRequisitionStates.Recommendation)
                {
                    indexHandler.setState(new GetForRecommendationState(_user, userId, role));
                    requisitions = await indexHandler.request(_db);
                }
                else if (command == getRequisitionStates.Approval)
                {
                    indexHandler.setState(new GetForApprovalState(divisionId, jobTitleId, _jobTitle, userId));
                    requisitions = await indexHandler.request(_db);
                }
                else if (command == getRequisitionStates.Opened)
                {
                    indexHandler.setState(new GetAllOpenState(_user, userId));
                    requisitions = await indexHandler.request(_db);
                }
                else if (command == getRequisitionStates.Issued)
                {
                    indexHandler.setState(new GetAllIssuedState(_user, userId, issuedState));
                    requisitions = await indexHandler.request(_db);
                }
                else if (command == getRequisitionStates.Returned)
                {
                    indexHandler.setState(new GetAllReturnedState(_user, userId));
                    requisitions = await indexHandler.request(_db);
                }
                else if (command == getRequisitionStates.Receiving)
                {
                    indexHandler.setState(new GetForReceivingState());
                    requisitions = await indexHandler.request(_db);
                }
                else if (command == getRequisitionStates.Tracking)
                {
                    indexHandler.setState(new GetForTracking());
                    requisitions = await indexHandler.request(_db);
                }
                else
                    throw new NotImplementedException("Could not resolve issue when retrieving requisitions");

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
                    .Include(f => f.Issuer)
                    .Include(f => f.State)
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

        public async Task<string> Create(Requisition requisition, string userId)
        {
            try
            {
                Glaccount glaccount = await _glAccount.GetOne(requisition.GlaccountId);
                CreateRequisitionHandler createHandler = new CreateRequisitionHandler();
                string message = string.Empty;

                if (glaccount.NeedsMotivation == true || requisition.AmountRequested >= 2000)
                {
                    createHandler.setState(new RequireMotivationState());
                    message = await createHandler.request(_db, requisition, userId);
                }
                else if (glaccount.NeedsMotivation == false)
                {
                    createHandler.setState(new StandardCreateState());
                    message = await createHandler.request(_db, requisition, userId);
                }
                else
                {
                    throw new Exception("System could not resolve error within requisition creation.");
                }

                return message;
            }
            catch { throw; }
        }

        public async Task<string> Edit(Requisition requisition, string command, string userId, int attemptCode, bool forDoc)
        {
            try
            {
                string messageResponse = "";
                EditRequisitionHandler editRequisition = new EditRequisitionHandler();
                Requisition reviewRequisition = await GetOne(requisition.RequisitionId);

                if (command == editRequisitionStates.Recommendation)
                {
                    editRequisition.setState(new RecommendationState(reviewRequisition, userId));
                    messageResponse = await editRequisition.request(_db, requisition);
                }
                else if (command == editRequisitionStates.Approval)
                {
                    editRequisition.setState(new ApprovalState(reviewRequisition, userId));
                    messageResponse = await editRequisition.request(_db, requisition);
                }
                else if (command == editRequisitionStates.Edit)
                {
                    editRequisition.setState(new WholeRequisitionState(_glAccount));
                    messageResponse = await editRequisition.request(_db, requisition);
                }
                else if (command == editRequisitionStates.Issuing)
                {
                    editRequisition.setState(new IssuingState(_transaction, userId, attemptCode));
                    messageResponse = await editRequisition.request(_db, requisition);
                }
                else if (command == editRequisitionStates.Expenses)
                {
                    editRequisition.setState(new ExpensesState());
                    messageResponse = await editRequisition.request(_db, requisition);
                }
                else if (command == editRequisitionStates.Return)
                {
                    editRequisition.setState(new ReturnedState());
                    messageResponse = await editRequisition.request(_db, requisition);
                }
                else if(command == editRequisitionStates.Close)
                {
                    editRequisition.setState(new CloseState(_transaction));
                    messageResponse = await editRequisition.request(_db, requisition);
                }
                else if(forDoc == true)
                {
                    editRequisition.setState(new AddDocumentState(command));
                    messageResponse = await editRequisition.request(_db, requisition);
                }
                else
                    throw new Exception("System could not resolve error within requisition editing.");

                return messageResponse;
            }
            catch { throw; }
        }

        public async Task SoftDelete(Requisition requisition)
        {
            try
            {
                if (requisition.FinanceApproval == null)
                {
                    requisition.CloseDate = DateTime.Now;
                    requisition.StateId = 10;
                    requisition.IsActive = false;
                    _db.Requisitions.Update(requisition);
                    int result = await _db.SaveChangesAsync();

                    if (result == 0) throw new DbUpdateException($"System could not delete the requested requisition.");
                }
                else
                    throw new Exception("You cannot delete a requisition once the money has been issued.");
            }
            catch { throw; }
        }
    }
}

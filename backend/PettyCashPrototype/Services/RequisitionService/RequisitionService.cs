using PettyCashPrototype.Services.RequisitionService.CreateHandler;
using PettyCashPrototype.Services.RequisitionService.EditHandler;
using PettyCashPrototype.Services.RequisitionService.IndexHandler;

namespace PettyCashPrototype.Services.RequisitionService
{
    public class RequisitionService : IRequisition
    {
        private PettyCashPrototypeContext _db;
        private readonly IUser _user;
        private readonly ITransaction _transaction;
        private readonly IGLAccount _glAccount;
        private readonly IJobTitle _jobTitle;
        public RequisitionService(PettyCashPrototypeContext db, IUser user, IGLAccount gLAccount, IJobTitle jobTitle, ITransaction transaction)
        {
            _db = db;
            _user = user;
            _glAccount = gLAccount;
            _jobTitle = jobTitle;
            _transaction = transaction;
        }

        public async Task<IEnumerable<Requisition>> GetAll(string command, int divisionId, int jobTitleId, string userId, string role)
        {
            try
            {
                GetRequisitionsHandler indexHandler = new GetRequisitionsHandler();
                IEnumerable<Requisition> requisitions = new List<Requisition>();

                if (command == getRequisitionStates.All)
                {
                    indexHandler.setState(new GetAllState(_db));
                    requisitions = await indexHandler.request();
                }
                else if (command == getRequisitionStates.ForOne)
                {
                    indexHandler.setState(new GetForApplicantState(_db, userId));
                    requisitions = await indexHandler.request();
                }
                else if (command == getRequisitionStates.Recommendation)
                {
                    indexHandler.setState(new GetForRecommendationState(_user, _db, userId, role));
                    requisitions = await indexHandler.request();
                }
                else if (command == getRequisitionStates.Approval)
                {
                    indexHandler.setState(new GetForApprovalState(_db, divisionId, jobTitleId, _jobTitle, userId));
                    requisitions = await indexHandler.request();
                }
                else if (command == getRequisitionStates.Issuing)
                {
                    indexHandler.setState(new GetForIssuingState(_user, _db, userId));
                    requisitions = await indexHandler.request();
                }
                else if (command == getRequisitionStates.Receiving)
                {
                    indexHandler.setState(new GetForReceivingState(_db));
                    requisitions = await indexHandler.request();
                }
                else if (command == getRequisitionStates.Tracking)
                {
                    indexHandler.setState(new GetForTracking(_db));
                    requisitions = await indexHandler.request();
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

        public async Task<string> Create(Requisition requisition, string userId)
        {
            try
            {
                Glaccount glaccount = await _glAccount.GetOne(requisition.GlaccountId);
                CreateRequisitionHandler createHandler = new CreateRequisitionHandler();
                string message = string.Empty;

                if (glaccount.NeedsMotivation == true || requisition.AmountRequested > 2000)
                {
                    createHandler.setState(new RequireMotivationState(requisition, _db, userId));
                    message = await createHandler.request();
                }
                else if (glaccount.NeedsMotivation == false)
                {
                    createHandler.setState(new StandardCreateState(requisition, _db, userId));
                    message = await createHandler.request();
                } else
                {
                    throw new Exception("System could not resolve error within requisition creation.");
                }

                return message;
            }
            catch { throw; }
        }

        public async Task<string> Edit(Requisition requisition, string command, string userId, int attemptCode)
        {
            try
            {
                string messageResponse = "";
                EditRequisitionHandler editRequisition = new EditRequisitionHandler();
                Requisition reviewRequisition = await GetOne(requisition.RequisitionId);

                if (command == editRequisitionStates.Recommendation)
                {
                    editRequisition.setState(new RecommendationState(_db, reviewRequisition, requisition, userId));
                    messageResponse = await editRequisition.request();
                }
                else if (command == editRequisitionStates.Approval)
                {
                    editRequisition.setState(new ApprovalState(_db, reviewRequisition, requisition, userId));
                    messageResponse = await editRequisition.request();
                }
                else if (command == editRequisitionStates.Edit)
                {
                    editRequisition.setState(new WholeRequisitionState(_db, requisition));
                    messageResponse = await editRequisition.request();
                }
                else if (command == editRequisitionStates.Issuing)
                {
                    editRequisition.setState(new IssuingState(_db, _transaction, requisition, userId, attemptCode));
                    messageResponse = await editRequisition.request();
                }
                else if (command == editRequisitionStates.AddMotivation)
                {
                    requisition.Stage = "Motivation has been uploaded. Requisition has been sent for recommendation.";
                    editRequisition.setState(new WholeRequisitionState(_db, requisition));
                    messageResponse = await editRequisition.request();
                }
                else if (command == editRequisitionStates.AddReceipt)
                {
                    requisition.Stage = "Receipt has been uploaded. Please give money back to Accounts Payable.";
                    requisition.ReceiptReceived = true;
                    editRequisition.setState(new WholeRequisitionState(_db, requisition));
                    messageResponse = await editRequisition.request();
                }
                else
                    throw new Exception("System could not resolve error within requisition editing.");

                return messageResponse;
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

namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class WholeRequisitionState : IEditState
    {
        private readonly Requisition requisition;
        private PettyCashPrototypeContext _db;
        private IGLAccount _glAccount;
        public WholeRequisitionState(PettyCashPrototypeContext db, Requisition requisition, IGLAccount gLAccount = null)
        {
            this.requisition = requisition;
            _db = db;
            _glAccount = gLAccount;
        }

        public async Task<string> EditRequisition()
        {
            if (_glAccount != null || requisition.AmountRequested > 2000)
            {
                Glaccount glaccount = await _glAccount!.GetOne(requisition.GlaccountId);
                requisition.Glaccount = glaccount;
                if (glaccount.NeedsMotivation || requisition.AmountRequested > 2000)
                {
                    requisition.NeedsMotivation = true;
                    requisition.Stage = "Requisition has been stored in the system. Motivation must be uploaded before it can be sent for recommendation.";
                }
                else if (!glaccount.NeedsMotivation || requisition.AmountRequested < 2000)
                {
                    requisition.NeedsMotivation = false;
                    requisition.Stage = "Requisiton has been sent for recommendation.";
                }
            }
            if (requisition.ManagerRecommendationId == null)
            {
                
                _db.Requisitions.Update(requisition);
                int result = await _db.SaveChangesAsync();

                if (result == 0) throw new DbUpdateException($"System could not edit the requisition for {requisition.Applicant!.FullName}.");

                return "The requisition has been edited.";
            }
            else
            {
                throw new Exception("You cannot edit a requisition after recommendation.");
            }
        }
    }
}

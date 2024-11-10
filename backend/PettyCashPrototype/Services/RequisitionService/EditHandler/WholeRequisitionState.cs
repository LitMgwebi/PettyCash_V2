namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class WholeRequisitionState : IEditState
    {
        private IGLAccount _glAccount;
        public WholeRequisitionState(IGLAccount gLAccount)
        {
            _glAccount = gLAccount;
        }

        public async Task<string> EditRequisition(PettyCashContext _db, Requisition requisition)
        {
            if (requisition.ManagerRecommendationId == null)
            {
                /*
                An email to be sent to the user, telling them of the change and the new rules namely:
                 If the a motivation is needed, email will be sent to applicant telling them that the requisition has been edited,
                     and now requires them to upload the motivation
                 Else if there is no motivation needed, email will be sent to the applicant and the line manager telling them about
                     incoming requisition requiring their attention.
                     
                ****Might need to create Chain from CFO down to BK/AA for this email so that it can be used in creating StandardRequisition
                */
                //if (_glAccount != null || requisition.AmountRequested > 2000)
                //{
                Glaccount glaccount = await _glAccount!.GetOne(requisition.GlaccountId);
                requisition.Glaccount = glaccount;
                if (glaccount.NeedsMotivation || requisition.AmountRequested >= 2000)
                {
                    requisition.NeedsMotivation = true;
                    requisition.Stage = "Requisition has been stored in the system. Motivation must be uploaded before it can be sent for recommendation.";
                }
                //else if (!glaccount.NeedsMotivation || requisition.AmountRequested < 2000)
                else
                {
                    requisition.NeedsMotivation = false;
                    requisition.Stage = "Requisiton has been sent for recommendation.";
                }
                //}

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

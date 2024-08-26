namespace PettyCashPrototype.Services.RequisitionService.CreateHandler
{
    public class StandardCreateState : ICreateState
    {
        public async Task<string> CreateRequisition(PettyCashPrototypeContext _db, Requisition requisition, string userId)
        {
            requisition.Stage = "Requisiton has been sent for recommendation.";
            requisition.ApplicantId = userId;
            requisition.StartDate = DateTime.Now;
            requisition.StateId = 5;
            //requisition.Status = "Processing";
            requisition.NeedsMotivation = false;
            /*
            The code for emails to be sent to the applicant and the users Line Manager/GM/Bookkeeper/Accountant for recommendation, stating that this requisition has been started.
            Is there a design pattern I could use to switch between the various potential receivers?
                -Something that chooses based on the role of the user - The role would have to be passed down to this method for that to be operational.
            
            This email must be sent to the applicant as well as the recommender. There will have to be code to differentiate between whether the applicant is in the finance dept or not
            if in finance
                send email to BK and AA as well as applicant
            else 
                send email to applicant and line manager
            
            Might need to create Chain from CFO down to BK/AA for this email so that it can be used in editing WholeRequisition
             */

            _db.Requisitions.Add(requisition);
            if (await _db.SaveChangesAsync() > 0)
            {
                return "The new Requisition has been added to the system";

            }
            else throw new DbUpdateException("System could not add the new Requisition.");
        }
    }
}

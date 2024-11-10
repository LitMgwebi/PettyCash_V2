namespace PettyCashPrototype.Services.RequisitionService.CreateHandler
{
    public class RequireMotivationState: ICreateState
    {
        public async Task<string> CreateRequisition(PettyCashContext _db, Requisition requisition, string userId)
        {
            requisition.Stage = "Requisition has been stored in the system. Motivation must be uploaded before it can be sent for recommendation.";
            requisition.ApplicantId = userId;
            requisition.StartDate = DateTime.Now;
            requisition.StateId = 5;
            //requisition.Status = "Processing";
            requisition.NeedsMotivation = true;
            /*
            The code for emails to be sent to the applicant and the users Line Manager/GM/Bookkeeper/Accountant for recommendation, stating that this requisition has been started.
            Is there a design pattern I could use to switch between the various potential receivers?
                -Something that chooses based on the role of the user - The role would have to be passed down to this method for that to be operational.

            This email needs to be sent to the applicant only. Stating that the applicant has created the motivation but it will not be sent for recommendation until the user uploads a motivation
             */


            _db.Requisitions.Add(requisition);
            if (await _db.SaveChangesAsync() > 0)
            {
                return "The new Requisition has been added to the system. Please upload motivation.";

            }
            else throw new DbUpdateException("System could not add the new Requisition.");
        }
    }
}

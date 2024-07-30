namespace PettyCashPrototype.Services.RequisitionService.CreateHandler
{
    public class RequireMotivationState: ICreateState
    {
        private readonly Requisition requisition;
        private readonly PettyCashPrototypeContext _db;
        private readonly string userId;

        public RequireMotivationState(Requisition requisition, PettyCashPrototypeContext db, string userId)
        {
            this.requisition = requisition;
            _db = db;
            this.userId = userId;
        }
        public async Task<string> CreateRequisition()
        {
            requisition.Stage = "Requisition has been stored in the system. Motivation must be uploaded before it can be sent for recommendation.";
            requisition.ApplicantId = userId;
            requisition.StartDate = DateTime.Now;
            requisition.NeedsMotivation = true;
            /*
            The code for emails to be sent to the applicant and the users Line Manager/GM/Bookkeeper/Accountant for recommendation, stating that this requisition has been started.
            Is there a design pattern I could use to switch between the various potential receivers?
                -Something that chooses based on the role of the user - The role would have to be passed down to this method for that to be operational.

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

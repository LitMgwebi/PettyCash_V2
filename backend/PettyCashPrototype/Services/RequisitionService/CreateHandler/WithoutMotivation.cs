using PettyCashPrototype.Models;

namespace PettyCashPrototype.Services.RequisitionService.CreateHandler
{
    public class WithoutMotivation : ICreateState
    {
        public async Task<string> CreateRequisition(Requisition requisition, PettyCashPrototypeContext _db, string userId)
        {
            requisition.Stage = "Requisiton has been sent for recommendation.";
            requisition.ApplicantId = userId;
            requisition.StartDate = DateTime.Now;
            /*
            The code for emails to be sent to the applicant and the users Line Manager/GM/Bookkeeper/Accountant for recommendation, stating that this requisition has been started.
            Is there a design pattern I could use to switch between the various potential receivers?
                -Something that chooses based on the role of the user - The role would have to be passed down to this method for that to be operational.

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

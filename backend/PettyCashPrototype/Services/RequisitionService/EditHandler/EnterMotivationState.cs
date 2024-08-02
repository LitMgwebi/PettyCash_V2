using PettyCashPrototype.Models;

namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class EnterMotivationState: IEditState
    {
        private PettyCashPrototypeContext _db;
        private Requisition requisition;

        public EnterMotivationState(PettyCashPrototypeContext db, Requisition requisition)
        {
            _db = db;
            this.requisition = requisition;
        } 

        public async Task<string> EditRequisition()
        {
            requisition.Stage = "Motivation has been uploaded. Requisition has been sent for recommendation.";

            EditRequisitionHandler editRequisition = new EditRequisitionHandler();

            editRequisition.setState(new WholeRequisitionState(_db, requisition));
            string messageResponse = await editRequisition.request();

            return messageResponse;
        }
    }
}

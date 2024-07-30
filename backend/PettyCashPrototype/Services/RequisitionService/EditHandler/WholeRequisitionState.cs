namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class WholeRequisitionState : IEditState
    {
        private readonly Requisition requisition;
        private PettyCashPrototypeContext _db;
        public WholeRequisitionState(PettyCashPrototypeContext db, Requisition requisition)
        {
            this.requisition = requisition;
            _db = db;
        }

        public async Task<string> EditRequisition()
        {
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

namespace PettyCashPrototype.Services.RequisitionService.EditHandler
{
    public class AddDocumentState : IEditState
    {
        private readonly Requisition requisition;
        private PettyCashPrototypeContext _db;
        private string type;
        public AddDocumentState(PettyCashPrototypeContext db, Requisition requisition, string type)
        {
            this.requisition = requisition;
            _db = db;
            this.type = type;
        }

        public async Task<string> EditRequisition()
        {
            if (type == typesOfDocument.Motivation)
            {
                requisition.Stage = "Motivation has been uploaded. Requisition has been sent for recommendation.";
                _db.Requisitions.Update(requisition);
                int result = await _db.SaveChangesAsync();

                if (result == 0) throw new DbUpdateException($"System could not update requisition #{requisition.RequisitionId} to acknowledge the motivation being uploaded.");

                return "Motivation has been uploaded successfully.";
            }
            else if (type == typesOfDocument.Receipt)
            {
                requisition.Stage = "Receipt has been uploaded. Please provide change to Accounts Payable.";
                requisition.ReceiptReceived = true;
                _db.Requisitions.Update(requisition);
                int result = await _db.SaveChangesAsync();

                if (result == 0) throw new DbUpdateException($"System could not update requisition #{requisition.RequisitionId} to acknowledge the receipt/s being uploaded.");

                return "Receipt/s uploaded successfully.";
            }
            else
                throw new Exception("System requires correct command to upload document.");
           
        }  
    }
}

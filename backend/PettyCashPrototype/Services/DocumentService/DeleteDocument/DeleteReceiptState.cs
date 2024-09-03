namespace PettyCashPrototype.Services.DocumentService.DeleteDocument
{
    public class DeleteReceiptState : IDeleteDocument
    {
        public async Task<string> DeleteDocument(PettyCashPrototypeContext db, IRequisition _requisition, Document document)
        {
            Requisition requisition = await _requisition.GetOne(document.RequisitionId);
            if (requisition.StateId == 7)
            {
                document.IsActive = false;
                db.Documents.Update(document);
                int result = await db.SaveChangesAsync();

                if (result == 0) throw new DbUpdateException($"System could not delete ${document.FileName}.{document.FileExtension}.");

                return "Receipt has successfully been deleted.";
            }
            else
                throw new Exception("You can only delete a receipt when the requisition is in an Issued state.");
        }
    }
}
